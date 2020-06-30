namespace TransportRules
{
    /// <summary>
    /// Define las condiciones y acciones definidas para una regla
    /// </summary>
    public class ConditionAction
    {
        #region Properties
        /// <summary>
        /// Define la condición valida de una regla
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// Define el tipo de acción que tendrá la condición
        /// </summary>
        public bool IsSuccessful { get; set; }
        /// <summary>
        /// Define la acción que tendrá la condición
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// Mensaje a mostrar de la condición
        /// </summary>
        public string Message { get; set; } 
        #endregion
    }
}
