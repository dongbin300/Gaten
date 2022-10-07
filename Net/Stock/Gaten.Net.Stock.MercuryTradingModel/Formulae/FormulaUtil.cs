using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Formulae
{
    public class FormulaUtil
    {
        public static Comparison ToComparison(string data) => data switch
        {
            "<" => Comparison.LessThan,
            "<=" => Comparison.LessThanOrEqual,
            ">" => Comparison.GreaterThan,
            ">=" => Comparison.GreaterThanOrEqual,
            "=" => Comparison.Equal,
            "!=" => Comparison.NotEqual,
            _ => Comparison.NotEqual
        };

        public static string ComparisonToString(Comparison comparison) => comparison switch
        {
            Comparison.LessThan => "<",
            Comparison.LessThanOrEqual => "<=",
            Comparison.GreaterThan => ">",
            Comparison.GreaterThanOrEqual => ">=",
            Comparison.Equal => "=",
            Comparison.NotEqual => "!=",
            _ => "!=",
        };
    }
}
