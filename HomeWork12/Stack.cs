using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13
{
    public delegate void ElementDelegateHendler(object sender, ArrayEventArgs e);
    class Stack<T>
    {
        private int buffer = 10;
        DynamicArray<T> dynamicArray = new DynamicArray<T>();

        public event ElementDelegateHendler ElementStackEvent;



        public T Peek()
        {

            return dynamicArray.Get(dynamicArray.Top - 1);
        }


        public T Pop()
        {


            try
            {

                T a = dynamicArray.Get(dynamicArray.Top - 1);
                dynamicArray.Remove(dynamicArray.Top - 1);
                if (ElementStackEvent != null)
                    ElementStackEvent(this, new ArrayEventArgs("Event Stack Remove Element:" + a));
                if (dynamicArray.Top == 0)
                {
                    if (ElementStackEvent != null)
                        ElementStackEvent(this, new ArrayEventArgs("Event buffer is empty"));

                }
                return a;


            }

            catch (EmptyBufferException ex)
            {
                Console.WriteLine(ex);
                return default(T);
            }

            catch (OutOfIndexException ex)
            {
                Console.WriteLine(ex);
                return default(T);
            }
        }
            
        
  


        public void Push(T push)
        {
            try
            {
                dynamicArray.Add(push);
                if (ElementStackEvent != null)
                    ElementStackEvent(this, new ArrayEventArgs("Event Push Element: " + push));
                if (dynamicArray.Top + 1 > buffer)
                {
                    if (ElementStackEvent != null)
                        ElementStackEvent(this, new ArrayEventArgs("Event buffer is full!!!"));
                }
            }

            catch (FullBufferException ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void Print()
        {
            dynamicArray.Print();
        }

    }
}
