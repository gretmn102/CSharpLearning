namespace App
{
    internal class Program
    {
        public static void Main()
        {
            PlayersRepository playersRepository = new();
            View view = new(playersRepository);
            view.StartMenu();
        }
    }
}
