using OpheliaSuiteV2.Core.DataAccess.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportRules
{
    /// <summary>
    /// Propiedades de autogenerado para version 2
    /// </summary>
    public class Autogenerate : EntityBase
    {
        #region Properties
        /// <summary>
        /// Codigo de asignación de autogenerado
        /// </summary>
        public string Code;
        /// <summary>
        /// Nombre o descripcion de autogenerado
        /// </summary>
        public string Description;
        /// <summary>
        /// Patron asignado al autogenerado
        /// </summary>
        public string Pattern;
        /// <summary>
        /// valor consecutivo de autogenerado
        /// </summary>
        public int NextValue;
        #endregion
    }
}
