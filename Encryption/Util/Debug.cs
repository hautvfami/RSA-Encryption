using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Util
{
    /// <summary>
    /// When you remove this class, all of Log in this project will be highlight and available to remove.
    /// That's easy to control Log of Secure data.
    /// </summary>
    class Debug
    {
        public static void showBuffer(string TAG, byte[] buffer)
        {
            Console.Write("\n"+TAG+":\t");
            for (int i = 0; i < buffer.Length; i++)
            {
                Console.Write("|" + (int)buffer[i]);
            }
        }

        public static void showTime(string TAG)
        {
            Console.WriteLine("\n"+TAG+":\t"+DateTime.Now.ToString());
        }

        public static void showLog(string TAG, object Log)
        {
            Console.WriteLine("\n" + TAG + ":\t" + Log);
        }
    }
}
