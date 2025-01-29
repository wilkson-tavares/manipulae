using System.Net;

namespace Manipulae.Exception.ExceptionBase
{
    public class InvalidLoginException : ManipulaeException
    {
        public InvalidLoginException() : base("Invalid Email or Password") { }

        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
