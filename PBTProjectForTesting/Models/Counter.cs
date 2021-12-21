namespace PBTProjectForTesting.Models
{
    public class Counter
    {
        private int _count;

        public Counter()
        {
            _count = 0;
        }

        public void Inc()
        {
            _count++;
        }

        public void Dec()
        {
            if (_count > 2) _count -= 2;
            else _count--;
        }

        public int Get()
        {
            return _count;
        }

        public string ToString()
        {
            return "Counter=" + _count;
        } 
    }
}