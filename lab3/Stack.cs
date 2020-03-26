using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class Stack<T>
    {
        private T[] StackContents { get; set; }
        private int CountLast { get; set; }
        public Stack()
        {
            StackContents = new T[20];
        }
        public Stack(int size)
        {
            StackContents = new T[size];
        }
        public int Count => CountLast;
        public bool IsEmpty => CountLast == 0;

        public void Push(T element)
        {
            if (CountLast <= StackContents.Length)
                StackContents[CountLast++] = element;
            
            else
            {
                var stackContents = StackContents;
                Array.Resize(ref stackContents, CountLast + 5);
                StackContents = stackContents;
                StackContents[CountLast++] = element;
            }
        }
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack Empty");
            T element = StackContents[--CountLast];
            StackContents[CountLast] = default(T);
            return element;
        }
        public T Peek()
        {
            return StackContents[CountLast - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < StackContents.Length; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(this.StackContents[i], default(T)))
                    yield return this.StackContents[i];
                else
                    yield return default;
            }
        }
    }
}
