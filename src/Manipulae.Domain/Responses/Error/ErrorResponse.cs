using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Domain.Responses.Error
{
    public class ErrorResponse
    {
        public List<string> ErrorMessage { get; set; }
        public ErrorResponse(string errorMessage)
        {
            ErrorMessage = new List<string> { errorMessage };
        }

        public ErrorResponse(List<string> errorMessage)
        {
            ErrorMessage = errorMessage ?? new List<string>();
        }
    }
}
