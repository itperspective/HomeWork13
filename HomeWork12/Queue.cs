using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13
{
    class Queue<T>
    {
        private int buffer = 10;
        DynamicArray<T> dynamicArray = new DynamicArray<T>();

        public event MyDelegateHendler EmptyBufferEvent;
        public event MyDelegateHendler FullBufferEvent;
        public event MyDelegateHendler RemoveElementEvent;
        public event MyDelegateHendler AddElementEvent;

        
        public void Enqueue(T enqueue)
        {
            if (dynamicArray.Top + 1 > buffer)
            {
                throw new FullBufferException();
            }
            else
            {
                dynamicArray.Add(enqueue);
                if (AddElementEvent != null)
                    AddElementEvent(this, new ArrayEventArgs("Event Queue add element: " + enqueue));

                if (dynamicArray.Top + 1 > buffer)
                {
                    if (FullBufferEvent != null)
                        FullBufferEvent(this, new ArrayEventArgs("Queue buffer is Full!!"));
                }
            }
           
        }

        
        public void Dequeue()
        {
            if (dynamicArray.Top == 0)
            {
                throw new EmptyBufferException();
            }
            else
            {

                T a = dynamicArray.Get(0);
                dynamicArray.Remove(0);
                if (RemoveElementEvent != null)
                    RemoveElementEvent(this, new ArrayEventArgs("Event Queue Remove Element" + a));
                if (dynamicArray.Top == 0)
                {
                    if (EmptyBufferEvent != null)
                        EmptyBufferEvent(this, new ArrayEventArgs("Event Queue buffer is empty"));
                }
            }
            
        }

        public void Print()
        {
            dynamicArray.Print();
        }


    }
}
