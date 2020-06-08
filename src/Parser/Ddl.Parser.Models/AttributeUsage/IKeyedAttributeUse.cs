namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public interface IKeyedAttributeUse : IAttributeUse
    {
        string Key { get; }
    }
}
