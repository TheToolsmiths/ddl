using System;
using TheToolsmiths.Ddl.Models.Ast.Literals;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Results;
using BoolLiteral = TheToolsmiths.Ddl.Models.Ast.Literals.BoolLiteral;
using DefaultLiteral = TheToolsmiths.Ddl.Models.Ast.Literals.DefaultLiteral;
using LiteralValue = TheToolsmiths.Ddl.Models.Build.Literals.LiteralValue;

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
                BoolLiteral literal => new Models.Build.Literals.BoolLiteral(literal.Text),
                DefaultLiteral literal => new Models.Build.Literals.DefaultLiteral(),
                EmptyLiteral literal => new Models.Build.Literals.DefaultLiteral(),
                NumberLiteral literal => new Models.Build.Literals.NumberLiteral(literal.Text),
                StringLiteral literal => new Models.Build.Literals.StringLiteral(literal.Text),
                _ => throw new ArgumentOutOfRangeException(nameof(astLiteral))
            };

            return Result.FromValue(literalValue);
        }
    }
}
