using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Models
{
    public class DefaultConfig : Config
    {
        public DefaultConfig() : base("1.0.0.0", 6, 16)
        {
        }
    }
}
