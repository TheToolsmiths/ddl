namespace TheToolsmiths.Ddl.Models.Compiled.Types.Resolution
{
    public class MatchGenericParameterResolution : TypeResolution
    {
        public MatchGenericParameterResolution(
            string parameterName)
            : base(TypeResolutionKind.MatchGenericParameter)
        {
            this.ParameterName = parameterName;
        }

        public string ParameterName { get; }
    }
}
