using TheToolsmiths.Ddl.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class LiteralListener : DdlBaseListener
    {
        public LiteralValue? Value { get; private set; }

        public override void EnterBoolLiteral(DdlParser.BoolLiteralContext context)
        {
            string text = context.BoolLiteral().GetText();

            this.Value = new LiteralValue(LiteralValueType.BooleanLiteral, text);
        }

        public override void EnterFloatLiteral(DdlParser.FloatLiteralContext context)
        {
            string text = context.FloatLiteral().GetText();

            this.Value = new LiteralValue(LiteralValueType.FloatLiteral, text);
        }

        public override void EnterIntegerLiteral(DdlParser.IntegerLiteralContext context)
        {
            string text = context.IntLiteral().GetText();

            this.Value = new LiteralValue(LiteralValueType.IntegerLiteral, text);
        }

        public override void EnterStringLiteral(DdlParser.StringLiteralContext context)
        {
            var literal = context.StringLiteral();
            string text = literal.GetText().Trim('"', '\'');

            this.Value = new LiteralValue(LiteralValueType.StringLiteral, text);
        }
    }
}
