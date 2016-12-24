using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13
{
    public delegate void MyDelegateHendler(object sender, ArrayEventArgs e);
    class Stack<T>
    {
        private int buffer = 10;
        DynamicArray<T> dynamicArray = new DynamicArray<T>();

        public event MyDelegateHendler EmptyBufferEvent;
        public event MyDelegateHendler FullBufferEvent;
        public event MyDelegateHendler RemoveElementEvent;
        public event MyDelegateHendler AddElementEvent;



        public T Peek()
        {
            if (dynamicArray.Top==0)
            {
                throw new EmptyBufferException();
            }
            else
            return dynamicArray.Get(dynamicArray.Top - 1);
        }


        public T Pop()
        {

            if (dynamicArray.Top == 0)
            {
                throw new EmptyBufferException();
            }
            else
            {

                T a = dynamicArray.Get(dynamicArray.Top - 1);
                dynamicArray.Remove(dynamicArray.Top - 1);
                if (RemoveElementEvent != null)
                    RemoveElementEvent(this, new ArrayEventArgs("Event Stack Remove Element:" + a));
                if (dynamicArray.Top == 0)
                {
                    if (EmptyBufferEvent != null)
                        EmptyBufferEvent(this, new ArrayEventArgs("Event buffer is empty"));

                }
                return a;
            }


        }
            
        
        public void Push(T push)
        {
            if (dynamicArray.Top + 1 > buffer)
            {
                throw new FullBufferException();
            }
            else
            {
                dynamicArray.Add(push);
                if (AddElementEvent != null)
                    AddElementEvent(this, new ArrayEventArgs("Event Push Element: " + push));
                if (dynamicArray.Top + 1 > buffer)
                {
                    if (FullBufferEvent != null)
                        FullBufferEvent(this, new ArrayEventArgs("Event buffer is full!!!"));
                }
            }
          
        }

        public void Print()
        {
            dynamicArray.Print();
        }

    }
}
