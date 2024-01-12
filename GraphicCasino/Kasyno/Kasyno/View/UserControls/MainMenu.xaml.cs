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
        ListBox listBox;
        ListBoxItem selectedItem;
        int iter;

        public MainMenu()
        {
            InitializeComponent();
        }
        void OnLoaded(object sender, RoutedEventArgs e)
        {
            listBox = (ListBox)sender;
            selectedItem = (ListBoxItem)listBox.SelectedItem;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                listBox.SelectedIndex = 0;
                listBox = (ListBox)sender;
                listBox.Focus();
                selectedItem = (ListBoxItem)listBox.SelectedItem;
            }
            if(e.Key == Key.Up)
            {
                listBox.SelectedIndex = this.iter;
                listBox = (ListBox)sender;
                listBox.Focus();
                selectedItem = (ListBoxItem)listBox.SelectedItem;
            }
            if(e.Key == Key.Enter)
            {
                var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
                if (item != null)
                {
                    string selectedGame = item.Content.ToString();
                    if (selectedGame == "Roulette")
                    {
                        Roulette roulette = new Roulette();
                        roulette.Show();
                    }
                    if (selectedGame == "Craps")
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
                    if (selectedGame == "Exit")
                    {
                        System.Windows.Application.Current.Shutdown();
                    }
                }
            }
        }
        private void PlaceholdersListBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                string selectedGame = item.Content.ToString();
                if (selectedGame == "Roulette")
                {
                    Roulette roulette = new Roulette();
                    roulette.Show();
                }
                if (selectedGame == "Craps")
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
                if (selectedGame == "Exit")
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
