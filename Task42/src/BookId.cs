namespace App
{
    struct BookId : IEquatable<BookId>
    {
        public int Id { get; }

        static int _lastId = 0;

        public BookId(int id)
        {
            Id = id;
        }

        public static BookId GenerateNew()
        {
            BookId bookId = new(_lastId);
            _lastId++;
            return bookId;
        }

        public static bool TryParse(string input, out BookId result)
        {
            bool isValid = int.TryParse(input, out int intId);
            result = new BookId(intId);
            return isValid;
        }

        public override readonly string ToString()
        {
            return Id.ToString();
        }

        readonly bool IEquatable<BookId>.Equals(BookId other)
        {
            return Id == other.Id;
        }

        public override readonly bool Equals(object? obj)
        {
            return obj is BookId id && ((IEquatable<BookId>)this).Equals(id);
        }

        public override readonly int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
