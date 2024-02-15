using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Common
{
    public class AppSettings
    {
        public string BaseWebUri { get; set; } = string.Empty;

        public List<WebApi> APIs = new();  
    }
}
