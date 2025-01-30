using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Exception.ExceptionBase
{
    public class BadRequestException : ManipulaeException
    {
        public BadRequestException(string message) : base(message) { }

        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public override List<string> GetErrors()
        {
            return new List<string>() { Message };
        }
    }
}
