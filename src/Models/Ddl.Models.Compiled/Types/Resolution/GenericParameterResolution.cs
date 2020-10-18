namespace TheToolsmiths.Ddl.Models.Compiled.Types.Resolution
{
    public class GenericParameterResolution : TypeResolution
    {
        public GenericParameterResolution(
            string parameterName)
            : base(TypeResolutionKind.MatchGenericParameter)
        {
            this.ParameterName = parameterName;
        }

        public string ParameterName { get; }
    }
}
