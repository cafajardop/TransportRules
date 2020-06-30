using OpheliaSuiteV2.Core.DataAccess.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportRules
{
    /// <summary>
    /// Encapsula las propiedades que definen un operador
    /// </summary>
    public class Operator : EntityBase
    {
        /// <summary>
        /// Código
        /// Código
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Códificación generada
        /// </summary>
        public string Codification { get; set; }
        /// <summary>
        /// Combinaciones con otros operadores disponibles
        /// </summary>
        public List<string> Combination { get; set; }
        /// <summary>
        /// Visible
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// Tipos de operador
        /// </summary>
        public OperatorTypes Type { get; set; }
        /// <summary>
        /// Tipos de datos permitidos
        /// </summary>
        public List<DataTypes> DataTypes { get; set; }
        /// <summary>
        /// Define si el operador permite listados
        /// </summary>
        public bool AllowList { get; set; }
        /// <summary>
        /// Define si el operador permite variables nulas
        /// </summary>
        public bool AllowNulleable { get; set; }
        /// <summary>
        /// Define si es requerido
        /// </summary>
        public bool Required { get; set; }
    }
}
