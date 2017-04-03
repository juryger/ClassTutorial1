using System;

namespace Version_1_C.Exceptions
{
    public class FileStoreAccessException : Exception
    {
        public FileStoreAccessException(string message)
            : base(message)
        {
        }

        public FileStoreAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
