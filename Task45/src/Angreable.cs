namespace App
{
    class Angreable
    {
        private int _max;
        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        private int _current;
        public int Current
        {
            get { return _current; }
            set
            {
                _current = 0 < value ? (value <= _max ? value : _max) : 0;
            }
        }

        public Angreable(int max, int current = 0)
        {
            Max = max;
            Current = current;
        }
    }
}
