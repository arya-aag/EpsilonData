using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectionTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void ConnectionTest()
        {
            Connection newConnection = new Connection("http://10.87.231.77:8080/MarketDataAnalysisToolWeb/rest/FirstFunction/allTickers");

        }
    }
}
