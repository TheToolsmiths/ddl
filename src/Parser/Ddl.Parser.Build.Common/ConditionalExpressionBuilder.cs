using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Ast.CompareSymbolsExpressions;
using TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Ast.Operators;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Results;

using BoolLiteralExpression = TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions.BoolLiteralExpression;
using EmptyExpression = TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions.EmptyExpression;
using NegateExpression = TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions.NegateExpression;

namespace TheToolsmiths.Ddl.Parser.Build.Common
{
    public class ConditionalExpressionBuilder
    {
        public Result<ConditionalExpression> BuildExpression(
            IRootEntryBuildContext context,
            AstConditionalExpression conditionalExpression)
        {
            if (conditionalExpression.IsEmpty)
            {
                return Result.FromValue(ConditionalExpression.Empty);
            }

            var result = this.CreateExpression(conditionalExpression.Root);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var expression = ConditionalExpression.Create(result.Value);

            return Result.FromValue(expression);
        }

        private Result<IConditionalExpressionElement> CreateExpression(
            IAstConditionalExpressionElement element)
        {
            return element switch
            {
                BinaryExpression expression => this.CreateBinaryExpression(expression),
                BoolLiteralExpression expression => this.CreateBoolLiteralExpression(expression),
                EmptyExpression expression => this.CreateEmptyExpression(expression),
                LogicalCombinedExpressions expression => this.CreateLogicalCombinedExpression(expression),
                NegateExpression expression => this.CreateNegateExpression(expression),
                ParenthesisExpression expression => this.CreateParenthesisExpression(expression),
                SymbolExpression expression => this.CreateSymbolExpression(expression),
                _ => throw new ArgumentOutOfRangeException(nameof(element))
            };
        }

        private Result<IConditionalExpressionElement> CreateParenthesisExpression(ParenthesisExpression expression)
        {
            return this.CreateExpression(expression.InnerExpression);
        }

        private Result<IConditionalExpressionElement> CreateSymbolExpression(SymbolExpression expression)
        {
            var astSymbolExpression = expression.Expression;

            var symbolExpression = astSymbolExpression switch
            {
                CompareSymbolExpression compare => CreateCompareSymbolExpression(compare),
                IdentifierSymbolExpression identifier => DefineCheckExpression.CreateDefined(identifier.Identifier.Text),
                NegateSymbolExpression negate => DefineCheckExpression.CreateNotDefined(negate.Identifier.Text),
                _ => throw new ArgumentOutOfRangeException(nameof(astSymbolExpression))
            };
            return Result.FromValue(symbolExpression);

            IConditionalExpressionElement CreateCompareSymbolExpression(CompareSymbolExpression compare)
            {
                return compare.Comparer switch
                {
                    EqualityComparerOperator _ => DefineCompareExpression.CreateEquals(
                        compare.Identifier.Text,
                        compare.LiteralValue),
                    InequalityComparerOperator _ => DefineCompareExpression.CreateNotEquals(
                        compare.Identifier.Text,
                        compare.LiteralValue),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

        private Result<IConditionalExpressionElement> CreateNegateExpression(NegateExpression expression)
        {
            var result = this.CreateExpression(expression.InnerExpression);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var innerExpression = result.Value;

            var negateExpression = new Models.ConditionalExpressions.NegateExpression(innerExpression);
            return Result.FromValue<IConditionalExpressionElement>(negateExpression);
        }

        private Result<IConditionalExpressionElement> CreateEmptyExpression(EmptyExpression _)
        {
            return Result.FromValue<IConditionalExpressionElement>(new Models.ConditionalExpressions.EmptyExpression());
        }

        private Result<IConditionalExpressionElement> CreateBoolLiteralExpression(BoolLiteralExpression expression)
        {
            var literalExpression = expression.Value
                ? Models.ConditionalExpressions.BoolLiteralExpression.True
                : Models.ConditionalExpressions.BoolLiteralExpression.False;

            return Result.FromValue<IConditionalExpressionElement>(literalExpression);
        }

        private Result<IConditionalExpressionElement> CreateBinaryExpression(BinaryExpression expression)
        {
            IConditionalExpressionElement leftExpression;
            {
                var result = this.CreateExpression(expression.LeftExpression);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                leftExpression = result.Value;
            }

            IConditionalExpressionElement rightExpression;
            {
                var result = this.CreateExpression(expression.RightExpression);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                rightExpression = result.Value;
            }

            var logicalExpression = expression.Op switch
            {
                AndOperator _ => LogicalExpression.CreateAnd(leftExpression, rightExpression),
                OrOperator _ => LogicalExpression.CreateOr(leftExpression, rightExpression),
                _ => throw new ArgumentOutOfRangeException()
            };
            return Result.FromValue(logicalExpression);
        }

        private Result<IConditionalExpressionElement> CreateLogicalCombinedExpression(
            LogicalCombinedExpressions expression)
        {
            var expressions = new List<IConditionalExpressionElement>();

            foreach (var astExpression in expression.Expressions)
            {
                var result = this.CreateExpression(astExpression);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                expressions.Add(result.Value);
            }

            var logicalExpression = expression.Op switch
            {
                AndOperator _ => LogicalExpression.CreateAnd(expressions),
                OrOperator _ => LogicalExpression.CreateOr(expressions),
                _ => throw new ArgumentOutOfRangeException()
            };
            return Result.FromValue(logicalExpression);
        }
    }
}
