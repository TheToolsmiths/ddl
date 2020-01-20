namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public abstract class BaseAttributeUse : IAttributeUse
    {
        public abstract AttributeUseType UseType { get; }
        public abstract bool IsKeyed { get; }
        public abstract bool IsTyped { get; }
    }
}
