using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageConversao.Model;

namespace ConversaoDeMoedasTeste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesteUm()
        {
            var valor = new ConverterEmReais().Executa(1, 3.92d);

            Assert.IsTrue(valor.Equals("R$ 3,92"));
        }
    }
}
