using MongoDB.Bson.Serialization.Attributes;
using OpheliaSuiteV2.Core.DataAccess.MongoDb;
using System.Collections.Generic;

namespace TransportRules
{
    public class Prototype: EntityBase
    {
        #region Builder
        /// <summary>
        /// Inicializa una instancia de la clase
        /// </summary>
        public Prototype()
        {
            Params = new List<Variable>();
            ReferenceFunction = new List<string>();
            ReferenceRule = new List<string>();
            ReferenceEntity = new List<string>();
            ReferenceRank = new List<string>();
            ReferenceAdapter = new List<string>();
            ReferencePrototype = new List<string>();
            ModifyAuthor = new List<Author>();
            ReferencesRules = new List<Rule>();
            ReferencesFunctions = new List<Function>();
            ReferencesEntities = new List<Entity>();
            ReferencesRanks = new List<Rank>();
            ReferencesAdapters = new List<Adapter>();
            ReferencesPrototypes = new List<Prototype>();
            Errors = new List<string>();
            PublishAuthor = new List<Author>();

        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de asignación del prototipo
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Descripción del prototipo
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Icono del prototipo
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Etiquetas asociadas al prototipo
        /// </summary>
        public List<string> Tags { get; set; }
        /// <summary>
        /// Tipo de prototipo
        /// </summary>
        public PrototypeType Type { get; set; }
        /// <summary>
        /// Definición de estado general del prototipo
        /// </summary>
        public State State { get; set; }
        /// <summary>
        /// Listado de variables utilizadas por el prototipo
        /// </summary>
        [BsonIgnore]
        public List<Variable> Params { get; set; }

        /// <summary>
        /// Listado de errores
        /// </summary>
        public List<string> Errors { get; set; }

        #region References
        /// <summary>
        /// Listado de funciones de usuario utilizados en el cuerpo de la Regla
        /// </summary>
        public List<string> ReferenceFunction { get; set; }
        /// <summary>
        /// Listado de reglas utilizados en el cuerpo de la Regla
        /// </summary>
        public List<string> ReferenceRule { get; set; }
        /// <summary>
        /// Listado de Entidades usadas en el cuerpo de la función
        /// </summary>
        public List<string> ReferenceEntity { get; set; }
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
        /// Listado de reglas referencia
        /// </summary>
        [BsonIgnore]
        public List<Rule> ReferencesRules { get; set; }

        /// <summary>
        /// Listado de funciones referencia
        /// </summary>
        [BsonIgnore]
        public List<Function> ReferencesFunctions { get; set; }

        /// <summary>
        /// Listado de funciones de referencia
        /// </summary>
        [BsonIgnore]
        public List<Entity> ReferencesEntities { get; set; }

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
        #endregion

        #region Authors
        /// <summary>
        /// Usuario y fecha de Creación del prototipo
        /// </summary>
        public Author Author { get; set; }
        /// <summary>
        /// Listado de autores de modificación del prototipo
        /// </summary>
        public List<Author> ModifyAuthor { get; set; }
        /// <summary>
        /// Listado de autores responsables de la publicación de la Regla
        /// </summary>
        public List<Author> PublishAuthor { get; set; }

        public Author LastAuthorModify { get; set; }
        #endregion
        #endregion
    }

    public enum PrototypeType
    {
        /// <summary>
        /// Validación
        /// </summary>
        Validation,
        /// <summary>
        /// Verificación
        /// </summary>
        Verification,
        /// <summary>
        /// Consolidación
        /// </summary>
        Consolidation
    }
}
