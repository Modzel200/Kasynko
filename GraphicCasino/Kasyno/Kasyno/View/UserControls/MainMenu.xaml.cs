using Kasyno.Games;
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

namespace Kasyno.View.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private void gameListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            ListBoxItem selectedItem = (ListBoxItem)listBox.SelectedItem;

            if (selectedItem != null)
            {
                string selectedGame = selectedItem.Content.ToString();
                if(selectedGame=="Roulette")
                {
                    Roulette roulette = new Roulette();
                    roulette.Show();
                }
                if(selectedGame=="Craps")
                {
                    Craps craps = new Craps();
                    craps.Show();
                }
                if (selectedGame == "BlackJack")
                {
                    Blackjack blackjack = new Blackjack();
                    blackjack.Show();
                }
                if (selectedGame == "Slots")
                {
                    Slots slots = new Slots();
                    slots.Show();
                }
                if (selectedGame=="Exit")
                {
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        private void gameListBox_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            listBox.Focus();
        }
    }
}
