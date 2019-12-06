using System;
using System.Threading.Tasks;
using Ddl.Transpiler;
using TheToolsmiths.Ddl.Parser;

namespace TheToolsmiths.Ddl.Transpiler.Cli
{
    public static class Program
    {
        private const string TestPath = "allFeatures.ddl";

        public static async Task Main()
        {
            var contents = await DdlTextParser.ReadFromFile(TestPath);

            string result = await DdlTranspiler.TranspileToString(contents);

            Console.Write(result);
        }
    }
}
