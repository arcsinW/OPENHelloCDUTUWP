using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Services
{
    /// <summary>
    /// The argument that is passed as part of the result of
    /// <see cref="TaskCompletionSource{TResult}"/> which indicates
    /// the source of completion..
    /// </summary>
    public enum SignInCompletionSource
    {
        UserChanged,
        DialogClosed
    }
}
