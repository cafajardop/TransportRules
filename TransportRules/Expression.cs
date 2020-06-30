using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportRules
{
    public class ExpressionData
    {
        public ExpressionData()
        {
            Variables = new List<Variable>();
            RelatedRules = new List<string>();
            RelatedFunction = new List<string>();
        }

        public ExpressionType Type { get; set; }

        public string Expression { get; set; }

        public Variable ReturnVariable { get; set; }

        public List<Variable> Variables { get; set; }

        public List<string> RelatedEntity { get; set; }

        public List<string> RelatedFunction { get; set; }

        public List<string> RelatedRules { get; set; }

        public Function Function { get; set; }
    }
}
