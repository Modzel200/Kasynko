using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Cryptography;


namespace ConsoleCasino.Slots
{
    public class Slots
    {
        Assets assets { get; set; }
        public Slots(Assets assets)
        {
            this.assets = assets;
        }
        public void Game(Account account)
        {
            
            int bet = 0;
            ConsoleKeyInfo cki;
            while (true)
            {
                assets.fillTablesSlots();
                assets.getBalance(account);
                assets.getSlotsTitle();
                Console.SetCursorPosition(0, 9);
                Console.Write("Za ile chcesz wejść? ");
                try
                {
                    bet = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Błędne dane, akceptujemy tylko liczby");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
            Console.Clear();
            EmptyView();
            assets.getBalance(account);
            do
            {
                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.Spacebar:
                        if (!removeBal(account, bet))
                        {
                            break;
                        }
                        assets.getBalance(account);
                        LeverAnim();
                        Lever(account, bet, assets);
                        LeverAnimBack();
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
        }
        public void LeverAnim()
        {
            assets.getSlotsLeverAnim();
        }
        public void LeverAnimBack()
        {
            assets.getSlotsLeverAnimBack();
        }
        public void EmptyView()
        {
            assets.getSlotsTitle();
            assets.getSlotsView();
        }
        public void GameView(int a, int b, int c)
        {
            assets.getSlotsGameView(a, b, c);
        }
        public bool Lever(Account account, int bet, Assets assets)
        {
            assets.getBalance(account);
            Console.CursorVisible = false;
            Random rand = new Random();
            List<int> iters = new List<int>();
            iters.Add(0);
            iters.Add(0);
            iters.Add(0);
            for (int i = 0; i < 30; i++)
            {
                if (i < 10)
                {
                    iters[0] = rand.Next(16);
                }
                if(i < 20)
                {
                    iters[1] = rand.Next(16);
                }
                iters[2] = rand.Next(16);
                GameView(iters[0], iters[1], iters[2]);
                Thread.Sleep(80);
            }
            double prize = assets.slotsWin(iters[0], iters[1], iters[2]);
            if (prize != 1)
            {
                account.addBalance(bet * prize);
                assets.getBigWin();
                return true;
            }
            return false;
        }
        public bool removeBal(Account account, int bet)
        {
            if(account.getBalance()>= bet)
            {
                account.removeBalance(bet);
                return true;
            }
            return false;
        }
    }
}
