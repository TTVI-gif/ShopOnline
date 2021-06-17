using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Utilities.Exceptions
{
    public class EshopSolutonException : Exception
    {
        public EshopSolutonException()
        {
        }

        public EshopSolutonException(string message)
            : base(message)
        {
        }

        public EshopSolutonException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

