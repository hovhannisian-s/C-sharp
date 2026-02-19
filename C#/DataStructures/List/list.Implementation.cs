using System.Drawing;

namespace MyList
{
    public partial class MyList<T> : IEnumerable<T> where T : IComparable<T>  
    {        
        // ===== Constructors =====
        public MyList()
        {
            m_items = new T[m_defaultCapacity];
            m_size = 0;
        }
        public MyList(int capacity)
        {
            m_items = new T[capacity];
            m_size = 0;
        }
        public MyList(IEnumerable<T> collection)
        {
            if(collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if (collection is ICollection<T> col)
            {
                int count = col.Count;
                m_items = new T[count];
                col.CopyTo(m_items, 0);
                m_size = count;
            }
            else
            {
                m_items = new T[m_defaultCapacity];
                m_size = 0;

                foreach (T item in collection)
                {
                    Add(item); 
                }
            }
        }

        // ===== Indexer =====
        public T this[int index] 
        { 
            get
            {
                if(index >= 0 && index <= m_size)
                {
                    return m_items[index];
                }
            
                throw new IndexOutOfRangeException("Index is out of range.");
            } 
            set
            {
                if(index >= 0 && index <= m_size)
                {
                    m_items[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
            } 
        }

        // // ===== Core Methods =====
        public void Add(T item)
        {
            EnsureCapacity(m_size + 1);
            m_items[m_size++] = item;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            if(collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            foreach (T item in collection)
            {
                Add(item); 
            }

        }

        public void Insert(int index, T item)
        {
            if(index < 0 || index > m_size)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            EnsureCapacity(m_size + 1);

            for(int i = m_size; i > index; i--)
            {
                m_items[i] = m_items[i - 1];
            }
            m_items[index] = item;
            m_size++;
        }
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            foreach(T item in collection)
            {
                Insert(index,item);
                ++index;
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if(index != -1)
            {
                for(int i = index; i < m_size - 1; ++i)
                {
                    m_items[i] = m_items[i + 1];
                }
                --m_size;
                return true;
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= m_size)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            for (int i = index; i < m_size - 1; ++i)
            {
                m_items[i] = m_items[i + 1];
            }

            --m_size;
        }
        public void RemoveRange(int index, int count)
        {
            if(count < 0)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            for(int i = 0; i < count; ++i)
            {
                RemoveAt(index);
            }
        }

        public void Clear()
        {
            m_size = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }
        public int IndexOf(T item)
        {
            for(int i = 0; i < m_size; ++i)
            {
                if(m_items[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        public int LastIndexOf(T item)
        {
            for(int i = m_size - 1; i >= 0; --i)
            {
                if(m_items[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public T Find(Predicate<T> match)
        {
            if(match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            for(int i = 0; i < m_size; ++i)
            {
                if(match(m_items[i]))
                {
                    return m_items[i];
                }
            }

            return default(T);
        }
        public MyList<T> FindAll(Predicate<T> match)
        {
            if(match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            MyList<T> result = new MyList<T>();

            for(int i = 0; i < m_size; i++)
            {
                if(match(m_items[i]))
                {
                    result.Add(m_items[i]);
                }
            }

            return result;
        }       

        public bool Exists(Predicate<T> match)
        {
            if(match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            for(int i = 0; i < m_size; i++)
            {
                if(match(m_items[i]))
                {
                    return true;
                }
            }

            return false;
        } 

        public void ForEach(Action<T> action)
        {
            if(action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            for (int i = 0; i < m_size; i++)
            {
                action(m_items[i]);
            }
        }

        public void Reverse()
        {
            for(int i = 0; i < m_size / 2; ++i)
            {
                (m_items[i], m_items[m_size - 1 - i]) = (m_items[m_size - 1 - i],m_items[i]);
            }
        }
        public void Sort(bool asc = true)
        {
            MergeSortAlg(0,m_size-1,asc);
        }

        public T[] ToArray()
        {
            T[] array = new T[m_size];
            for(int i = 0; i < m_size; ++i)
            {
                array[i] = m_items[i];
            }
            return array;
        }

        public void TrimExcess()
        {
            int newCapacity = m_size;
            T[] newArr = new T[newCapacity];
            for(int i = 0; i < m_size; ++i)
            {
                newArr[i] = m_items[i];
            }
            m_items = newArr;
        }


        // Additional 
        public int BinarySearch(T item)
        {
            int left = 0;
            int right = m_size - 1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if(m_items[mid].CompareTo(item) == 0)
                {
                    return mid;
                }
                else if(m_items[mid].CompareTo(item) > 0)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }
        public void CopyTo(T[] array)
        {
            if(array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < m_size)
            {
                throw new ArgumentException("Destination array is too small.");
            }

            for (int i = 0; i < m_size; ++i)
            {
                array[i] = m_items[i];
            }
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (array.Length - arrayIndex < m_size)
            {
                throw new ArgumentException("Destination array is too small.");
            }
            for (int i = 0; i < m_size; ++i)
            {
                array[arrayIndex + i] = m_items[i];
            }
        }
        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            if(array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if(index < 0 || index >= m_size)            
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if(arrayIndex < 0 || arrayIndex >= array.Length)            
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if(count < 0)
            {
                throw new ArgumentException("Count is not valid");
            }
            if(array.Length - arrayIndex < count)
            {
                throw new ArgumentException("Destination array is too small.");
            }
            if(m_size - index < count)
            {
                throw new ArgumentException("Source does not have enough elements.");
            }
            while(count != 0)
            {
                array[arrayIndex++] = m_items[index++];
                count--;
            }
            
        }
        // public IEnumerator<T> GetEnumerator();

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < m_size; i++)
            {
                yield return m_items[i];
            }
        }

        // Non-generic enumerator (required for IEnumerable)
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
                
        // ===== Helpers =====
        public void Print()
        {
            for(int i = 0; i < m_size; ++i)
            {
                System.Console.Write(m_items[i] + " ");
            }
            System.Console.WriteLine();
        }
        private void EnsureCapacity(int min)
        {
            if (m_items.Length >= min)
            {
                return;
            }
            int newCapacity = m_items.Length == 0 ? m_defaultCapacity : m_items.Length * 2;

            if (newCapacity < min)
            {
                newCapacity = min;
            }
            T[] newItems = new T[newCapacity];
            for(int i = 0; i < m_items.Length; ++i)
            {
                newItems[i] = m_items[i];
            }
            m_items = newItems;
        }

        private void MergeSortAlg(int first, int last, bool asc)
        {
            if(first < last)
            {
                int mid = first + (last - first) / 2; 


                MergeSortAlg(first, mid, asc);
                MergeSortAlg(mid + 1, last, asc);

                Merge(first, mid, last, asc);
            }
        }

        private void Merge(int first, int mid, int last, bool asc)
        {
            T[] tempArr = new T[m_items.Length];

            int first1 = first;
            int last1 = mid;

            int first2 = mid + 1;
            int last2 = last;

            int tempIndex = first;

            while((first1 <= last1) && (first2 <= last2))
            {
                int cmp = m_items[first1].CompareTo(m_items[first2]);
                bool takeFirst = asc ? cmp <= 0 : cmp > 0;
                tempArr[tempIndex++] = takeFirst ? m_items[first1++] : m_items[first2++];
            }

            while(first1 <= last1)
            {
                tempArr[tempIndex++] = m_items[first1++];
            }

            while(first2 <= last2)
            {
                tempArr[tempIndex++] = m_items[first2++];
            }

            for(int i = first; i <= last; ++i)
            {
                m_items[i] = tempArr[i];
            }
        }
    }

}   