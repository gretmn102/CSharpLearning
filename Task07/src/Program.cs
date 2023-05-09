internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Вы заходите в поликлинику и видите...");
        Console.Write("Введите кол-во старушек: ");
        int oldLadiesCount = Int32.Parse(Console.ReadLine());

        Console.WriteLine($"...и видите {oldLadiesCount} старушек!");

        int minutesCostPerPatient = 10;

        Console.WriteLine($"Вы занимаете очередь и развешиваете уши. Ближайшая старушка с превеликим упоением начинает рассказывать про зеленое солнце и яркую траву из далекого прошлого. А еще она вскользь упоминает, что доктор обслуживает каждого пациента ровно за {minutesCostPerPatient} минут.");

        Console.WriteLine($"— Раньше, безусловно, было лучше, — поучительным тоном добавляет она, а вы тем временем принимаетесь подсчитывать оставшееся время.");

        int remainingAllMinutes = oldLadiesCount * minutesCostPerPatient;
        int remainingHours = remainingAllMinutes / 60;
        int remainingMins = remainingAllMinutes % 60;

        Console.WriteLine($"Раз старушек — {oldLadiesCount}, а время на обслуживание каждой — {minutesCostPerPatient} минут, тогда сидеть вам тут еще... {remainingHours} часов и {remainingMins} минут!");

        Console.WriteLine($"— Ничего себе! — восклицаете вы вслух, а старушка еще с большей прытью продолжает рассказывать о прекрасном прошлом. К ней подключаются еще старушки, и еще, пока в конце концов до вас не доходит простая истина:");
        Console.WriteLine($"РАНЬШЕ БЫЛО ЛУЧШЕ!");
    }
}
