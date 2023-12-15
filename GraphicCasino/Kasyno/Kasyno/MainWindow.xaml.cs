using Kasyno.Logic;
using Kasyno.View.UserControls;
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

namespace Kasyno
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Account account = new Account();
            accountInfo.Text = "Balans: " + account.getBalance();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            intro.Visibility = Visibility.Hidden;
            hideIntroButton.Visibility = Visibility.Hidden;
        }
    }
}