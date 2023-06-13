namespace App
{
    internal class Program
    {
        public static void Main()
        {
            BooksRepository booksRepository = new(
                new Book[] {
                    new Book(BookId.GenerateNew(), "Дагон", "Говард Филлипс Лавкрафт", 1917),
                    new Book(BookId.GenerateNew(), "Кибериада", "Станислав Герман Лем", 1964)
                }
            );
            View view = new(booksRepository);
            view.StartMenu();
        }
    }
}
