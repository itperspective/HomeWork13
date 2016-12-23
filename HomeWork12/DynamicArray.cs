using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13
{
    
    public class DynamicArray<T> : Dynamic<T>
    {
        
        

        

        protected bool IndexOutOfRange(int index)
        {
            if (index > top)
            {
                return true;
            }

            else { return false; }

        }
        

        

        protected bool IsEmpty()
        {


            if (top == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool IsFull()
        {
            if (top == array.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void Growth()
        {
            capacity = capacity * 2;
            T[] array1 = new T[capacity];
            for (int i = 0; i < array.Length; i++)
            {
                array1[i] = array[i];
            }

            array = array1;


        }

        public T Get(int index)
        {
            if (top==0)
            {
                throw new EmptyBufferException();
            }
            else
            {
               
                return array[index];
            }


        }

        public void Add(T add)
        {
            if (top +1 > buffer) { throw new FullBufferException(); }

            else if (IsFull())
            {
                Growth();
                array[top] = add;
                top = top + 1;
            }
            else
            {
                array[top] = add;
                top = top + 1;
            }
        }

        public void Insert(T add, int index)
        {
            if (IndexOutOfRange(index))
            {
                throw new OutOfIndexException();
            }
        

            else if (top>buffer) { throw new FullBufferException(); }

            else
            {
                if (IsFull())
                {
                    Growth();
                    for (int i = top; i > index - 1; i--)
                    {
                        array[i + 1] = array[i];
                    }
                    array[index] = add;
                    top = top + 1;
                }


                else
                {

                    for (int i = top; i > index; i--)
                    {
                        array[i] = array[i - 1];
                    }

                    array[index] = add;
                    top = top + 1;

                }
            }

        }

       
        public void Remove(int index)
        {
            if (IndexOutOfRange(index))
            {
                throw new OutOfIndexException();
            }

            else
            {
                if (IsEmpty())
                {
                   throw new EmptyBufferException();
                }
                else
                {
                    //Console.WriteLine("Remove value [{0}] from stack", array[index]);
                    for (int i = index; i < array.Length - 1; i++)
                    {
                        array[i] = array[i + 1];
                    }
                    top = top - 1;
                    
                }
            }

        }
    

        public void Print()
        {
            Console.WriteLine("Your stack looks like this now:");
            Console.Write("[");
            for (int i = 0; i < top; i++)
            {
                Console.Write(" " + array[i] + " ");
            }
            Console.Write("]");
            Console.WriteLine("  SIZE :{0}, CAPACITY:{1}", top, array.Length);


        }
    }
}
