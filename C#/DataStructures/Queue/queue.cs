namespace MyQueue
{
    public class MyQueue<T> : IEnumerable<T>
    {
        private T[] m_array;
        private int m_head;   
        private int m_tail;  
        private int m_count; 

        // Constructors
        public MyQueue()
        {
            m_head = 0;
            m_tail = -1;
            m_count = 0;
            m_array = Array.Empty<T>();
        }

        public MyQueue(int capacity)
        {
            m_head = 0;
            m_tail = -1;
            m_count = 0;
            m_array = new T[capacity];
        }

        public MyQueue(MyQueue<T> other)
        {
            m_array = new T[other.m_array.Length];
            for(int i = 0; i < m_count; ++i)
            {
                m_array[i] = other.m_array[(other.m_head + i) % other.m_array.Length];
            }
            m_head = 0;
            m_tail = other.m_count - 1;
            m_count = other.m_count;
        }

        public MyQueue(IEnumerable<T> range)
        {
            if (range is ICollection<T> collection)
            {
                m_array = new T[collection.Count];
            }
            else
            {
                m_array = Array.Empty<T>();
            }

            foreach (T item in range)
            {
                Enqueue(item); 
            }
        }

        // Main functions
        public void Enqueue(T item)
        {
            if (m_count == m_array.Length)
            {
                Resize();
            }

            m_tail = (m_tail + 1) % m_array.Length;
            m_array[m_tail] = item;
            if (m_count == 0)
            {
                m_head = m_tail;
            }

            m_count++;
        }

        public T Dequeue()
        {
            if (m_count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T value = m_array[m_head];

            m_head = (m_head + 1) % m_array.Length;

            m_count--;

            return value;
        }

        public T Peek()
        {
            if(m_count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return m_array[m_head];
        }

        public void Clear()
        {
            m_count = 0;
            m_head = 0;
            m_tail = -1;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < m_count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(item, m_array[(m_head + i) % m_array.Length]))
                    return true;
            }
            return false;
        }


        public T[] ToArray()
        {
            T[] arr = new T[m_count];
            for(int i = 0; i < m_count; ++i)
            {
                arr[i] = m_array[(m_head + i) % m_array.Length];
            }

            return arr;
        }

        private void Resize()
        {
            int newCapacity = m_array.Length == 0 ? 2 : m_array.Length * 2;
            T[] newArray = new T[newCapacity];

            for(int i = 0; i < m_count; ++i)
            {
                newArray[i] = m_array[(m_head + i) % m_array.Length];
            }

            m_array = newArray;
            m_head = 0;
            m_tail = m_count - 1;
        }

        public int Count()
        {
            return m_count;
        }
        // foreach
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < m_count; i++)
            {
                yield return m_array[(m_head + i) % m_array.Length];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}