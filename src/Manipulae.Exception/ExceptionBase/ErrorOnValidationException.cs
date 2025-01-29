using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Exception.ExceptionBase
{
    public class ErrorOnValidationException : ManipulaeException
    {
        private readonly List<string> _errors;

        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }

        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public override List<string> GetErrors()
        {
            return _errors;
        }
    }
}
