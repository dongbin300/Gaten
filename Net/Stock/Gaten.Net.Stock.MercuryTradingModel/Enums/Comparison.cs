namespace Gaten.Net.Stock.MercuryTradingModel.Enums
{
    public enum Comparison
    {
        None = 0,

        /// <summary>
        /// <
        /// </summary>
        LessThan = 23,

        /// <summary>
        /// >
        /// </summary>
        GreaterThan = 32,

        /// <summary>
        /// <=
        /// </summary>
        LessThanOrEqual = 22,

        /// <summary>
        /// >=
        /// </summary>
        GreaterThanOrEqual = 33,

        /// <summary>
        /// =
        /// </summary>
        Equal = 11,

        /// <summary>
        /// !=
        /// </summary>
        NotEqual = 10,
    }
}
