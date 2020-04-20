using System;

namespace TheToolsmiths.Ddl.Cli.Abstractions.Plugins
{
    public class PluginStartupAttribute : Attribute
    {
        public PluginStartupAttribute(Type hostingStartupType)
        {
            this.HostingStartupType = hostingStartupType;
        }

        public Type HostingStartupType { get; }
    }
}
