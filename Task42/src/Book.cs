namespace App
{
    class Book
    {
        public BookId Id { get; }
        public string Name { get; }
        public string Author { get; }
        public int PublishedYear { get; }

        public Book(BookId bookId, string name, string author, int publishedYear)
        {
            Name = name;
            Author = author;
            PublishedYear = publishedYear;
            Id = bookId;
        }

        public override string ToString()
        {
            return $"{Id}, \"{Name}\", {Author}, {PublishedYear}";
        }
    }
}
