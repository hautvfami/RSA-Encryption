using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Data
{
    static class Dict
    {
        public const string SIGN_SUCCESSFUL = "Sign successful";
        public const string VERIFY_SUCCESSFUL = "Verify successful";

        public const string SIGN_FAILED = "Sign failed";
        public const string VERIFY_FAILED = "Verify failed";

        public const string FILE_NOT_FOUND = "File not found";
        public const string ENCRYPT_SUCCESSFUL = "Encrypt successful";
        public const string DECRYPT_SUCCESSFUL = "Decrypt successful";

        public const string ENCRYPTING = "Encrypting...";
        public const string DECRYPTING = "Decrypting...";

        public const string SELECT_KEY_FILE = "Select a Key File";
        public const string SELECT_TARGET_FILE = "Select a Target File";
    }
}
