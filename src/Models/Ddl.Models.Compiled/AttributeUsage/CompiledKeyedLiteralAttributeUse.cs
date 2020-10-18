using TheToolsmiths.Ddl.Models.Literals;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public class CompiledKeyedLiteralAttributeUse : BaseCompiledAttributeUse, ICompiledKeyedLiteralAttributeUse
    {
        public CompiledKeyedLiteralAttributeUse(string key, LiteralValue literal)
        {
            this.Key = key;
            this.Literal = literal;
        }

        public override CompiledAttributeUseKind UseKind => CompiledAttributeUseKind.KeyedLiteral;

        public override bool IsKeyed => true;

        public override bool IsTyped => false;

        public string Key { get; }

        public LiteralValue Literal { get; }
    }
}
