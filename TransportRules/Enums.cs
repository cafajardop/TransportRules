namespace TransportRules
{
    public enum BRMTypes
    {
        Function,
        Rule,
        Entity
    }

    /// <summary>
    /// Enumeración que define los tipos de datos disponibles
    /// soportados por el motor de reglas
    /// </summary>
    public enum DataTypes
    {
        /// <summary>
        /// Tipo de dato Texto
        /// </summary>
        String,
        /// <summary>
        /// Tipo de dato double (numérico)
        /// </summary>
        Double,
        /// <summary>
        /// Tipo de dato Long (entero)
        /// </summary>
        Long,
        /// <summary>
        /// Tipo de dato booleano
        /// </summary>
        Bool,
        /// <summary>
        /// Tipo de dato objeto dinámico
        /// </summary>
        Object,
        /// <summary>
        /// Tipo de dato Fecha (con horas)
        /// </summary>
        Date,
        /// <summary>
        /// Tipo de dato Entidad
        /// </summary>
        Entity,
        /// <summary>
        /// Tipo dato Dinámico
        /// </summary>
        Dynamic
    }

    /// <summary>
    /// Enumeración que define los tipos de funciones soportadas
    /// </summary>
    public enum FunctionType
    {
        /// <summary>
        /// funciones creadas por usuarios de la aplicación
        /// </summary>
        UserFunction,
        /// <summary>
        /// funciones de tipo plantilla
        /// </summary>
        Template,
        /// <summary>
        /// funciones de sistema
        /// </summary>
        SystemFunction
    }

    /// <summary>
    /// Enumeración que define los tipos de reglas soportadas
    /// </summary>
    public enum RuleType
    {
        /// <summary>
        /// Tipo regla
        /// </summary>
        Rule,
        /// <summary>
        /// Reglas de tipo plantilla
        /// </summary>
        Template
    }

    /// <summary>
    /// Enumeración que define los estados disponibles para reglas y funciones
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Estado en desarrollo
        /// </summary>
        InDevelopment,
        /// <summary>
        /// Estado publicada
        /// </summary>
        Published,
        /// <summary>
        /// Estado con errores
        /// </summary>
        WithError
    }

    /// <summary>
    /// Enumeración para definir el tipo de expresion a evaluar
    /// </summary>
    public enum ExpressionType
    {
        /// <summary>
        /// Expresion sencilla
        /// </summary>
        Expression,
        /// <summary>
        /// Expresion de tipo función
        /// </summary>
        Function,
        /// <summary>
        /// Expresion de tipo clase
        /// </summary>
        Class
    }

    /// <summary>
    /// Enumeración donde define los tipos de operadores
    /// </summary>
    public enum OperatorTypes
    {
        /// <summary>
        /// Normal
        /// </summary>
        None = 0,
        /// <summary>
        /// Concatenación
        /// </summary>
        Concat,
        /// <summary>
        /// Etiquetas
        /// </summary>
        Tag,
        /// <summary>
        /// Varios valores
        /// </summary>
        Values
    }
}
