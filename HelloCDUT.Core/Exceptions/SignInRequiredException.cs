using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Core.Exceptions
{
    public class SignInRequiredException : Exception
    {
        public SignInRequiredException()
        {

        }

        public SignInRequiredException(string message) : base(message)
        {
        }

        public SignInRequiredException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
