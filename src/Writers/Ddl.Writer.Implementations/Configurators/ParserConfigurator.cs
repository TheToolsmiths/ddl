using System;
using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Writer.Configurations;

namespace TheToolsmiths.Ddl.Writer.Implementations.Configurators
{
    public class ParserConfigurator : IParserConfigurator
    {
        public void Configure(IParserConfigurationContext context)
        {
            if (context.TryGetWriterConfigurationBuilder(out var builder) == false)
            {
                throw new NotImplementedException();
            }

            RegisterWriters(builder);
        }

        private static void RegisterWriters(IWriterConfigurationBuilder builder)
        {
            //throw new NotImplementedException();
        }
    }
}
