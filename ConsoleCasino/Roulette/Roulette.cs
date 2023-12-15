using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCasino.Roulette
{
    public class Roulette
    {
        private List<int> roulette = new List<int>() { 0, 5, 12, 3, 10, 1, 8, 9, 2, 7, 6, 11, 4 };
        
        private Random random = new Random();
        private int rand;
        private int number;
        private int bid;
        private int betNumber;
        private int write;
        private List<RouletteElement> rouletteImg;
        public void Game(Account account, Assets assets)
        {
            ConsoleKeyInfo cki;
            do
            {
                assets.getBalance(account);
                Console.SetCursorPosition(0, 10);
                assets.getBasicRoulette();
                Console.SetCursorPosition(0, 2);
                assets.getRoulette();
                Console.WriteLine();
                Console.WriteLine("\n");
                Console.WriteLine("Wciśnij SPACE żeby zakręcić, ESC żeby wyjść");
                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.Spacebar:
                        Console.Write("Twój zakład: ");
                        try
                        {
                            bid = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Błędne dane, akceptujemy tylko liczby");
                            Thread.Sleep(1000);
                            break;
                        }
                        Console.Write("Ktory numer wybierasz [0-12]: ");
                        betNumber = int.Parse(Console.ReadLine());
                        //Console.Clear();
                        if (account.getBalance() >= bid)
                        {
                            account.removeBalance(bid);
                            Console.Clear();
                            if (Spin(betNumber,assets))
                            {
                                account.addBalance(5*bid);
                                Console.SetCursorPosition(10, 21);
                                Console.WriteLine("Wygrywasz, twój aktualny balans:" + account.getBalance());
                                Thread.Sleep(1000);
                                if(bid>=100)
                                {
                                    assets.getBigWin();
                                }
                                Console.Clear() ;
                            }
                            else
                            {
                                
                                Console.SetCursorPosition(10, 21);
                                Console.WriteLine("Przegrywasz, twój aktualny balans:" + account.getBalance());
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }
                        else
                        {
                            account.getMoreMoney(assets, bid);
                        }
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
        }
        public bool Spin(int bet, Assets assets)
        {
            rouletteImg = assets.getRouletteImg();
            int time = 100;
            Console.CursorVisible = false;
            rand = random.Next() % 20 + 10;
            number = rand;
            while (rand != 0)
            {
                Console.SetCursorPosition(0, 0);
                assets.getRoulette();
                write = number % roulette.Count;
                Console.SetCursorPosition(0, 10);
                Console.Write(rouletteImg[write].image);
                Console.SetCursorPosition(10, 20);
                Console.Write("Aktualnie wygrywa: "+rouletteImg[write].number+"  ");
                rand--;
                number++;
                Thread.Sleep(time);
                time += 20;
            }
            Console.SetCursorPosition(0, 33);
            Console.Write("");
            Console.SetCursorPosition(0, 34);
            Console.SetCursorPosition(10, 20);
            Console.Write("Wygrywa " + rouletteImg[write].number +"           \n");
            if (bet == write)
            {
                return true;
            }
            return false;
        }
    }
}
