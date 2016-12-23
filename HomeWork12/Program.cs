using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13
{
    class Program
    {
        private static void ShowMessage(object sender, ArrayEventArgs e)
        {
            Console.WriteLine(e.Message);
           
        }
        static void Main(string[] args)
        {
            DynamicArray<int> dynamicArray = new DynamicArray<int>();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();


            stack.ElementStackEvent += ShowMessage;
            queue.ElementQueueEvent += ShowMessage;

            int input=0;
            int value;

            while (input != 8)
            {
                Console.WriteLine("Please Enter: 1-Push; 2-Pop; 3-Peek; 8-Exit");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                }


                switch (input)
                {
                    case 1:
                        Console.WriteLine("Please Enter int to push:");
                        try
                        {
                            value = Convert.ToInt32(Console.ReadLine());
                            stack.Push(value);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        stack.Print();
                        break;
                    case 2:
                        stack.Pop();
                        stack.Print();
                        break;
                    case 3:
                        stack.Peek();
                        stack.Print();
                        break;
                    case 8:
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
