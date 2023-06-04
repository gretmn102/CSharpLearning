namespace App
{
    class User
    {
        string UserName { get; }
        int Rating { get; }

        public User(string userName, int rating)
        {
            UserName = userName;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"Имя пользователя: {UserName}\nЕго рейтинг: {Rating}";
        }
    }

    internal class Program
    {
        private static void Main()
        {
            User user = new("Михаил", 999);
            Console.WriteLine(user);
        }
    }
}
