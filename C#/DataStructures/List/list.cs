namespace MyList
{
    public partial class MyList<T> : IEnumerable<T> where T : IComparable<T> 
    {
        // ===== Fields =====
        private T[] m_items;
        private int m_size;
        private const int m_defaultCapacity = 1;

        // ===== Properties =====
        public int Count => m_size;
        public int Capacity => m_items.Length;
    }

}