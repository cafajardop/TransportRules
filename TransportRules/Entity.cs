using OpheliaSuiteV2.Core.DataAccess.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TransportRules
{
    /// <summary>
    /// Encapsula las entidades 
    /// </summary>
    public class Entity : EntityBase
    {
        #region Builder
        /// <summary>
        /// Inicializa una instancia de la clase
        /// </summary>
        public Entity()
        {
            Properties = new List<Variable>();
            ReferenceFunction = new List<string>();
            ReferenceSysFunction = new List<string>();
            ReferencesEntities = new List<Entity>();
            References = new List<Function>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Código fuente
        /// </summary>
        public string SourceCode { get; set; }
        /// <summary>
        /// Listado de propiedades
        /// </summary>
        public List<Variable> Properties { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public string Builder { get; set; }
        public List<string> Tags { get; set; }
        public bool WithErrors { get; set; }
        public string Icon { get; set; }

        public bool ExtrictValidation { get; set; }

        public List<string> ReferenceEntities { get; set; }

        /// <summary>
        /// Listado de funciones de usuario utilizados en el cuerpo de la función
        /// </summary>
        public List<string> ReferenceFunction { get; set; }
        /// <summary>
        /// Listado de funciones de sistema utilizados en el cuerpo de la función
        /// </summary>
        public List<string> ReferenceSysFunction { get; set; }
        /// <summary>
        /// Listado de funciones referencia
        /// </summary>
        [BSonIgnore]
        public List<Function> References { get; set; }

        #region Authors
        /// <summary>
        /// Usuario y fecha de Creación de la Regla
        /// </summary>
        public Author CreateAuthor { get; set; }
        /// <summary>
        /// Listado de autores de modificación de la Regla
        /// </summary>
        public List<Author> ModifyAuthor { get; set; }
        #endregion

        [BSonIgnore]
        public List<Entity> ReferencesEntities { get; set; }
        public Author LastAuthorModify { get; set; }
        #endregion

        #region Methods
        public string GetExpression()
        {
            List<string> exp = new List<string>() { Builder, SourceCode };
            exp.AddRange(Properties.Select(p => $"public {p.Type} {p.Code} {{get; set;}}"));

            return string.Join(Environment.NewLine, exp);
        }
        #endregion
    }
}
