using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Exception.ExceptionBase
{
    public abstract class ManipulaeException : SystemException
    {
        protected ManipulaeException(string message) : base(message) { }

        public abstract int StatusCode { get; }

        public abstract List<string> GetErrors();
    }
}
