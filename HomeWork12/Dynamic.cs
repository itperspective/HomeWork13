using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13
{
    public abstract class Dynamic<T>
    {

        protected T[] array;
        protected int top;
        protected int count;
        protected int head;
        protected int tail;
        protected int capacity = 1;
        protected int size;
        protected int buffer;
        

        public int Top
        {
            get
            {
                return top;
            }
            set
            {
                value = top;
            }
        }

        public Dynamic()
        {
            this.array = new T[capacity];
            this.top = 0;
            this.count = 0;
            this.head = 0;
            this.tail = 0;
            this.size = capacity;
            this.buffer = 10;
            

        }
    }
}
