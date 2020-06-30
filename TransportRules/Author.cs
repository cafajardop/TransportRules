#region Imports
using System;
#endregion

namespace TransportRules
{
    /// <summary>
    /// Define los Autores
    /// </summary>
    public class Author
    {
        #region Properties
        /// <summary>
        /// Usuario autor de una acción
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Fecha de realización de la acción
        /// </summary>
        public DateTime Date { get; set; } 
        #endregion
    }
}
