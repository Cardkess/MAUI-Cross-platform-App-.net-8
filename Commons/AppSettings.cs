using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Commons
{
    public class AppSettings
    {
        public string BaseWebUri { get; set; } = string.Empty;

        public List<WebApi> APIs = new();  
    }
}
