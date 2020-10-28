using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Utility
{
    public class EmailSettings
    {
        public string ApiKey { get; set; }
        public string ApiBaseUri { get; set; }
        public string RequestUri { get; set; }
        public string From { get; set; }
    }
}
