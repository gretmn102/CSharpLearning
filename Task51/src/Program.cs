namespace App
{
    internal class Program
    {
        public static void Main()
        {
            // Random random = new();
            int length = 20; // random.Next(10, 20);
            Villain[] villains = new Villain[length];
            for (int i = 0; i < length; i++)
            {
                villains[i] = VillainGenerator.Generate();
            }
            VillainsRepository villainsRepository = new(villains);

            Controller controller = new(villainsRepository);
            controller.Start();
        }
    }
}
