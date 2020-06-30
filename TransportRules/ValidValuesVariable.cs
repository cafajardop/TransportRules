using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportRules
{
    /// <summary>
    /// Asocia los valores válidos que puede asignar una variable
    /// </summary>
    public class ValidValuesVariable
    {
        /// <summary>
        /// Código de la variable
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Mensaje si no cumple ningun valor válido
        /// </summary>
        public string NonValidMessage { get; set; }
        /// <summary>
        /// Listado de valores posibles válidos de la variable
        /// </summary>
        public List<string> Values { get; set; }

        [BsonIgnore]
        public Variable Variable { get; set; }
    } 
}
