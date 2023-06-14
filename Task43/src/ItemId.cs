namespace App
{
    struct ItemId : IEquatable<ItemId>
    {
        public int Id { get; }

        static int _lastId = 0;

        public ItemId(int id)
        {
            Id = id;
        }

        public static ItemId GenerateNew()
        {
            ItemId itemId = new(_lastId);
            _lastId++;
            return itemId;
        }

        public static bool TryParse(string input, out ItemId result)
        {
            bool isValid = int.TryParse(input, out int intId);
            result = new ItemId(intId);
            return isValid;
        }

        public override readonly string ToString()
        {
            return Id.ToString();
        }

        readonly bool IEquatable<ItemId>.Equals(ItemId other)
        {
            return Id == other.Id;
        }

        public override readonly bool Equals(object? obj)
        {
            return obj is ItemId id && ((IEquatable<ItemId>)this).Equals(id);
        }

        public override readonly int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
