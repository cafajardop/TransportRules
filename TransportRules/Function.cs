#region Imports
using MongoDB.Bson.Serialization.Attributes;
using OpheliaSuiteV2.Core.DataAccess.MongoDb;
using System.Collections.Generic;
#endregion

namespace TransportRules
{
    /// <summary>
    /// Encapsula las propiedades que definen una función
    /// </summary>
    public class Function : EntityBase
    {
        #region Builder
        public Function()
        {
            Params = new List<Variable>();
            Tags = new List<string>();
            ReferenceFunction = new List<string>();
            ReferenceRule = new List<string>();
            ReferenceSysFunction = new List<string>();
            ReferenceEntities = new List<string>();
            ReferenceRank = new List<string>();
            ReferenceAdapter = new List<string>();
            ReferencePrototype = new List<string>();
            ModifyAuthor = new List<Author>();
            PublishAuthor = new List<Author>();

            Errors = new List<string>();
            References = new List<Function>();
            ReferencesRules = new List<Rule>();
            ReferencesEntity = new List<Entity>();
            ReferencesRanks = new List<Rank>();
            ReferencesAdapters = new List<Adapter>();
            ReferencesPrototypes = new List<Prototype>();
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Código de asignación de la Función
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Descripción de la función
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Código fuente de ejecución de la función
        /// </summary>
        public string SourceCode { get; set; }
        /// <summary>
        /// Variable de retorno de la función
        /// </summary>
        public Variable ReturnType { get; set; }
        /// <summary>
        /// Listado de parámetros necesarios para la ejecución de la función
        /// </summary>
        public List<Variable> Params { get; set; }
        /// <summary>
        /// Definción de tipos de función
        /// </summary>
        public FunctionType Type { get; set; }
        /// <summary>
        /// Definición de estado general de la función
        /// </summary>
        public State State { get; set; }
        /// <summary>
        /// ícono del front
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Etiquetas asociadas a la función
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Listado de reglas utilizados en el cuerpo de la Regla
        /// </summary>
        public List<string> ReferenceRule { get; set; }

        /// <summary>
        /// Listado de funciones de usuario utilizados en el cuerpo de la función
        /// </summary>
        public List<string> ReferenceFunction { get; set; }
        /// <summary>
        /// Listado de funciones de sistema utilizados en el cuerpo de la función
        /// </summary>
        public List<string> ReferenceSysFunction { get; set; }
        /// <summary>
        /// Listado de Entidades usadas en el cuerpo de la función
        /// </summary>
        public List<string> ReferenceEntities { get; set; }

        /// <summary>
        /// Listado de rangos usados en el cuerpo de la función
        /// o en las variables calculadas
        /// </summary>
        public List<string> ReferenceRank { get; set; }

        /// <summary>
        /// Listado de adaptadores usados en el cuerpo de la función
        /// o en las variables calculadas
        /// </summary>
        public List<string> ReferenceAdapter { get; set; }
        /// <summary>
        /// Listado de prototipos usados en el cuerpo de la función
        /// o en las variables calculadas
        /// </summary>
        public List<string> ReferencePrototype { get; set; }

        /// <summary>
        /// Listado de errores
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Listado de funciones referencia
        /// </summary>
        [BSonIgnore]
        public List<Function> References { get; set; }

        /// <summary>
        /// Listado de reglas de referencia
        /// </summary>
        [BSonIgnore]
        public List<Rule> ReferencesRules { get; set; }

        /// <summary>
        /// Listado de funciones de referencia
        /// </summary>
        [BSonIgnore]
        public List<Entity> ReferencesEntity { get; set; }

        /// <summary>
        /// Listado de rangos de referencia
        /// </summary>
        [BsonIgnore]
        public List<Rank> ReferencesRanks { get; set; }

        /// <summary>
        /// Listado de adaptadores de referencia
        /// </summary>
        [BsonIgnore]
        public List<Adapter> ReferencesAdapters { get; set; }

        /// <summary>
        /// Listado de prototipos de referencia
        /// </summary>
        [BsonIgnore]
        public List<Prototype> ReferencesPrototypes { get; set; }

        /// <summary>
        /// Usuario y fecha de Creación de la función
        /// </summary>
        public Author CreateAuthor { get; set; }
        /// <summary>
        /// Listado de autores de modificación de la función
        /// </summary>
        public List<Author> ModifyAuthor { get; set; }
        /// <summary>
        /// Listado de autores responsables de la publicación de la función
        /// </summary>
        public List<Author> PublishAuthor { get; set; }
        #endregion
    }
}
