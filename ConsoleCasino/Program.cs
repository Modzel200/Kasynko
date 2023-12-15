using ConsoleCasino;
using ConsoleCasino.Roulette;
using ConsoleCasino.Slots;
using System.Runtime.InteropServices;
using ConsoleCasino.Craps;
using ConsoleCasino.BlackJack;

class Program
{
    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();
    private static IntPtr ThisConsole = GetConsoleWindow();
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    private const int HIDE = 0;
    private const int MAXIMIZE = 3;
    private const int MINIMIZE = 6;
    private const int RESTORE = 9;
   
    static void Main(string[] args)
    {
        //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        Console.SetWindowSize(210, 61);
        //ShowWindow(ThisConsole, MAXIMIZE);
        Account account = new Account();
        Assets assets = new Assets();
        assets.Intro();
        do
        {
            Console.Clear();
            assets.getTittle();
            assets.getBalance(account);
            string[] options = { "Slots", "Roulette", "BlackJack", "Craps", "Wyjście" };
            Games games = new Games();
            int game = games.changeOption(options);
            Console.Clear();
            switch (game)
            {
                case 0:
                    Slots slots = new Slots(assets);
                    slots.Game(account);
                    break;
                case 1:
                    Roulette roulette = new Roulette();
                    roulette.Game(account, assets);
                    break;
                case 2:
                    Blackjack bjgame = new Blackjack(assets, account);
                    bjgame.Game();

                    break;
                case 3:
                    Craps craps = new Craps(account);
                    craps.Game(assets);
                    break;
                case 4:
                    assets.outro();
                    Environment.Exit(0);
                    break;
            }
            assets.getTittle();
        } while (true);
        
    }
}
