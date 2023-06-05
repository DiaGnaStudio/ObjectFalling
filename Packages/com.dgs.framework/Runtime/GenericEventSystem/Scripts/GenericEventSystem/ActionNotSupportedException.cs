using System;
using System.Runtime.Serialization;

namespace DiaGna.Framework.GenericEventSystem
{
    public class ActionNotSupportedException : Exception
    {
        public ActionNotSupportedException() : base("BaseAction type is not supported to be added to or removed from the BaseEvent type")
        {
        }

        public ActionNotSupportedException(string message) : base(message)
        {
        }

        public ActionNotSupportedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ActionNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
