using System.Collections;

namespace App
{
    class ItemsContainer : IEnumerable<Item>, IList<Item>, ICollection<Item>
    {
        readonly List<Item> _items;

        public int Count => _items.Count;

        public bool IsReadOnly => ((ICollection<Item>)_items).IsReadOnly;

        public Item this[int index]
        {
            get => ((IList<Item>)_items)[index];
            set => ((IList<Item>)_items)[index] = value;
        }

        public ItemsContainer()
        {
            _items = new();
        }

        public ItemsContainer(Item[] items)
        {
            _items = new();
            foreach (Item item in items)
            {
                _items.Add(item);
            }
        }

        public void Add(Item item)
        {
            ((ICollection<Item>)_items).Add(item);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return ((IEnumerable<Item>)_items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_items).GetEnumerator();
        }

        public int IndexOf(Item item)
        {
            return ((IList<Item>)_items).IndexOf(item);
        }

        public void Insert(int index, Item item)
        {
            ((IList<Item>)_items).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Item>)_items).RemoveAt(index);
        }

        public void Clear()
        {
            ((ICollection<Item>)_items).Clear();
        }

        public bool Contains(Item item)
        {
            return ((ICollection<Item>)_items).Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            ((ICollection<Item>)_items).CopyTo(array, arrayIndex);
        }

        public bool Remove(Item item)
        {
            return ((ICollection<Item>)_items).Remove(item);
        }
    }
}
