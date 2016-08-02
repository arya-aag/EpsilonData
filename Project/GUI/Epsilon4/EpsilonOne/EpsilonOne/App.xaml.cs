using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EpsilonOne
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //global
        public string ipRest = "http://10.87.238.241:8080/MarketDataAnalysisToolWeb/rest/";
        public string ipFF = "http://10.87.238.241:8080/MarketDataAnalysisToolWeb/rest/FirstFunction/";

        //graph window
        public List<KeyValuePair<int, double>> pointsToPlot1 = new List<KeyValuePair<int, double>>();
        public List<KeyValuePair<int, double>> pointsToPlot2 = new List<KeyValuePair<int, double>>();
        public string ticker1 = "";
        public string ticker2 = "";
        public int numOfGraphs = 0;

        //pie plot
        //public List<KeyValuePair<string, long>> pointsToPiePlot = new List<KeyValuePair<string, long>>();
        public string pieQuarter = "Q2";

    }
}
