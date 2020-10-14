namespace TheToolsmiths.Ddl.Models.Build.ConditionalExpressions
{
    public class DefineCompareExpression : IConditionalExpressionElement
    {
        private DefineCompareExpression(DefineCompareKind compareKind, string define, string value)
        {
            this.CompareKind = compareKind;
            this.Define = define;
            this.Value = value;
        }

        public DefineCompareKind CompareKind { get; }

        public string Define { get; }

        public string Value { get; }

        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.CompareDefine;

        public static DefineCompareExpression CreateNotEquals(string define, string value)
        {
            return new DefineCompareExpression(DefineCompareKind.Inequality, define, value);
        }

        public static DefineCompareExpression CreateEquals(string define, string value)
        {
            return new DefineCompareExpression(DefineCompareKind.Equality, define, value);
        }
    }
}
