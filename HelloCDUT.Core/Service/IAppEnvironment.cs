using HelloCDUT.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Core.Service
{
    /// <summary>
    /// Defines the app environment
    /// </summary>
    public interface IAppEnvironment
    {
        /// <summary>
        /// Stores the current user that is logged in.
        /// </summary>
        User CurrentUser { get; set; }
    }
}
