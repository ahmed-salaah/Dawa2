using System;

namespace Exceptions
{
    public class AttachmentSizeException : Exception
    {
        public AttachmentSizeException(string message, double size,Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
