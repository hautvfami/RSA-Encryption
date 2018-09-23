using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public static class Consts
    {
        /// <summary>
        /// Key size of Prime Number
        /// </summary>
        public const int KEY_SIZE_16 = 16;
        public const int KEY_SIZE_32 = 32;
        public const int KEY_SIZE_64 = 64;
        public const int KEY_SIZE_128 = 128;
        public const int KEY_SIZE_256 = 256;
        public const int KEY_SIZE_512 = 512;
        public const int KEY_SIZE_1024 = 1024;
        public const int KEY_SIZE_2048 = 2048;

        public const string EMPTY = "";
        public const string DIALOG_KEY_FILTER = "*Key File | *.keystorage";
        public const string ENCRYPT_FILE_NAME = ".encrypt";

    }
}
