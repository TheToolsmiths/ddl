using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Models.Literals;
using TheToolsmiths.Ddl.Parser.Models.Structs;
using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Models.Values;
using TheToolsmiths.Ddl.Parser.Shared;
using TheToolsmiths.Ddl.Parser.Shared.Contexts;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public class CommonParsers : ICommonParsers
    {
        private readonly IParserContext context;
        private readonly IServiceProvider provider;

        public CommonParsers(IParserContext context, IServiceProvider provider)
        {
            this.context = context;
            this.provider = provider;
        }

        public Task<ParseResult<StructDefinitionContent>> ParseStructDefinitionContentParser()
        {
            return this.provider.GetRequiredService<StructDefinitionContentParser>().Parse(this.context);
        }

        public Task<ParseResult<ITypeIdentifier>> ParseTypeIdentifier()
        {
            return this.provider.GetRequiredService<TypeIdentifierParser>().Parse(this.context);
        }

        public Task<ParseResult<ITypeName>> ParseTypeName()
        {
            return this.provider.GetRequiredService<TypeNameParser>().ParseTypeName(this.context);
        }

        public Task<ParseResult<IReadOnlyList<IAttributeUse>>> ParseAttributeUseList()
        {
            return this.provider.GetRequiredService<AttributeUsageParser>().ParseAttributeUseList(this.context);
        }

        public Task<ParseResult<StructValueInitialization>> ParseStructValueInitialization()
        {
            return this.provider.GetRequiredService<StructValueInitializationParser>().ParseStructuredInitialization(this.context);
        }

        public Task<ParseResult<LiteralValue>> ParseLiteralValue()
        {
            return this.provider.GetRequiredService<LiteralValueInitializationParser>().ParseLiteralValue(this.context);
        }

        public Task<ParseResult<ConditionalExpression>> ParseConditionalExpressionRoot()
        {
            return this.provider.GetRequiredService<ConditionalExpressionParser>().ParseConditionalExpressionRoot(this.context);
        }

        public Task<ParseResult<ValueInitialization>> ParseFieldInitialization()
        {
            return this.provider.GetRequiredService<FieldInitializationParser>().ParseFieldInitialization(this.context);
        }
    }
}
