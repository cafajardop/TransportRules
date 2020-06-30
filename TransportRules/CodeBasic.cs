using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportRules
{
    public class CodeBasic
    {
        public string Code { get; set; }
        public string SourceCode { get; set; }
        public List<Variable> Parameters { get; set; }
        public string Signature { get; set; }
        public Variable ReturnType { get; set; }
    }
}
