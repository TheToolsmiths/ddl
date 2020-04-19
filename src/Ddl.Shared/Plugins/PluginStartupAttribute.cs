using System;

namespace TheToolsmiths.Ddl.Shared.Plugins
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
