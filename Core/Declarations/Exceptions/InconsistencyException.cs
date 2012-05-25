using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace Netron.NetronLight
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors")]
    [Serializable()]
    public sealed class InconsistencyException : Exception
    {
        public InconsistencyException(string message) : base(message){ }

        public InconsistencyException() : base(){}
        public InconsistencyException(string message, Exception e) :  base(message, e){}
    }
}
