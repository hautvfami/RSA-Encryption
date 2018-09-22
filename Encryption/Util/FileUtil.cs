using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Util
{
    class FileUtil
    {
        public static string getDirectory(string filePath)
        {
            string dir = filePath.Substring(0, filePath.LastIndexOf('\\')) + "\\";
            return dir;
        }

        public static string getFileName(string filePath)
        {
            string fileName = filePath.Substring(filePath.LastIndexOf('\\'));
            return fileName;
        }

    }
}
