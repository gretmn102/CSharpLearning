internal class Program
{
    public static void ArrayRemoveAt<T>(ref T[] arr, int index)
    {
        if (!(0 <= index && index < arr.Length)) {
            throw new ArgumentException("index must be greater than or equal to zero and less than the length of the array", nameof(index));
        }
        int length = arr.Length - 1;

        for (int i = index; i < length; i++)
        {
            arr[i] = arr[i + 1];
        }
        Array.Resize(ref arr, length);
    }

    public static void ArrayAdd<T>(T item, ref T[] arr)
    {
        int length = arr.Length;
        Array.Resize(ref arr, length + 1);
        arr[length] = item;
    }

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

    private static void HeroDraw()
    {
        CanvasSet(_heroId, _heroX, _heroY);
    }

    const char _wallId = 'x';

    const char _coinId = 'c';

    const char _emptySpaceId = ' ';

    static char[,] _canvas = null!;

    static void CanvasInit(int width, int height)
    {
        _canvas = new char[height, width];
    }

    static void CanvasSet(char sprite, int x, int y)
    {
        _canvas[y, x] = sprite;
    }

    static void CanvasDraw()
    {
        int height = CanvasGetHeigth();
        int width = CanvasGetWidth();
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(_canvas[y, x]);
            }
            Console.WriteLine();
        }
    }

    static int CanvasGetWidth()
    {
        return _canvas.GetLength(1);
    }

    static int CanvasGetHeigth()
    {
        return _canvas.GetLength(0);
    }


    static bool[,] _walls = null!;
    static void WallInit(int width, int height)
    {
        _walls = new bool[height, width];
    }

    static void WallsSet(bool isWall, int x, int y)
    {
        _walls[y, x] = isWall;
    }

    static bool WallsGet(int x, int y)
    {
        return _walls[y, x];
    }

    static int WallsGetWidth()
    {
        return _walls.GetLength(1);
    }

    static int WallsGetHeigth()
    {
        return _walls.GetLength(0);
    }


    /// <summary>
    /// Поскольку структуры пока не доступны, поэтому придется
    /// завести массив из массивов двух int'ов, первый элемент
    /// из которых является положением монеты на оси X, а
    /// второй — положением на оси Y.
    /// </summary>
    static int[][] _coins = null!;

    static void CoinsInit(int length)
    {
        _coins = new int[length][];
    }

    static void CoinsAddCoin(int coinX, int coinY)
    {
        var item = new int[] { coinX, coinY };
        ArrayAdd(item, ref _coins);
    }

    static void CoinsRemoveCoin(int index)
    {
        ArrayRemoveAt(ref _coins, index);
    }

    static void Init(ref char[,] level)
    {
        int height = level.GetLength(0);
        int width = level.GetLength(1);

        WallInit(width, height);
        CoinsInit(0);
        CanvasInit(width, height);

        char current;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                current = level[y, x];
                switch (current)
                {
                    case _wallId:
                        WallsSet(true, x, y);
                        break;
                    case _coinId:
                        CoinsAddCoin(x, y);
                        break;
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

    static void WallsDraw()
    {
        int wallWidth = WallsGetWidth();
        int wallHeight = WallsGetHeigth();
        for (int y = 0; y < wallHeight; y++)
        {
            for (int x = 0; x < wallWidth; x++)
            {
                if (WallsGet(x, y))
                {
                    CanvasSet(_wallId, x, y);
                }
                else
                {
                    CanvasSet(_emptySpaceId, x, y);
                }
            }
        }
    }

    private static int CoinsGetCount()
    {
        return _coins.Length;
    }

    private static void CoinsDraw()
    {
        for (int i = 0; i < _coins.Length; i++)
        {
            int[] coin = _coins[i];
            CanvasSet(_coinId, coin[0], coin[1]);
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
            _heroX = heroNewX;
            _heroY = heroNewY;
        }
    }

    private static void HeroCollisionWall(ref int heroNewX, ref int heroNewY)
    {
        bool isWall = WallsGet(heroNewX, heroNewY);
        if (isWall)
        {
            heroNewX = _heroX;
            heroNewY = _heroY;
        }
    }

    private static void HeroCollisionWorldUpdate(ref int heroNewX, ref int heroNewY)
    {
        int worldWidth = _walls.GetLength(1);
        int worldHeight = _walls.GetLength(0);

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

    static void HeroCoinCollision()
    {
        for (int i = 0; i < CoinsGetCount(); i++)
        {
            int[] coin = _coins[i];
            if (_heroX == coin[0] && _heroY == coin[1])
            {
                CoinsRemoveCoin(i);
                i--;
            }
        }
    }

    static void PhysicsUpdate()
    {
        HeroCollisionUpdate();
        HeroCoinCollision();
        HeroSlowDown();
    }

    static void InfoDraw()
    {
        Console.WriteLine("WASD (← ↑ → ↓) — перемещение");
        int coinsCount = CoinsGetCount();
        Console.WriteLine($"Осталось собрать монет {coinsCount}");
    }

    static void GraphicsUpdate()
    {
        Console.Clear();
        WallsDraw();
        CoinsDraw();
        HeroDraw();
        CanvasDraw();
        InfoDraw();
    }

    private static void Main()
    {
        var level = new char[,] {
            { 'h', 'x', ' ', ' ', ' ' },
            { ' ', ' ', ' ', 'x', ' ' },
            { 'x', 'x', ' ', 'x', ' ' },
            { 'c', ' ', ' ', 'x', 'c' }};

        Console.WriteLine("Loading level...");
        Init(ref level);
        Console.WriteLine("Level is loaded.");

        Console.CursorVisible = false;

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
