using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheToolsmiths.Ddl.Lexer.Tests.Utils;

namespace TheToolsmiths.Ddl.Lexer.Tests
{
    [TestClass]
    public class AllFeaturesLexing
    {
        private const string AllFeaturesFile = "allFeatures.ddl";

        [TestMethod]
        public async Task TestAllFeatures()
        {
            var lexer = await FileLexerUtils.CreateLexerFromPath(AllFeaturesFile);

            while (true)
            {
                var result = await lexer.TryGetNextToken();

                if (result.HasToken == false)
                {
                    break;
                }

                var token = result.Token;
            }
        }
    }
}
