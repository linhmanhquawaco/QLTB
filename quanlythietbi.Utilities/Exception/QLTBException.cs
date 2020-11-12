using System;
using System.Collections.Generic;
using System.Text;

namespace quanlythietbi.Utilities.Exceptions
{
    public class QLTBException : Exception
    {
        public QLTBException()
        {
        }

        public QLTBException(string message)
            : base(message)
        {
        }

        public QLTBException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}