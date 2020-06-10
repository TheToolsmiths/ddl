using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Ast.Models.CompareSymbolsExpressions;
using TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Operators;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public class ConditionalExpressionParser
    {
        public async Task<Result<ConditionalExpression>> ParseConditionalExpressionRoot(IParserContext context)
        {
            var parseResult = await this.ParseParenthesisExpression(context);

            if (parseResult.IsError)
            {
                throw new NotImplementedException();
            }

            var expression = parseResult.Value;

            var value = ConditionalExpression.Create(expression);

            return Result.FromValue(value);
        }

        private async Task<Result<IConditionalExpressionElement>> ParseParenthesisExpression(IParserContext context)
        {
            if (await context.Lexer.TryConsumeOpenParenthesesToken() == false)
            {
                throw new NotImplementedException();
            }

            var parseResult = await this.ParseExpressionsList(context);

            if (parseResult.IsError)
            {
                throw new NotImplementedException();
            }

            var expression = parseResult.Value;

            if (await context.Lexer.TryConsumeCloseParenthesesToken() == false)
            {
                throw new NotImplementedException();
            }

            var parenthesisExpression = new ParenthesisExpression(expression);

            return Result.FromValue<IConditionalExpressionElement>(parenthesisExpression);
        }

        private async Task<Result<IConditionalExpressionElement>> ParseExpressionsList(IParserContext context)
        {
            var expressions = new List<IConditionalExpressionElement>();

            IConditionalLogicalOperator? op = null;

            while (true)
            {
                {
                    var result = await context.Lexer.TryPeekToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var token = result.Token;

                    if (token.IsCloseParentheses())
                    {
                        break;
                    }
                }

                {
                    var parseResult = await this.ParseExpression(context);

                    if (parseResult.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    expressions.Add(parseResult.Value);
                }

                {
                    var result = await context.Lexer.TryPeekToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var token = result.Token;

                    if (token.IsLogicalAnd())
                    {
                        context.Lexer.PopToken();

                        if (op != null)
                        {
                            if (op.LogicalOperatorType != ConditionalLogicalOperatorType.And)
                            {
                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            op = new AndOperator();
                        }

                        continue;
                    }

                    if (token.IsLogicalOr())
                    {
                        context.Lexer.PopToken();

                        if (op != null)
                        {
                            if (op.LogicalOperatorType != ConditionalLogicalOperatorType.Or)
                            {
                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            op = new OrOperator();
                        }

                        continue;
                    }
                }

                break;
            }

            IConditionalExpressionElement expression;
            if (expressions.Count == 0)
            {
                expression = new EmptyExpression();
            }
            else if (expressions.Count == 1)
            {
                expression = expressions.First();
            }
            else
            {
                if (op == null)
                {
                    throw new ArgumentNullException();
                }

                if (expressions.Count == 2)
                {
                    var leftExpression = expressions[0];
                    var rightExpression = expressions[1];
                    expression = new BinaryExpression(op, leftExpression, rightExpression);
                }
                else
                {
                    expression = new LogicalCombinedExpressions(op, expressions);
                }
            }

            return Result.FromValue(expression);
        }

        private async Task<Result<IConditionalExpressionElement>> ParseExpression(IParserContext context)
        {
            var result = await context.Lexer.TryPeekToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            if (token.IsBoolean())
            {
                return await this.ParseBooleanExpression(context);
            }

            if (token.IsIdentifier())
            {
                return await this.ParseSymbolExpression(context);
            }

            if (token.IsLogicalNot())
            {
                return await this.ParseNegateExpression(context);
            }

            if (token.IsOpenParentheses())
            {
                return await this.ParseParenthesisExpression(context);
            }

            throw new NotImplementedException();
        }

        private async Task<Result<IConditionalExpressionElement>> ParseNegateExpression(IParserContext context)
        {
            if (await context.Lexer.TryConsumeLogicalNotToken() == false)
            {
                throw new NotImplementedException();
            }

            var result = await context.Lexer.TryPeekToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            var parseResult = token.Kind switch
            {
                LexerTokenKind.Identifier => await this.ParseIdentifierExpression(context),
                LexerTokenKind.OpenParentheses => await this.ParseParenthesisExpression(context),
                LexerTokenKind.Boolean => await this.ParseBooleanExpression(context),
                _ => throw new NotImplementedException()
            };

            if (parseResult.IsError)
            {
                return parseResult;
            }

            var expression = parseResult.Value;

            var value = new NegateExpression(expression);

            return Result.FromValue<IConditionalExpressionElement>(value);
        }

        private async Task<Result<IConditionalExpressionElement>> ParseIdentifierExpression(IParserContext context)
        {
            var result = await context.Lexer.TryGetIdentifierToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            var identifier = new Identifier(token.Memory.ToString());
            var expression = new IdentifierSymbolExpression(identifier);
            var value = new SymbolExpression(expression);

            return Result.FromValue<IConditionalExpressionElement>(value);
        }

        private async Task<Result<IConditionalExpressionElement>> ParseSymbolExpression(IParserContext context)
        {
            Identifier identifier;
            {
                var result = await context.Lexer.TryGetIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                identifier = Identifier.FromString(token.Memory.ToString());
            }

            IConditionalSymbolExpression expression;
            {
                var operatorResult = await context.Lexer.TryPeekToken();

                if (operatorResult.IsError)
                {
                    throw new NotImplementedException();
                }

                var operatorToken = operatorResult.Token;

                if (operatorToken.IsEquality()
                || operatorToken.IsInequality())
                {
                    context.Lexer.PopToken();

                    var result = await context.Lexer.TryGetStringToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    string literalValue = result.Token.Memory.ToString();

                    IEqualityComparerOperator comparer;
                    if (operatorToken.IsEquality())
                    {
                        comparer = new EqualityComparerOperator();
                    }
                    else if (operatorToken.IsInequality())
                    {
                        comparer = new InequalityComparerOperator();
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }

                    expression = new CompareSymbolExpression(identifier, comparer, literalValue);
                }
                else
                {
                    expression = new IdentifierSymbolExpression(identifier);
                }
            }

            var value = new SymbolExpression(expression);
            return Result.FromValue<IConditionalExpressionElement>(value);
        }

        private async Task<Result<IConditionalExpressionElement>> ParseBooleanExpression(IParserContext context)
        {
            var result = await context.Lexer.TryGetLiteralToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            IConditionalExpressionElement value;
            if (token.IsBooleanTrue())
            {
                value = new BoolLiteralExpression(true);
            }
            else if (token.IsBooleanFalse())
            {
                value = new BoolLiteralExpression(false);
            }
            else
            {
                throw new ArgumentOutOfRangeException(token.ToString());
            }

            return Result.FromValue(value);
        }
    }
}
