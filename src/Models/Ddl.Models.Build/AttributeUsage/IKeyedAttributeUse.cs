namespace TheToolsmiths.Ddl.Models.Build.AttributeUsage
{
    public interface IKeyedAttributeUse : IAttributeUse
    {
        string Key { get; }
    }
}
