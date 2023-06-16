namespace App
{
    internal class View
    {
        public void MainSteps()
        {
            Console.Write("Введите место отбытия: ");
            string departure = Console.ReadLine() ?? "Неизвестное";
            Console.Write("Введите место назначения: ");
            string destination = Console.ReadLine() ?? "Неизвестное";
            Console.WriteLine($"Маршрут: {departure}—{destination}");

            Random r = new();
            int from = 1, to = 100;
            int possiblePassengersCount = r.Next(from, to);
            Console.WriteLine($"Количество желающих отправиться по такому маршруту {possiblePassengersCount}.");
            Console.Write("Укажите, скольким нужно продать биллеты: ");
            int passengersCount = ConsoleHelpers.ReadInt(from, possiblePassengersCount + 1);

            Console.Write("Введите название поезда: ");
            string trainName = Console.ReadLine() ?? "Неизвестное";
            Console.WriteLine($"Название поезда: {trainName}");

            int wagonSeats;
            for (int wagonNumber = 1, restPassengersCount = passengersCount;
                restPassengersCount > 0;
                wagonNumber++)
            {
                Console.WriteLine($"Осталось расположить {restPassengersCount} пассажиров.");
                Console.Write($"Введите вместимость {wagonNumber}-го вагона: ");
                wagonSeats = ConsoleHelpers.ReadInt(1, int.MaxValue);
                restPassengersCount -= wagonSeats;
            }

            Console.WriteLine("Поезд готов отправиться в путь!");
        }

        public void Start()
        {
            bool isContinue = true;
            while (isContinue)
            {
                MainSteps();

                Console.Write("Создать еще одно направление? (д/н): ");
                isContinue = ConsoleHelpers.YesOrNo();
            }
        }
    }
}
