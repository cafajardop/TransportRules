using System;
using System.Collections.Generic;
using System.Text;

namespace TransportRules
{
    public class Attributes
    {
        /// <summary>
        /// Tipo de atributo
        /// </summary>
        public AttributeType Type { get; set; }
        /// <summary>
        /// Valor del atributo
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Mensaje de atributo
        /// </summary>
        public string Message { get; set; }
    }

    public enum AttributeType
    {
        /// <summary>
        /// Longitud
        /// </summary>
        Length,
        /// <summary>
        /// Expresión regular
        /// </summary>
        Regex,
        /// <summary>
        /// Valor máximo
        /// </summary>
        MaxValue,
        /// <summary>
        /// Valor mínimo
        /// </summary>
        MinValue,
        /// <summary>
        /// Cantidad de decimales
        /// </summary>
        DecimalCount,
        /// <summary>
        /// Función
        /// </summary>
        Function
    }
}
