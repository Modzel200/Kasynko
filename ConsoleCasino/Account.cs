using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCasino
{
    public class Account
    {
        private string name;
        private double accBalance;
        public Account()
        {
            if (!File.Exists("account.txt"))
            {
                Console.Write("Podaj swoje imie: ");
                name = Console.ReadLine();
                File.WriteAllText("account.txt",name+"\n"+"1000");
            }
            name = File.ReadLines("account.txt").ElementAtOrDefault(0);
            accBalance = double.Parse(File.ReadLines("account.txt").ElementAtOrDefault(1), CultureInfo.InvariantCulture.NumberFormat);
        }
        public string getName()
        {
            return name;
        }
        public double getBalance()
        {
            return accBalance;
        }
        public void addBalance(double money)
        {
            this.accBalance += money;
            File.WriteAllText("account.txt", name + "\n" + accBalance);
        }
        public void removeBalance(double money)
        {
            this.accBalance -= money;
            File.WriteAllText("account.txt", name + "\n" + accBalance);
        }
        public void getMoreMoney(Assets assets, int bid)
        {
            assets.getMerchant();
            Console.SetCursorPosition(130, 20);
            ConsoleKeyInfo cki;
            Console.Write("Chcesz się może zadłużyć? (Y - weź pożyczkę/N - odmów pożyczki): ");
            cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.Y:
                    this.accBalance = bid;
                    File.WriteAllText("account.txt", name + "\n" + accBalance);
                    break;
                case ConsoleKey.N:
                    break;
            }
            Console.Clear();
        }
    }
}
