internal class Program
{
    // я забыл, что значит структура:

    /// <summary>ID, он же выполняет роль спрайта</summary>
    const char _heroId = 'h';
    static int _heroX = 0;
    static int _heroY = 0;
    static int _heroSpeedX = 0;
    static int _heroSpeedY = 0;
    const int _heroSpeed = 1;
    const int _heroMaxSpeed = 1;
    const int _heroBrakingSpeed = 1; // ускоряется на единицу, тормозит на единицу...

    static int HeroCalcSpeedClamp(int newSpeed)
    {
        if (newSpeed < -_heroMaxSpeed)
        {
            return -_heroMaxSpeed;
        }
        if (newSpeed > _heroMaxSpeed)
        {
            return _heroMaxSpeed;
        }
        return newSpeed;
    }
    static void HeroSetSpeedX(int newSpeed)
    {
        _heroSpeedX = HeroCalcSpeedClamp(newSpeed);
    }
    static void HeroIncreaseSpeedX(int increaseSpeedOn)
    {
        HeroSetSpeedX(_heroSpeedX + increaseSpeedOn);
    }
    static void HeroSetSpeedY(int newSpeed)
    {
        _heroSpeedY = HeroCalcSpeedClamp(newSpeed);
    }
    static void HeroIncreaseSpeedY(int increaseSpeedOn)
    {
        HeroSetSpeedY(_heroSpeedY + increaseSpeedOn);
    }

    private static void HeroSlowDown()
    {
        if (_heroSpeedX < 0)
        {
            HeroIncreaseSpeedX(_heroBrakingSpeed);
        }
        else if (_heroSpeedX > 0)
        {
            HeroIncreaseSpeedX(-_heroBrakingSpeed);
        }

        if (_heroSpeedY < 0)
        {
            HeroIncreaseSpeedY(_heroBrakingSpeed);
        }
        else if (_heroSpeedY > 0)
        {
            HeroIncreaseSpeedY(-_heroBrakingSpeed);
        }
    }

    const char _wallId = 'x';

    const char _chestId = 'c';

    const char _emptySpaceId = ' ';

    static char[,] _world = null!;

    static void WorldInit(ref char[,] level)
    {
        int height = level.GetLength(0);
        int width = level.GetLength(1);

        _world = level;

        char current;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                current = level[y, x];
                switch (current)
                {
                    case _wallId:
                    case _chestId:
                    case _emptySpaceId:
                        break;
                    case _heroId:
                        _heroX = x;
                        _heroY = y;
                        break;
                    default:
                        throw new Exception($"Not recognize `{current}` at ({x}, {y})");
                }
            }
        }

    }

    static void WorldSetEntity(char entity, int x, int y)
    {
        _world[y, x] = entity;
    }

    static char WorldGetEntity(int x, int y)
    {
        return _world[y, x];
    }

    static void WorldPrint()
    {
        int worldWidth = _world.GetLength(1);
        int worldHeight = _world.GetLength(0);
        for (int y = 0; y < worldHeight; y++)
        {
            for (int x = 0; x < worldWidth; x++)
            {
                Console.Write(_world[y, x]);
            }
            Console.WriteLine();
        }
    }

    /// возвращает true, если пользователь передвинул персонажа
    static bool UserInputUpdate()
    {
        ConsoleKeyInfo cki = Console.ReadKey(true);
        switch (cki.Key)
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                HeroIncreaseSpeedY(-_heroSpeed);
                return true;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                HeroIncreaseSpeedY(_heroSpeed);
                return true;
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                HeroIncreaseSpeedX(-_heroSpeed);
                return true;
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                HeroIncreaseSpeedX(_heroSpeed);
                return true;
            default:
                return false;
        }
    }

    private static void HeroCollisionUpdate()
    {
        int heroNewX = _heroX + _heroSpeedX;
        int heroNewY = _heroY + _heroSpeedY;

        HeroCollisionWorldUpdate(ref heroNewX, ref heroNewY);

        HeroCollisionWall(ref heroNewX, ref heroNewY);

        if (_heroX != heroNewX || _heroY != heroNewY)
        {
            WorldSetEntity(_emptySpaceId, _heroX, _heroY);
            _heroX = heroNewX;
            _heroY = heroNewY;
            WorldSetEntity(_heroId, _heroX, _heroY);
        }
    }

    private static void HeroCollisionWall(ref int heroNewX, ref int heroNewY)
    {
        switch (WorldGetEntity(heroNewX, heroNewY))
        {
            case _emptySpaceId:
                break;
            default:
                heroNewX = _heroX;
                heroNewY = _heroY;
                break;
        }
    }

    private static void HeroCollisionWorldUpdate(ref int heroNewX, ref int heroNewY)
    {
        int worldWidth = _world.GetLength(1);
        int worldHeight = _world.GetLength(0);

        if (heroNewX < 0)
        {
            heroNewX = 0;
        }
        else if (heroNewX > worldWidth - 1)
        {
            heroNewX = worldWidth - 1;
        }

        if (heroNewY < 0)
        {
            heroNewY = 0;
        }
        else if (heroNewY > worldHeight - 1)
        {
            heroNewY = worldHeight - 1;
        }
    }

    static void PhysicsUpdate()
    {
        HeroCollisionUpdate();
        HeroSlowDown();
    }

    static void InfoPrint()
    {
        Console.WriteLine("WASD (← ↑ → ↓) — перемещение");
    }

    static void GraphicsUpdate()
    {
        Console.Clear();
        WorldPrint();
        InfoPrint();
    }

    private static void Main()
    {
        var level = new char[,] {
            { 'h', 'x', ' ', ' ', ' ' },
            { ' ', ' ', ' ', 'x', ' ' },
            { 'x', 'x', ' ', 'x', ' ' },
            { 'c', ' ', ' ', 'x', 'c' }};

        Console.WriteLine("Loading level...");
        WorldInit(ref level);
        Console.WriteLine("Level is loaded.");

        GraphicsUpdate();

        while (true)
        {
            bool isMoved = UserInputUpdate();
            if (isMoved)
            {
                PhysicsUpdate();
                GraphicsUpdate();
            }
        }
    }
}
