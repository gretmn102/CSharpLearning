namespace App
{
    class Prisoner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Reason { get; set; }
        public Prisoner(string firstName, string lastName, string reason)
        {
            FirstName = firstName;
            LastName = lastName;
            Reason = reason;
        }
    }

    internal class Program
    {
        private static void DisplayPrissoners(IEnumerable<Prisoner> prisoners)
        {
            foreach (Prisoner prisoner in prisoners)
            {
                Console.WriteLine($"{prisoner.LastName} {prisoner.FirstName}, причина заключения: {prisoner.Reason}");
            }
        }

        private static void Main()
        {
            const string antigovernmentResonType = "Антиправительственное";
            Prisoner[] originalPrisoners = new Prisoner[] {
                new Prisoner("Дуглас", "Смит", "Ограбление"),
                new Prisoner("Рон", "Бадай", antigovernmentResonType),
                new Prisoner("Адамс", "Фендлер", antigovernmentResonType),
                new Prisoner("Батун", "Ихтлер", "Убийство"),
            };

            Console.WriteLine("До амнистии за антиправительственные деяния в великой стране Арстоцка:");
            DisplayPrissoners(originalPrisoners);

            var filteredPrisoners =
                from prisoner in originalPrisoners
                where prisoner.Reason != antigovernmentResonType
                select prisoner;

            Console.WriteLine();
            Console.WriteLine("После:");
            DisplayPrissoners(filteredPrisoners);
        }
    }
}
