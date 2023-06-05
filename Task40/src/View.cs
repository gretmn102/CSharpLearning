namespace App
{
    class View
    {
        readonly PlayersRepository _playersRepository;

        public View(PlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }

        public void AddNewPlayer()
        {
            Console.WriteLine("Введите ник нового игрока: ");
            string nickname = Console.ReadLine() ?? "";
            PlayerId playerId = PlayerId.NewPlayerId();
            Player newPlayer = new(playerId)
            {
                Nickname = nickname
            };
            _playersRepository.Insert(newPlayer);
            Console.WriteLine($"{nickname} успешно добавлен в БД!");
        }

        /// <summary>
        /// Банит первого попавшегося игрока с указанным ником, потому что ники в БД могут повторяться.
        /// </summary>
        public void BanPlayer()
        {
            Console.WriteLine("Введите ник игрока, которого хотите забанить: ");
            string nickname = Console.ReadLine() ?? "";

            Player? player = _playersRepository
                .Where(player => nickname == player.Nickname)
                .FirstOrDefault();

            if (player == null)
            {
                Console.WriteLine($"Игрок с ником '{nickname}' не найден!");
            }
            else if (player.IsBanned)
            {
                Console.WriteLine($"Игрок с ником '{nickname}' уже и так забанен, куда уж еще.");
            }
            else
            {
                player.IsBanned = true;
                _playersRepository.Update(player);
                Console.WriteLine($"Игрок с ником '{nickname}' успешно забанен.");
            }
        }

        public void PrintPlayers()
        {
            if (_playersRepository.Count == 0)
            {
                Console.WriteLine("Ни одного игрока в игре пока что нет.");
            }
            else
            {
                foreach (var player in _playersRepository)
                {
                    Console.WriteLine(player);
                }
            }
        }

        /// <summary>
        /// Разбанивает первого попавшегося игрока с указанным ником, потому что ники в БД могут повторяться.
        /// </summary>
        public void UnbanPlayer()
        {
            Console.WriteLine("Введите ник игрока, которого хотите разбанить: ");
            string nickname = Console.ReadLine() ?? "";

            Player? player = _playersRepository
                .Where(player => nickname == player.Nickname)
                .FirstOrDefault();

            if (player == null)
            {
                Console.WriteLine($"Игрок с ником '{nickname}' не найден!");
            }
            else if (!player.IsBanned)
            {
                Console.WriteLine($"Игрок с ником '{nickname}' не забанен.");
            }
            else
            {
                player.IsBanned = false;
                _playersRepository.Update(player);
                Console.WriteLine($"Игрок с ником '{nickname}' успешно разбанен.");
            }
        }

        public void StartMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите цифру команды:");
                Console.WriteLine("1. Добавить игрока");
                Console.WriteLine("2. Вывести список игроков");
                Console.WriteLine("3. Забанить игрока");
                Console.WriteLine("4. Разбанить игрока");
                string inputCommand = Console.ReadLine() ?? "";
                switch (inputCommand)
                {
                    case "1":
                        AddNewPlayer();
                        break;
                    case "2":
                        PrintPlayers();
                        break;
                    case "3":
                        BanPlayer();
                        break;
                    case "4":
                        UnbanPlayer();
                        break;
                    default:
                        Console.WriteLine($"'{inputCommand}' — Неизвестная команда!");
                        break;
                }

                Console.WriteLine("(Нажмите Enter, чтобы продолжить)");
                while (true)
                {
                    var cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
        }
    }
}
