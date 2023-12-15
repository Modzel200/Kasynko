using Kasyno.Logic;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kasyno.Games
{

    public partial class Craps : Window
    {
        private Random random = new Random();
        private Account account = new Account();
        private int userScore;
        private int botScore;
        private int rand;
        public Craps()
        {
            InitializeComponent();
            accBalance.Text = "Balans: " + account.getBalance();
        }
        private void Won()
        {
            account.addBalance(double.Parse(bet.Text, CultureInfo.InvariantCulture.NumberFormat) * 2);
            accBalance.Text = "Balans: " + account.getBalance();

            info.Text = "Wygrana";
            info.Visibility = Visibility.Visible;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            info.Visibility = Visibility.Hidden;
            userThrow.Visibility = Visibility.Visible;
            botThrow.Visibility = Visibility.Visible;
            bigWin.Visibility = Visibility.Hidden;
            account.removeBalance(double.Parse(bet.Text, CultureInfo.InvariantCulture.NumberFormat));
            accBalance.Text = "Balans: " + account.getBalance();
            rand = random.Next() % 6;
            userScore = rand;
            switch (rand)
            {
                case 0:
                    userThrow.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "dice1.mp4");
                    break;
                case 1:
                    userThrow.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "dice2.mp4");
                    break;
                case 2:
                    userThrow.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "dice3.mp4");
                    break;
                case 3:
                    userThrow.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "dice4.mp4");
                    break;
                case 4:
                    userThrow.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "dice5.mp4");
                    break;
                case 5:
                    userThrow.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "dice6.mp4");
                    break;
            }
            rand = random.Next() % 6;
            botScore = rand;
            switch (rand)
            {
                case 0:
                    botThrow.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "dice1.mp4");
                    break;
                case 1:
                    botThrow.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "dice2.mp4");
                    break;
                case 2:
                    botThrow.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "dice3.mp4");
                    break;
                case 3:
                    botThrow.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "dice4.mp4");
                    break;
                case 4:
                    botThrow.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "dice5.mp4");
                    break;
                case 5:
                    botThrow.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "dice6.mp4");
                    break;
            }
            if(userScore>botScore)
            {
                Won();
            }
            else
            {
                info.Text = "Przegrana";
                info.Visibility = Visibility.Visible;
            }
        }
    }
}
