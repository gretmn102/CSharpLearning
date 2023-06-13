namespace App
{
    class BooksRepository
    {
        readonly Dictionary<BookId, Book> _books;

        public BooksRepository()
        {
            _books = new();
        }

        public BooksRepository(Book[] books)
        {
            _books = new();
            foreach (Book book in books)
            {
                _books.Add(book.Id, book);
            }
        }

        public void Add(Book book)
        {
            _books.Add(BookId.GenerateNew(), book);
        }

        public void Add(string name, string author, int publishedYear)
        {
            BookId id = BookId.GenerateNew();
            Book book = new(id, name, author, publishedYear);
            _books.Add(id, book);
        }

        public bool Remove(BookId id)
        {
            return _books.Remove(id);
        }

        public Book? Get(BookId id)
        {
            if (_books.TryGetValue(id, out Book? result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Book> GetAll()
        {
            foreach (var (_, book) in _books)
            {
                yield return book;
            }
        }

        public IEnumerable<Book> SearchByName(string pattern)
        {
            string lowerPattern = pattern.ToLower();
            foreach (var (_, book) in _books)
            {
                if (book.Name.ToLower().Contains(lowerPattern))
                {
                    yield return book;
                }
            }
        }

        public IEnumerable<Book> SearchByAuthor(string pattern)
        {
            string lowerPattern = pattern.ToLower();
            foreach (var (_, book) in _books)
            {
                if (book.Author.ToLower().Contains(lowerPattern))
                {
                    yield return book;
                }
            }
        }

        public IEnumerable<Book> SearchByPublishedYear(int publishedYear)
        {
            foreach (var (_, book) in _books)
            {
                if (book.PublishedYear == publishedYear)
                {
                    yield return book;
                }
            }
        }
    }
}
