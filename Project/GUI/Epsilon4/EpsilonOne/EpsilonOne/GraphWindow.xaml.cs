using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Controls.DataVisualization.Charting;
using System.Text.RegularExpressions;

namespace EpsilonOne
{
    /// <summary>
    /// Interaction logic for GraphParamsWindow.xaml
    /// </summary>
    public partial class GraphWindow : Window
    {
        AllPoints pointsToDraw = new AllPoints();

        public GraphWindow()
        {
            InitializeComponent();
        }
        
        private void OkayClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void DrawGraphs(object sender, RoutedEventArgs e)
        {
            //AllPoints allPoints = new AllPoints();
            List<KeyValuePair<int, double>> pointsToPlot = CreateKeyValuePairsFromPoints(pointsToDraw);

            LineSeries lineSeries = new LineSeries();
            lineSeries.Title = pointsToDraw.ticker;
            lineSeries.ItemsSource = pointsToPlot;
            lineSeries.DependentValuePath = "Value";
            lineSeries.IndependentValuePath = "Key";
            //lineSeries.DataPointStyle
            chtWindow.Series.Add(lineSeries);
        }

        private List<KeyValuePair<int, double>> CreateKeyValuePairsFromPoints(AllPoints allPoints)
        {
            List<KeyValuePair<int, double>> pointsToPlot = new List<KeyValuePair<int, double>>();
            foreach (Point point in allPoints.stockCloseValueList)
            {
                pointsToPlot.Add(new KeyValuePair<int, double>
                    (point.relativeDifference, point.closeValue));
            }
            return pointsToPlot;
        }

        private void Test(object sender, RoutedEventArgs e)
        {
            string getURL = "http://10.87.231.72:8080/MarketDataAnalysisToolWeb/rest/FirstFunction";
            WebClient getWC = new WebClient();

            Stream getStream = getWC.OpenRead(getURL);
            DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(AllPoints));
            AllPoints allPoints = (AllPoints)DCJS.ReadObject(getStream);
            pointsToDraw = allPoints;
        }
    }
}
