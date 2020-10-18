using System;

using TheToolsmiths.Ddl.Models.Ast.Literals;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Results;

using BoolLiteral = TheToolsmiths.Ddl.Models.Ast.Literals.BoolLiteral;
using LiteralValue = TheToolsmiths.Ddl.Models.Literals.LiteralValue;

namespace TheToolsmiths.Ddl.Parser.Build.Common
{
    public class LiteralValueBuilder
    {
        public Result<LiteralValue> BuildLiteral(
            IRootEntryBuildContext context,
            Models.Ast.Literals.LiteralValue astLiteral)
        {
            LiteralValue literalValue = astLiteral switch
            {
                BoolLiteral literal => BuildBoolLiteral(literal),
                NumberLiteral literal => BuildNumberLiteral(literal),
                StringLiteral literal => new Models.Literals.StringLiteral(literal.Text),
                DefaultLiteral _ => new Models.Literals.DefaultLiteral(),
                _ => throw new ArgumentOutOfRangeException(nameof(astLiteral))
            };

            return Result.FromValue(literalValue);
        }

        private static Models.Literals.NumberLiteral BuildNumberLiteral(NumberLiteral literal)
        {
            return new Models.Literals.NumberLiteral(literal.Text);
        }

        private static Models.Literals.BoolLiteral BuildBoolLiteral(BoolLiteral literal)
        {
            bool value = bool.Parse(literal.Text);

            return new Models.Literals.BoolLiteral(value);
        }
    }
}
