internal class Program
{
    private static void Main(string[] args)
    {
        string input;
        do {
            System.Console.WriteLine("Не отстану, пока не напишешь \"exit\"! 👻");
            input = Console.ReadLine();
        } while (input != "exit");
    }
}
