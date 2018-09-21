using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Util
{
    class BufferDebug
    {
        public static void show(string TAG, byte[] buffer)
        {
            Console.Write("\n"+TAG+":\t");
            for (int i = 0; i < buffer.Length; i++)
            {
                Console.Write("|" + (int)buffer[i]);
            }
        }
    }
}
