using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class LiteralListener : DdlBaseListener
    {
        public LiteralValue Value { get; private set; }

        public override void EnterBoolLiteral(DdlParser.BoolLiteralContext context)
        {
            var text = context.BoolLiteral().GetText();

            Value = new LiteralValue(LiteralValueType.Boolean, text);
        }

        public override void EnterFloatLiteral(DdlParser.FloatLiteralContext context)
        {
            var text = context.FloatLiteral().GetText();

            Value = new LiteralValue(LiteralValueType.Float, text);
        }

        public override void EnterIntegerLiteral(DdlParser.IntegerLiteralContext context)
        {
            var text = context.IntLiteral().GetText();

            Value = new LiteralValue(LiteralValueType.Integer, text);
        }

        public override void EnterStringLiteral(DdlParser.StringLiteralContext context)
        {
            var text = context.StringLiteral().GetText();

            Value = new LiteralValue(LiteralValueType.String, text);
        }
    }
}
