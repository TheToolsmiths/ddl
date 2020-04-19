using System.Runtime.Serialization;

namespace TheToolsmiths.Ddl.Cli
{
    public enum ParseOutputType
    {
        [EnumMember(Value = "default")]
        Default,
        
        [EnumMember(Value = "json")]
        Json
    }
}
