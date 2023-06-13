namespace App
{
    internal class View
    {
        readonly BooksRepository _booksRepository;

        public View(BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public static void PressToContinue()
        {
            Console.WriteLine("(Нажмите любую кнопку, чтобы продолжить)");
            Console.ReadKey();
        }

        public static int ReadYear()
        {
            string rawPublishedYear;
            int publishedYear;
            while (true)
            {
                rawPublishedYear = Console.ReadLine() ?? "";
                if (!int.TryParse(rawPublishedYear, out publishedYear))
                {
                    Console.WriteLine("Неправильно распознан год. Попробуйте ввести еще раз.");
                }
                else
                {
                    break;
                }
            }

            return publishedYear;
        }

        public void AddBook()
        {
            Console.Clear();
            Console.Write("Введите название книги: ");
            string bookName = Console.ReadLine() ?? "Неизвестное";
            Console.Write("Введите автора книги: ");
            string bookAuthor = Console.ReadLine() ?? "Неизвестный";
            Console.Write("Введите год публикации: ");
            int publishedYear = ReadYear();
            _booksRepository.Add(bookName, bookAuthor, publishedYear);

            Console.WriteLine("Книга успешно добавлена!");

            PressToContinue();
        }

        public void RemoveBook()
        {
            Console.Write("Введите ID книги: ");

            if (!BookId.TryParse(Console.ReadLine() ?? "", out BookId bookId))
            {
                Console.WriteLine("Неправильный ID");
            }
            else if (!_booksRepository.Remove(bookId))
            {
                Console.WriteLine($"Книга с {bookId}ID не найдена!");
            }
            else
            {
                Console.WriteLine("Книга успешно удалена!");
            }

            PressToContinue();
        }

        static public void DisplayBooks(IEnumerable<Book> books)
        {
            Console.WriteLine("Id, Название, Автор, Год публикации");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        public void DisplayAllBooks()
        {
            DisplayBooks(_booksRepository.GetAll());

            PressToContinue();
        }

        public void DisplayBooksByName()
        {
            Console.Write("Введите примерное название книги: ");
            string name = Console.ReadLine() ?? "";
            DisplayBooks(_booksRepository.SearchByName(name));

            PressToContinue();
        }

        public void DisplayBooksByAuthor()
        {
            Console.Write("Введите примерно автора книги: ");
            string author = Console.ReadLine() ?? "";
            DisplayBooks(_booksRepository.SearchByAuthor(author));

            PressToContinue();
        }

        public void DisplayBooksByPublishedYear()
        {
            Console.Write("Введите год публикации книги: ");
            int year = ReadYear();
            DisplayBooks(_booksRepository.SearchByPublishedYear(year));

            PressToContinue();
        }

        public void Menu()
        {
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Убрать книгу");
            Console.WriteLine("3. Показать все книги");
            Console.WriteLine("4. Показать книги по названию");
            Console.WriteLine("5. Показать книги по автору");
            Console.WriteLine("6. Показать книги по году");

            string? rawUserCommand = Console.ReadLine();
            switch (rawUserCommand)
            {
                case "1":
                    AddBook();
                    break;

                case "2":
                    RemoveBook();
                    break;

                case "3":
                    DisplayAllBooks();
                    break;

                case "4":
                    DisplayBooksByName();
                    break;

                case "5":
                    DisplayBooksByAuthor();
                    break;

                case "6":
                    DisplayBooksByPublishedYear();
                    break;

                default:
                    Console.WriteLine($"Неизвестная '{rawUserCommand}' команда");
                    PressToContinue();
                    break;
            }
        }

        public void StartMenu()
        {
            while (true)
            {
                Console.Clear();
                Menu();
            }
        }
    }
}
