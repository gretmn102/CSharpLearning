namespace App
{
    class Hero
    {
        private int _x;
        private int _y;

        public int X => _x;
        public int Y => _y;

        public Hero(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void SetPos(int x, int y)
        {
            _x = x < 0 ? 0 : x;
            _y = y < 0 ? 0 : y;
        }

        public void Draw()
        {
            for (int y = 0; y < _y; y++)
            {
                Console.WriteLine();
            }
            for (int x = 0; x < _x; x++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("H");
        }
    }

    internal class Program
    {
        static bool UserInputUpdate(Hero hero)
        {
            var cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    hero.SetPos(hero.X, hero.Y - 1);
                    return true;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    hero.SetPos(hero.X, hero.Y + 1);
                    return true;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    hero.SetPos(hero.X - 1, hero.Y);
                    return true;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    hero.SetPos(hero.X + 1, hero.Y);
                    return true;
                default:
                    return false;
            }
        }

        private static void Main()
        {
            Console.CursorVisible = false;
            Console.CancelKeyPress += ((obj, e) => Console.CursorVisible = true);

            Console.Clear();
            Hero hero = new(0, 0);
            hero.Draw();
            while (true)
            {
                bool isMoved = UserInputUpdate(hero);
                if (isMoved)
                {
                    Console.Clear();
                    hero.Draw();
                }
            }
        }
    }
}
