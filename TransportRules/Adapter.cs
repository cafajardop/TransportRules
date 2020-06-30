using OpheliaSuiteV2.Core.DataAccess.MongoDb;
using System.Collections.Generic;
using System.Net.Http;

namespace TransportRules
{
    /// <summary>
    /// Encapsula los adaptadores 
    /// </summary>
    public class Adapter : EntityBase
    {
        #region Builder
        /// <summary>
        /// Inicializa una instancia de la clase
        /// </summary>
        public Adapter()
        {
            Actions = new List<Action>();
            ModifyAuthor = new List<Author>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de asignación del adaptador
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Descripción del adaptador
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Icono del adaptador
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Etiquetas asociadas al adaptador
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Servidor del adaptador
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Puerto
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Url del adaptador
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Listado de acciones del adaptador
        /// </summary>
        public List<Action> Actions { get; set; }

        #region Authors
        /// <summary>
        /// Usuario y fecha de Creación de la Regla
        /// </summary>
        public Author Author { get; set; }
        /// <summary>
        /// Listado de autores de modificación de la Regla
        /// </summary>
        public List<Author> ModifyAuthor { get; set; }

        public Author LastAuthorModify { get; set; }
        #endregion
        #endregion

    }

    public class Action
    {
        #region Builder
        /// <summary>
        /// Inicializa una instancia de la clase
        /// </summary>
        public Action()
        {
            Params = new List<Variable>();
        }
        #endregion
        /// <summary>
        /// Código de indentificación de la acción
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Descripción de la acción
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Método del adaptador
        /// </summary>
        public HttpMethod HttpMethod { get; set; }
        /// <summary>
        /// Acción a ejecutar
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// Variable de retorno del adaptador
        /// </summary>
        public Variable ReturnType { get; set; }
        /// <summary>
        /// Listado de parámetros necesarios para la ejecución del adaptador
        /// </summary>
        public List<Variable> Params { get; set; }
    }
}
