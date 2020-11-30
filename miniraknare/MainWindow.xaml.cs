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

namespace miniraknare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// testing
    public partial class MainWindow : Window
    {

        int nummer1 = 0;
        int nummer2 = 0;
        string funktion = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void knp1_Click(object sender, RoutedEventArgs e)
        {
            if (funktion == "")
            {
                nummer1 = (nummer1 * 10) + 1;
                OutPText.Text = nummer1.ToString();
            }
            else
            {
                nummer2 = (nummer2 * 10) + 1;
                OutPText.Text = nummer2.ToString();

            }
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            if (funktion == "")
            {
                nummer1 = (nummer1 * 10) + 3;
                OutPText.Text = nummer1.ToString();
            }
            else
            {
                nummer2 = (nummer2 * 10) + 3;
                OutPText.Text = nummer2.ToString();

            }
        }

        private void knp2_Click(object sender, RoutedEventArgs e)
        {
            if (funktion == "")
            {
                nummer1 = (nummer1 * 10) + 2;
                OutPText.Text = nummer1.ToString();
            }
            else
            {
                nummer2 = (nummer2 * 10) + 2;
                OutPText.Text = nummer2.ToString();

            }
        }

        private void knp4_Click(object sender, RoutedEventArgs e)
        {
            if (funktion == "")
            {
                nummer1 = (nummer1 * 10) + 4;
                OutPText.Text = nummer1.ToString();
            }
            else
            {
                nummer2 = (nummer2 * 10) + 4;
                OutPText.Text = nummer2.ToString();

            }
        }

        private void knp5_Click(object sender, RoutedEventArgs e)
        {
            if (funktion == "")
            {
                nummer1 = (nummer1 * 10) + 5;
                OutPText.Text = nummer1.ToString();
            }
            else
            {
                nummer2 = (nummer2 * 10) + 5;
                OutPText.Text = nummer2.ToString();

            }
        }

        private void knp6_Click(object sender, RoutedEventArgs e)
        {
            if (funktion == "")
            {
                nummer1 = (nummer1 * 10) + 6;
                OutPText.Text = nummer1.ToString();
            }
            else
            {
                nummer2 = (nummer2 * 10) + 6;
                OutPText.Text = nummer2.ToString();

            }
        }

        private void knp7_Click(object sender, RoutedEventArgs e)
        {
            if (funktion == "")
            {
                nummer1 = (nummer1 * 10) + 7;
                OutPText.Text = nummer1.ToString();
            }
            else
            {
                nummer2 = (nummer2 * 10) + 7;
                OutPText.Text = nummer2.ToString();

            }
        }

        private void knp8_Click(object sender, RoutedEventArgs e)
        {
            if (funktion == "")
            {
                nummer1 = (nummer1 * 10) + 8;
                OutPText.Text = nummer1.ToString();
            }
            else
            {
                nummer2 = (nummer2 * 10) + 8;
                OutPText.Text = nummer2.ToString();

            }
        }

        private void knp9_Click(object sender, RoutedEventArgs e)
        {
            if (funktion == "")
            {
                nummer1 = (nummer1 * 10) + 9;
                OutPText.Text = nummer1.ToString();
            }
            else
            {
                nummer2 = (nummer2 * 10) + 9;
                OutPText.Text = nummer2.ToString();

            }
        }

        private void knp0_Click(object sender, RoutedEventArgs e)
        {
            if (funktion == "")
            {
                nummer1 = (nummer1 * 10);
                OutPText.Text = nummer1.ToString();
            }
            else
            {
                nummer2 = (nummer2 * 10);
                OutPText.Text = nummer2.ToString();

            }
        }

        private void knpPlus_Click(object sender, RoutedEventArgs e)
        {
            funktion = "+";
            OutPText.Text = "0";
        }

        private void knpMinus_Click(object sender, RoutedEventArgs e)
        {
            funktion = "-";
            OutPText.Text = "0";
        }

        private void knpGånger_Click(object sender, RoutedEventArgs e)
        {
            funktion = "*";
            OutPText.Text = "0";
        }

        private void knpDela_Click(object sender, RoutedEventArgs e)
        {
            funktion = "/";
            OutPText.Text = "0";
        }

        private void knpLika_Click(object sender, RoutedEventArgs e)
        {
            switch (funktion)
            {
                case "+":
                    OutPText.Text = (nummer1 + nummer2).ToString();
                    break;
                case "-":
                    OutPText.Text = (nummer1 - nummer2).ToString();
                    break;
                case "*":
                    OutPText.Text = (nummer1 * nummer2).ToString();
                    break;
                case "/":
                    OutPText.Text = (nummer1 / nummer2).ToString();
                    break;
            }
        }

        private void knpRensa_Click(object sender, RoutedEventArgs e)
        {
            if (funktion == "")
            {
                nummer1 = 0;
            }
            else
            {
                nummer2 = 0;
            }
            OutPText.Text = "0";
        }

        private void knpC_Click(object sender, RoutedEventArgs e)
        {
            nummer1 = 0;
            nummer2 = 0;
            funktion = "";
            OutPText.Text = "0";
        }

        private void knpMellan_Click(object sender, RoutedEventArgs e)
        {
            if (funktion == "")
            {
                nummer1 = (nummer1 / 10);
                OutPText.Text = nummer1.ToString();
            }
            else
            {
                nummer2 = (nummer2 / 10);
                OutPText.Text = nummer2.ToString();

            }
        }

        private void knpPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (funktion == "")
            {
                nummer1 *= -1;
                OutPText.Text = nummer1.ToString();
            }
            else
            {
                nummer2 *= -1;
                OutPText.Text = nummer2.ToString();

            }
        }
    }
}
