using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using OpheliaSuiteV2.Core.DataAccess.MongoDb;

namespace TransportRules
{
    public class Rule : EntityBase
    {
        #region Builder
        public Rule()
        {
            Variables = new List<Variable>();
            ValidValuesVariables = new List<ValidValuesVariable>();
            Conditions = new List<ConditionAction>();

            ReferenceFunction = new List<string>();
            ReferenceSysFunction = new List<string>();
            ReferenceRule = new List<string>();
            ReferenceEntities = new List<string>();
            ReferenceRank = new List<string>();
            ReferenceAdapter = new List<string>();
            ReferencePrototype = new List<string>();
            Tags = new List<string>();

            Errors = new List<string>();

            ModifyAuthor = new List<Author>();
            PublishAuthor = new List<Author>();

            References = new List<Rule>();
            ReferencesFunt = new List<Function>();
            ReferencesEntities = new List<Entity>();
            ReferencesRanks = new List<Rank>();
            ReferencesAdapters = new List<Adapter>();
            ReferencesPrototypes = new List<Prototype>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de asignación de la Regla
        /// </summary>
        public string Code
        {
            get; set;
        }
        /// <summary>
        /// Descripción de la Regla
        /// </summary>
        public string Description
        {
            get; set;
        }
        /// <summary>
        /// Código fuente de ejecución de la Regla
        /// </summary>
        public string SourceCode
        {
            get; set;
        }
        /// <summary>
        /// Variable de retorno de la Regla
        /// </summary>
        public Variable ReturnType
        {
            get; set;
        }
        /// <summary>
        /// Listado de parámetros necesarios para la ejecución de la Regla
        /// </summary>
        public List<Variable> Params
        {
            get; set;
        }
        /// <summary>
        /// Definción de tipos de Regla
        /// </summary>
        public RuleType Type
        {
            get; set;
        }

        public RuleMethod RuleType
        {
            get; set;
        }
        /// <summary>
        /// Definición de estado general de la Regla
        /// </summary>
        public State State
        {
            get; set;
        }
        /// <summary>
        /// ícono del front
        /// </summary>
        public string Icon
        {
            get; set;
        }
        /// <summary>
        /// Etiquetas asociadas a la Regla
        /// </summary>
        public List<string> Tags
        {
            get; set;
        }

        /// <summary>
        /// Listado de variables utilizadas en la regla
        /// </summary>
        public List<Variable> Variables
        {
            get; set;
        }
        /// <summary>
        /// Listado de Valores posibles por variable
        /// </summary>
        public List<ValidValuesVariable> ValidValuesVariables
        {
            get; set;
        }
        /// <summary>
        /// Listado de condiciones posibles por regla
        /// </summary>
        public List<ConditionAction> Conditions
        {
            get; set;
        }

        /// <summary>
        /// Define el valor por defecto cuando es Satisfactorio
        /// </summary>
        public ConditionAction DefaultSuccessful
        {
            get; set;
        }
        /// <summary>
        /// Define el valor por defecto cuando no es Satisfactorio
        /// </summary>
        public ConditionAction DefaultUnsuccessful
        {
            get; set;
        }

        /// <summary>
        /// Listado de errores
        /// </summary>
        public List<string> Errors
        {
            get; set;
        }

        #region References
        /// <summary>
        /// Listado de funciones de usuario utilizados en el cuerpo de la Regla
        /// </summary>
        public List<string> ReferenceFunction
        {
            get; set;
        }
        /// <summary>
        /// Listado de reglas utilizados en el cuerpo de la Regla
        /// </summary>
        public List<string> ReferenceRule
        {
            get; set;
        }
        /// <summary>
        /// Listado de funciones de sistema utilizados en el cuerpo de la Regla
        /// </summary>
        public List<string> ReferenceSysFunction
        {
            get; set;
        }
        /// <summary>
        /// Listado de Entidades usadas en el cuerpo de la función
        /// </summary>
        public List<string> ReferenceEntities
        {
            get; set;
        }

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

        [BSonIgnore]
        public List<Rule> References
        {
            get; set;
        }
        [BSonIgnore]
        public List<Function> ReferencesFunt
        {
            get; set;
        }
        /// <summary>
        /// Listado de funciones de referencia
        /// </summary>
        [BSonIgnore]
        public List<Entity> ReferencesEntities
        {
            get; set;
        }

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
        #endregion
       

        #region Authors
        /// <summary>
        /// Usuario y fecha de Creación de la Regla
        /// </summary>
        public Author CreateAuthor
        {
            get; set;
        }
        /// <summary>
        /// Listado de autores de modificación de la Regla
        /// </summary>
        public List<Author> ModifyAuthor
        {
            get; set;
        }
        /// <summary>
        /// Listado de autores responsables de la publicación de la Regla
        /// </summary>
        public List<Author> PublishAuthor
        {
            get; set;
        }
        #endregion

    }

    public enum RuleMethod
    {
        /// <summary>
        /// Arbol de desición
        /// </summary>
        DecisionTree,
        /// <summary>
        /// Tabla de desición
        /// </summary>
        DecisionTable
    }
}
