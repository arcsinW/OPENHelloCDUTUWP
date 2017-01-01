using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Service
{
    /// <summary>
    /// This handler enforces that the user is successfully authenticated.
    /// </summary>
    public interface IAuthEnforcementHandler
    {
        /// <summary>
        /// Requires a user to be signed in successfully.
        /// If not signed in already, the user will be prompted to do so.
        /// </summary>
        /// <exception cref="SignInRequiredException">When sign-in was not successful.</exception>
        Task CheckUserAuthentication();
    }
}
