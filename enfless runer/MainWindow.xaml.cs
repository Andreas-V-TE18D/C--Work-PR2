using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//För timer 
using System.Windows.Threading;

namespace enfless_runer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //variabler 

        DispatcherTimer gameTimer = new DispatcherTimer();

        //hitboxar 
        Rect playerHitBox;
        Rect groundHitBox;
        Rect obstacleHitBox;

        bool jumping; //För att se om spelaren hoppar eller inte

        int force = 20;
        int speed = 5;

        Random rnd = new Random();

        bool gameOver; //variabel för när spelet är slut 

        double spriteIndex = 0;


        ImageBrush playerSprite = new ImageBrush();
        ImageBrush backgroundSprite = new ImageBrush();
        ImageBrush obstacleSprite = new ImageBrush();

        //int array, posionerar hindret på den visuela bakgrunden 
        int[] obstaclePosition = { 320, 310, 300, 305, 315, };

        int score = 0; //int för poängen 


        public MainWindow()
        {
            InitializeComponent();

            MyCanvas.Focus(); //när spelet börjar så har elementet MyCanvas focus först 

            gameTimer.Tick += GameEngine;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);

            // detta tildelar bild till sprite, altså skapar en väg för funktionen att ta bilden från mappen images och sätter den som bakgrund
            backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/background.gif"));

            background.Fill = backgroundSprite;
            background2.Fill = backgroundSprite;


            StartGame();

        }

        private void GameEngine(object sender, EventArgs e)
        {
            //för rörande backgrund, altså hur snabbt bakcgrunden rör sig 
            Canvas.SetLeft(background, Canvas.GetLeft(background) - 3); //man kan ändra de här siffrorna för att justera hastigheten på spelet
            Canvas.SetLeft(background2, Canvas.GetLeft(background2) - 3);//högre sifra ger hörge hastighet

           if (Canvas.GetLeft(background) < - 1262) 
            {
                Canvas.SetLeft(background, Canvas.GetLeft(background2) + background2.Width);
            }

            if (Canvas.GetLeft(background2) < -1262)
            {
                Canvas.SetLeft(background2, Canvas.GetLeft(background) + background.Width);
            }


            Canvas.SetTop(player, Canvas.GetTop(player) + speed);
            Canvas.SetLeft(obstacle, Canvas.GetLeft(obstacle) - 12);

            scoreText.Content = "Score: " + score;


            //tildelar hitboxarna, altså länkar c# koderna med rektanglarna i canvas altså i MainWindow.xaml
            playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width - 15, player.Height);
            obstacleHitBox = new Rect(Canvas.GetLeft(obstacle), Canvas.GetTop(obstacle), obstacle.Width, obstacle.Height);
            groundHitBox = new Rect(Canvas.GetLeft(ground), Canvas.GetTop(ground), ground.Width, ground.Height);

            //sätter up colission för spelaren och marken

            if (playerHitBox.IntersectsWith(groundHitBox))
            {

                speed = 0;

                Canvas.SetTop(player, Canvas.GetTop(ground) - player.Height);

                jumping = false;

                spriteIndex += .5;

                if (spriteIndex > 8)
                {
                    spriteIndex = 1;
                }

                RunSprite(spriteIndex);


            }

            //för hopp funktion 
            if (jumping == true) //hur högt och snabbt spelaren kommer hoppa upåt när mellanslagstangenten släpps
            {
                speed = -9;

                force -= 1;
            }
            else
            {
                speed = 12; //Hastigheten spelaren faller nedåt
            }

            if (force < 0)
            {
                jumping = false;
            }
             
            if (Canvas.GetLeft(obstacle) < -50)
            {
                Canvas.SetLeft(obstacle, 950);

                Canvas.SetTop(obstacle, obstaclePosition[rnd.Next(0, obstaclePosition.Length)]);

                score += 1;

            }
            //om spelaren rör hinder, alltså när playerHitBox rör obstacleHitBox körs det här if. 
            if (playerHitBox.IntersectsWith(obstacleHitBox))
            {
                gameOver = true;

                gameTimer.Stop();
            }

            if (gameOver == true) //Den här if körs när gameover == true altså när spelaren har nudat hindret då visas en röd och svart linje runt hitboxarna och medelandet popar up också  
            {
                obstacle.Stroke = Brushes.Black;
                obstacle.StrokeThickness = 1;

                player.Stroke = Brushes.Red;
                player.StrokeThickness = 1;

                scoreText.Content = "Score: " + score + "Tryck på Enter För att spela igen!!";
            }

            else
            {
                player.StrokeThickness = 0;
                obstacle.StrokeThickness = 0;

            }



        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && gameOver == true) //Om spelaren förlorar kan man trycka enter för att börja om, altså StartGame körs
            {
                StartGame();
            }


        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        { //den här if är till för att när spelaren släpper mellanslagstangenten så körs den här if, då byter playersprite till bild numer 2 tills den landar  
           if (e.Key == Key.Space && jumping == false && Canvas.GetTop(player) > 260) 
            {
                jumping = true;
                force = 15;
                speed = -12;

                playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_02.gif"));
            }



        }

        private void StartGame()//funktion för starta spelet 
        {
            Canvas.SetLeft(background, 0);
            Canvas.SetLeft(background2, 1262);
            //defaoult location för spelaren 
            Canvas.SetLeft(player, 110);
            Canvas.SetTop(player, 140);
            //default location för hindren, ligger utanför visuela screnen 
            Canvas.SetLeft(obstacle, 950);
            Canvas.SetTop(obstacle, 310);

            RunSprite(1);
            // Tildelar bild från mapen images till hinder, altså skapar en väg så att funktionen kan hitta bilden i mapen images
            obstacleSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/obstacle.png"));
            obstacle.Fill = obstacleSprite;

            jumping = false;
            gameOver = false;
            score = 0;

            scoreText.Content = "Score: " + score; //läger till poängen i score

            gameTimer.Start();

        }

        private void RunSprite(double i)
        {
            //byter bilder för att få en animation till spelaren, och skapar en väg för funktionen att hitta bilderna i mappen images  
            switch (i) //alltså switch-satsen byter mellan case-saterna snabbt och varje case avslutas med nyckelordet break;
            {
                case 1:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_01.gif"));
                    break;
                case 2:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_02.gif"));
                    break;
                case 3:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_03.gif"));
                    break;
                case 4:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_04.gif"));
                    break;
                case 5:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_05.gif"));
                    break;
                case 6:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_06.gif"));
                    break;
                case 7:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_07.gif"));
                    break;
                case 8:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_08.gif"));
                    break;



            }
            player.Fill = playerSprite;

        }


    }
}
