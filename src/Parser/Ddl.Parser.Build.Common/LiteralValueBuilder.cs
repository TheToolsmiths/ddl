using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.Literals;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Results;
using BoolLiteral = TheToolsmiths.Ddl.Parser.Ast.Models.Literals.BoolLiteral;
using DefaultLiteral = TheToolsmiths.Ddl.Parser.Ast.Models.Literals.DefaultLiteral;
using LiteralValue = TheToolsmiths.Ddl.Models.Literals.LiteralValue;

namespace TheToolsmiths.Ddl.Parser.Build.Common
{
    public class LiteralValueBuilder
    {
        public Result<LiteralValue> BuildLiteral(
            IRootEntryBuildContext context,
            Ast.Models.Literals.LiteralValue astLiteral)
        {
            LiteralValue literalValue = astLiteral switch
            {
                BoolLiteral literal => new Models.Literals.BoolLiteral(literal.Text),
                DefaultLiteral literal => new Models.Literals.DefaultLiteral(),
                EmptyLiteral literal => new Models.Literals.DefaultLiteral(),
                NumberLiteral literal => new Models.Literals.NumberLiteral(literal.Text),
                StringLiteral literal => new Models.Literals.StringLiteral(literal.Text),
                _ => throw new ArgumentOutOfRangeException(nameof(astLiteral))
            };

            return Result.FromValue(literalValue);
        }
    }
}
