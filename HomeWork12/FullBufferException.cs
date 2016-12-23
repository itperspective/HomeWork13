using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13
{
    class FullBufferException:Exception
    {
        public FullBufferException(): base("Buffer is full! Can not add new element!")
        {

        }
    }
}
