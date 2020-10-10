namespace TheToolsmiths.Ddl.Configurations
{
    // TODO: Consider changing this name to IDdlConfigurator to avoid assuming scope is just for parser libraries
    public interface IParserConfigurator
    {
        void Configure(IParserConfigurationContext context);
    }
}
