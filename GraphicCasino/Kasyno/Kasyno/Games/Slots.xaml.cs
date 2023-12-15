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
using System.Windows.Threading;
using System.Xml.Linq;

namespace Kasyno.Games
{
    public class SlotsElement
    {
        public SlotsElement(int Id, string Name, string ImageUrl, List<string> AsciTab)
        {
            this.Id = Id;
            this.Name = Name;
            this.ImageUrl = ImageUrl;
            this.AsciTab = AsciTab;
        }
        public SlotsElement(int Id, string Name, string ImageUrl, double value)
        {
            this.Id = Id;
            this.Name = Name;
            this.ImageUrl = ImageUrl;
            this.AsciTab = AsciTab;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<string>? AsciTab { get; set; }
        public double Value {  get; set; }
    }
    public partial class Slots : Window
    {
        private Random random = new Random();
        private Account account = new Account();
        private List<SlotsElement> elements;
        private int move = 0;
        private DispatcherTimer timer = new DispatcherTimer();
        private List<int> iters = new List<int>();
        public Slots()
        {
            InitializeComponent();
            initList();
            accBalance.Text = "Balans: " + account.getBalance();
        }
        private void initList()
        {
            elements = new List<SlotsElement>();
            elements.Add(new SlotsElement(1, "Diament", "diamondslots.png", 5));
            elements.Add(new SlotsElement(2, "Wiśienki", "cherryslots.png", 1.5));
            elements.Add(new SlotsElement(3, "Śliwka", "plumslots.png", 1.25));
            elements.Add(new SlotsElement(4, "Dzwon", "bellslots.png", 2));
            elements.Add(new SlotsElement(5, "Koniczyna", "cloverslots.png", random.NextDouble() + 2));
            elements.Add(new SlotsElement(6, "Cytryna", "lemonslots.jpg", 2.33));
            elements.Add(new SlotsElement(7, "Moneta", "coinslots.png", 4.5));
            elements.Add(new SlotsElement(8, "Bar", "barslots.png", 1.33));
            elements.Add(new SlotsElement(9, "Jabłko", "appleslots.png", 3));
            elements.Add(new SlotsElement(10, "Serce", "heartslots.png", 0.5));
            elements.Add(new SlotsElement(11, "Winogrono", "grappesslots.png", 3.25));
            elements.Add(new SlotsElement(12, "Pomarańcza", "orangeslots.png", 2.1));
            elements.Add(new SlotsElement(13, "Podkowa", "horseshoeslots.png", 3.45));
            elements.Add(new SlotsElement(14, "Siedem", "sevenslots.png", 4.32));
            elements.Add(new SlotsElement(15, "Znak zapytania", "questionmarkslots.png", 1.33));
            elements.Add(new SlotsElement(16, "Arbuz", "watermelonslots.png", 2.20));
        }
        private double slotsWin(int a, int b, int c)
        {
            if ((elements[a].Id == elements[b].Id) && (elements[b].Id == elements[c].Id))
            {
                return elements[a].Value;
            }
            return 1;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            slot1.Visibility = Visibility.Visible;
            slot2.Visibility = Visibility.Visible;
            slot3.Visibility = Visibility.Visible;
            bigWin.Visibility = Visibility.Hidden;
            account.removeBalance(double.Parse(bet.Text, CultureInfo.InvariantCulture.NumberFormat));
            accBalance.Text = "Balans: " + account.getBalance();
            iters = new List<int>();
            iters.Add(0);
            iters.Add(0);
            iters.Add(0);
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += dispatcherTimer_Tick;
            timer.Start();
        }
        private void dispatcherTimer_Tick(object? sender, EventArgs? e)
        {
            move++;
            if(move < 30)
            {
                iters[0] = random.Next(16);
                iters[1] = random.Next(16);
                iters[2] = random.Next(16);
                slot1.Source = new ImageSourceConverter().ConvertFromString(elements[iters[0]].ImageUrl) as ImageSource;
                slot2.Source = new ImageSourceConverter().ConvertFromString(elements[iters[1]].ImageUrl) as ImageSource;
                slot3.Source = new ImageSourceConverter().ConvertFromString(elements[iters[2]].ImageUrl) as ImageSource;
            } else
            {
                double prize = slotsWin(iters[0], iters[1], iters[2]);
                if (prize != 1)
                {
                    slot1.Visibility = Visibility.Hidden;
                    slot2.Visibility = Visibility.Hidden;
                    slot3.Visibility = Visibility.Hidden;
                    bigWin.Visibility = Visibility.Visible;
                    account.addBalance(double.Parse(bet.Text, CultureInfo.InvariantCulture.NumberFormat) * 2);
                    accBalance.Text = "Balans: " + account.getBalance();
                }
                move = 0;
                timer.Stop();
            }
        }
    }
}
