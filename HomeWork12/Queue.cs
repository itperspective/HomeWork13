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
            try
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
            catch (FullBufferException ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        
        public void Dequeue()
        {
            try
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
            catch (EmptyBufferException ex)
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
