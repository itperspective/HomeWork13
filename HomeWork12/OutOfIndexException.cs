using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13
{
    class OutOfIndexException:Exception
    {
        public OutOfIndexException() : base("Index is out of range")
        {

        }
    }
}
