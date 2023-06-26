using System.Collections;

namespace App
{
    class ProductBasket : IList<Product>
    {
        private readonly List<Product> _products = new();

        public int Capacity { get; }

        public int Count => ((ICollection<Product>)_products).Count;

        public bool IsReadOnly => ((ICollection<Product>)_products).IsReadOnly;

        public Product this[int index]
        {
            get => ((IList<Product>)_products)[index];
            set => ((IList<Product>)_products)[index] = value;
        }

        public ProductBasket(int capacity)
        {
            Capacity = capacity;
        }

        public int CalcTotalCost()
        {
            return _products.Sum(x => x.Price);
        }

        public override string ToString()
        {
            return string.Join(", ", _products.Select(x => x.ToString()));
        }

        public int IndexOf(Product item)
        {
            return ((IList<Product>)_products).IndexOf(item);
        }

        public void Insert(int index, Product item)
        {
            if (IsFull())
            {
                throw new Exception("Product basket is full!");
            }
            ((IList<Product>)_products).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Product>)_products).RemoveAt(index);
        }

        public bool IsFull()
        {
            return _products.Count >= Capacity;
        }

        public void Add(Product item)
        {
            if (IsFull())
            {
                throw new Exception("Product basket is full!");
            }
            ((ICollection<Product>)_products).Add(item);
        }

        public void Clear()
        {
            ((ICollection<Product>)_products).Clear();
        }

        public bool Contains(Product item)
        {
            return ((ICollection<Product>)_products).Contains(item);
        }

        public void CopyTo(Product[] array, int arrayIndex)
        {
            ((ICollection<Product>)_products).CopyTo(array, arrayIndex);
        }

        public bool Remove(Product item)
        {
            return ((ICollection<Product>)_products).Remove(item);
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return ((IEnumerable<Product>)_products).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_products).GetEnumerator();
        }
    }
}
