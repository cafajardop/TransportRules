using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportRules
{
    public class DummyControl
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public Variable ReturnType { get; set; }
        public List<Variable> Parameters { get; set; }
        public BRMTypes Type { get; set; }
        public List<string> Tags { get; set; } 
        public string Signature { get; set; }
        public string SourceCode { get; set; }
    }
}
