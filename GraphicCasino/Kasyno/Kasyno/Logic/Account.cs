using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno.Logic
{
    public class Account
    {
        private double accBalance;
        public Account() 
        {
            if(!File.Exists("account.txt"))
            {
                File.WriteAllText("account.txt", "1000");
            }
            accBalance = double.Parse(File.ReadLines("account.txt").ElementAtOrDefault(0), CultureInfo.InvariantCulture.NumberFormat);
        }
        public double getBalance()
        {
            return accBalance;
        }
        public void addBalance(double money)
        {
            this.accBalance += money;
            File.WriteAllText("account.txt", accBalance.ToString());
        }
        public void removeBalance(double money)
        {
            this.accBalance -= money;
            File.WriteAllText("account.txt",accBalance.ToString());
        }
    }
}
