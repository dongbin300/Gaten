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
            _ => Comparison.None
        };

        public static string ComparisonToString(Comparison comparison) => comparison switch
        {
            Comparison.LessThan => "<",
            Comparison.LessThanOrEqual => "<=",
            Comparison.GreaterThan => ">",
            Comparison.GreaterThanOrEqual => ">=",
            Comparison.Equal => "=",
            Comparison.NotEqual => "!=",
            _ => "",
        };

        public static Cross ToCross(string data) => data switch
        {
            "++" => Cross.GoldenCross,
            "--" => Cross.DeadCross,
            _ => Cross.None
        };

        public static string CrossToString(Cross cross) => cross switch
        {
            Cross.GoldenCross => "++",
            Cross.DeadCross => "--",
            _ => ""
        };
    }
}
