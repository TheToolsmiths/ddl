namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public interface IKeyedAttributeUse : IAttributeUse
    {
        string Key { get; }
    }
}
