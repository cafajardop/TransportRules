using System;
using System.Collections.Generic;
using System.Text;

namespace TransportRules
{
    public class RankDetail
    {
        /// <summary>
        /// Id detalle de rango
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Valor inicial
        /// </summary>
        public double InitValue { get; set; }

        /// <summary>
        /// Valor Final
        /// </summary>
        public double EndValue { get; set; }

        /// <summary>
        /// Valor Entregado
        /// </summary>
        public double DeliveredValue { get; set; }

    }
}
