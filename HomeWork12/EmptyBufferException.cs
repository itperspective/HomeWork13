using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13
{
    class EmptyBufferException:Exception
    {
        public EmptyBufferException() : base("Buffer is Empty!!!")
        {

        }
    }
}
