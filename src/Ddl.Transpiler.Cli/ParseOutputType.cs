using System.Runtime.Serialization;

namespace TheToolsmiths.Ddl.Transpiler.Cli
{
    public enum ParseOutputType
    {
        [EnumMember(Value = "default")]
        Default,
        
        [EnumMember(Value = "json")]
        Json
    }
}
