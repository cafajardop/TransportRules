using System;
using System.Collections.Generic;
using System.Text;

namespace TransportRules {
    public class FunctionTransportPackage {
        public List<Entity> Entities {
            get; set;
        }
        public List<Function> Functions {
            get; set;
        }
        public List<Rule> Rules {
            get; set;
        }
        public Function MainFunction {
            get; set;
        }
    }
}
