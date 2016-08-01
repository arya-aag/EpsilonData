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
        public List<KeyValuePair<int, double>> pointsToPlot = new List<KeyValuePair<int, double>>();
        public List<KeyValuePair<string, long>> pointsToPiePlot = new List<KeyValuePair<string, long>>();

        public string ipRest = "http://10.87.238.241:8080/MarketDataAnalysisToolWeb/rest/";
        public string ticker1 = "";

        public string pieQuarter = "Q2";
    }
}
