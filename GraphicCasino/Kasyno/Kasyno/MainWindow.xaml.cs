using Kasyno.Logic;
using Kasyno.View.UserControls;
using System.Security.Principal;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Kasyno
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private Account account = new Account();
        public MainWindow()
        {
            InitializeComponent();
           // accountInfo.Text = "Balans: " + account.getBalance();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                intro.Visibility = Visibility.Hidden;
                hideIntroButton.Visibility = Visibility.Hidden;
                Keyboard.Focus(menu.gameListBox);
                menu.gameListBox.Focus();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            intro.Visibility = Visibility.Hidden;
            hideIntroButton.Visibility = Visibility.Hidden;
            Keyboard.Focus(menu.gameListBox);
            menu.gameListBox.Focus();
        }
    }
}