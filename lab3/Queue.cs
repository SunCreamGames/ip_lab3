using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class Queue<T>
    {
        private List<T> StackContents { get; set; }
        private int Count { get; set; }
        public Queue()
        {
            StackContents = new List<T>();
        }

        public bool IsEmpty => Count == 0;

        public void Enqueue(T element)
        {
            StackContents.Insert(Count, element);
            Count++;
        }
        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue Empty");
            T element = StackContents[0];
            StackContents.RemoveAt(0);
            Count--;

            return element;
        }
        public T First()
        {
            if (!IsEmpty)
                return StackContents[0];
            else
                throw new InvalidOperationException("Queue Empty");
        }
        public T Last()
        {
            return StackContents[Count - 1];
        }
        public void Clear()
        {
            StackContents.Clear();
            Count = 0;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < StackContents.Count; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(this.StackContents[i], default(T)))
                    yield return this.StackContents[i];
                else
                    yield return default;
            }
        }
    }
}
