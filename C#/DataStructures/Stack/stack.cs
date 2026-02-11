namespace MyStack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> m_list = new List<T>();
        private int m_size;

        // Constructors
        public MyStack()
        {
            m_size = 0;
        }

        public MyStack(int size)
        {
            m_size = size;
            m_list = new List<T>(size);
        }

        public MyStack(MyStack<T> other)
        {
            if(other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            m_list = new List<T>(other.m_list);
            m_size = other.m_size;
        }

        public MyStack(IEnumerable<T> range)
        {
            if(range == null)
            {
                throw new ArgumentNullException(nameof(range));
            }
            foreach(var num in range)
            {
                ++m_size;
                m_list.Add(num);
            }
        }

        // Main functions
        public void Push(T item)
        {
            m_list.Add(item);
            ++m_size;
        }

        public T Pop()
        {
            if(m_size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T top = m_list[m_size - 1];

            m_list.RemoveAt(m_size - 1);
            --m_size;
            return top;
        }

        public T Top()
        {
            if (m_size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return m_list[m_size - 1];
        }
        public bool Contains(T item)
        {
            return m_list.Contains(item);
        }

        public void Clear()
        {
            m_list.Clear();
            m_size = 0;
        }

        public T[] ToArray()
        {
            T[] arr = new T[m_size];
            for (int i = 0; i < m_size; i++)
            {
                arr[i] = m_list[m_size - 1 - i];
            }
            return arr;
        }

        public int Count()
        {
            return m_size;
        }

        //foreach 
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = m_size - 1; i >= 0; i--)
            {
                yield return m_list[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}