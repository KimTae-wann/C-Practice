using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Generic
{
    class Stack<T> //where T : struct
    {
        private T[] data;
        private int top;
        public Stack (int size)
        {
            data = new T[size];
            top = -1;
        }

        public void Push(T n)
        {
            // TODO: overflow check
            data[++top] = n;
        }

        public T Pop()
        {
            // TODO: underflow check
            return data[top--];
        }
    }
}
