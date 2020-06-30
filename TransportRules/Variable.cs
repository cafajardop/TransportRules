#region Imports
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
#endregion

namespace TransportRules
{
    /// <summary>
    /// Encapsula las propiedades de las variables
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// Inicializa una instancia de la clase
        /// </summary>
        public Variable()
        {
            Attributes = new List<Attributes>();
        }
        #region Properties
        /// <summary>
        /// Código de indentificación de la variable
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Descripción de uso de la variable
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Tipo de dato de la variable
        /// </summary>
        public DataTypes Type { get; set; }
        /// <summary>
        /// Define si la variable admite valores nulos
        /// </summary>
        public bool IsNullable { get; set; }
        /// <summary>
        /// Define si la variable es un arreglo/listado
        /// </summary>
        public bool IsList { get; set; }
        /// <summary>
        /// Define si la variable maneja un valor por defecto
        /// </summary>
        public string DefaultValue { get; set; }
        /// <summary>
        /// Entidad selecionada cuando el tipo de dato es Entidad
        /// </summary>
        public string EntityCode { get; set; }
        /// <summary>
        /// Valor que se le da a la variable cuando se crea el código del control de dummies
        /// </summary>
        public string ValueCode { get; set; }
        /// <summary>
        /// Código generado para el control de dummies
        /// </summary>
        public CodeBasic CodeBasic { get; set; }

        /// <summary>
        /// Valor a asignar a la variable
        /// </summary>
        [BsonIgnore]
        public string Value { get; set; }

        /// <summary>
        /// Diferencia si el valor es constante o variable desde el control para dummies
        /// </summary>
        public bool TypeValue { get; set; }

        /// <summary>
        /// Atributos asignados a la variable
        /// </summary>
        public List<Attributes> Attributes { get; set; }
        #endregion
    }
}
