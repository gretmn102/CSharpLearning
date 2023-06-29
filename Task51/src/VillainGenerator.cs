namespace App
{
    static class VillainGenerator
    {
        public static HashSet<string> FirstNames { get; } = new(new string[] {
            "Kurt",
            "Ray",
            "Russ",
            "Stan",
            "Vince",
            "Walter",
            "Tom",
            "Braden",
            "Luke",
            "Oscar",
        });

        public static HashSet<string> LastNames { get; } = new(new string[] {
            "Stone",
            "Carver",
            "Granger",
            "Chase",
            "Nolan",
            "Granger",
            "Gunn",
            "King",
            "Armstrong",
            "Snow",
        });

        public static int MinHeight { get; set; } = 160;
        public static int MaxHeight { get; set; } = 200;

        public static int MinWeight { get; set; } = 60;
        public static int MaxWeight { get; set; } = 150;

        public static HashSet<string> Nationalities { get; } = new(new string[] {
            "Odrierus",
            "Hafriosal",
            "Ugril",
            "Ustrya",
            "Straerus",
            "Shiyrhiel",
            "Ewhesh",
            "Otrana",
        });

        private static readonly Random Random = new();

        public static Villain Generate() => new()
        {
            FirstName = FirstNames.ElementAt(Random.Next(0, FirstNames.Count)),
            LastName = LastNames.ElementAt(Random.Next(0, LastNames.Count)),
            IsArrested = Random.Next(0, 2) > 0,
            Height = Random.Next(MinHeight, MaxHeight + 1),
            Weight = Random.Next(MinWeight, MaxWeight + 1),
            Nationality = Nationalities.ElementAt(Random.Next(0, Nationalities.Count))
        };
    }
}
