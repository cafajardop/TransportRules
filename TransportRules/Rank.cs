using OpheliaSuiteV2.Core.DataAccess.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TransportRules
{
    /// <summary>
    /// Encapsula los rangos 
    /// </summary>
    public class Rank : EntityBase
    {
        #region Builder
        /// <summary>
        /// Inicializa una instancia de la clase
        /// </summary>
        public Rank()
        {
            Detail = new List<RankDetail>();
            ModifyAuthor = new List<Author>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de asignación del rango
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Descripción del rango
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Icono del rango
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Etiquetas asociadas al rango
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Incluye Límite Inferior
        /// </summary>
        public bool LowerLimit { get; set; }

        /// <summary>
        /// Incluye Límite Superior
        /// </summary>
        public bool UpperLimit { get; set; }

        /// <summary>
        /// Detalle de rango
        /// </summary>
        public List<RankDetail> Detail { get; set; }

        #region Authors
        /// <summary>
        /// Usuario y fecha de Creación del rango
        /// </summary>
        public Author Author { get; set; }
        /// <summary>
        /// Listado de autores de modificación del rango
        /// </summary>
        public List<Author> ModifyAuthor { get; set; }

        public Author LastAuthorModify { get; set; }
        #endregion
        #endregion
    }
}
