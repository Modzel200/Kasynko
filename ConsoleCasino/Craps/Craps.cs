namespace ConsoleCasino.Craps;

public class Craps
{

    public Craps(Account account)
    {
        this.account = account;
    }

    private int bid;
    private Random random = new Random();
    private int rand;
    private int number;
    private int write;
    private int throw1;
    private int throw2;
    private List<CrapsElement> crapsImg;
    private Account account;
    public void Game(Assets assets)
    {
        ConsoleKeyInfo cki;
        do
        {
            Console.SetCursorPosition(0, 15);
            assets.getBasicCraps();
            Console.SetCursorPosition(0, 1);
            assets.getCraps();
            assets.getBalance(account);
            Console.WriteLine();
            Console.WriteLine("Wciśnij SPACE żeby rzucić koścmi, ESC żeby wyjść");
            cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.Spacebar:
                    Console.Write("Twój zakład: ");
                    try
                    {
                        bid = int.Parse(Console.ReadLine());
                    }
                    catch(FormatException e)
                    {
                        Console.WriteLine("Błędne dane, akceptujemy tylko liczby");
                        Thread.Sleep(1000);
                        break;
                    }
                    if (account.getBalance() >= bid)
                    {
                        account.removeBalance(bid);
                        Console.Clear();
                        if (Throw(assets))
                        {
                            account.addBalance(2 * bid);
                            Console.SetCursorPosition(100, 21);
                            Console.WriteLine("Wygrywasz, twój aktualny balans:" + account.getBalance());
                            Thread.Sleep(2000);
                            if (bid >= 100)
                            {
                                assets.getBigWin();
                            }
                            Console.Clear();
                        }
                        else
                        {
                            //account.removeBalance(bid);
                            Console.SetCursorPosition(100, 21);
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

    public bool Throw(Assets assets)
    {
        crapsImg = assets.getCrapsImg();
        Console.SetCursorPosition(0, 1);
        assets.getCraps();
        assets.getBalance(account);
        int time = 100;
        Console.CursorVisible = false;
        rand = random.Next() % 20 + 10;
        int newrand;
        Console.SetCursorPosition(10, 12);
        Console.WriteLine("Twój rzut: ");
        while (rand != 0)
        {
            Console.SetCursorPosition(10, 13);
            newrand = (random.Next() % 5) + 1;
            Console.Write(crapsImg[newrand].image);
            rand--;
            throw1 = crapsImg[newrand].number;
            Thread.Sleep(time);
            time += 20;
        }
        Thread.Sleep(2000);
        rand = random.Next() % 20 + 10;
        time = 100;
        Console.SetCursorPosition(10, 36);
        Console.WriteLine("Rzut rywala: ");
        while (rand != 0)
        {
            Console.SetCursorPosition(10, 37);
            newrand = (random.Next() % 5) + 1;
            Console.Write(crapsImg[newrand].image);
            rand--;
            throw2 = crapsImg[newrand].number;
            Thread.Sleep(time);
            time += 20;
        }
        if (throw1 > throw2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}