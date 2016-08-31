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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Controls.DataVisualization.Charting;

namespace EpsilonOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            showChart();
        }

        private void showChart()
        {
            //DateTime[] days = new DateTime[10];
            //days[0] = DateTime.Now;
            //for (int i = 0; i < 9; i++)
            //{
            //    days[i + 1] = days[i].AddDays(1);
            //}
            
            //List<KeyValuePair<int, double>> MyValue = new List<KeyValuePair<int, double>>();
            //MyValue.Add(new KeyValuePair<int, double>(1, 20));
            //MyValue.Add(new KeyValuePair<int, double>(2, 36));
            //MyValue.Add(new KeyValuePair<int, double>(3, 89));
            //MyValue.Add(new KeyValuePair<int, double>(5, 270));
            //MyValue.Add(new KeyValuePair<int, double>(7, 140));
            //MyValue.Add(new KeyValuePair<int, double>(8, 20));
            //MyValue.Add(new KeyValuePair<int, double>(9, 36));
            //MyValue.Add(new KeyValuePair<int, double>(10, 89));
            //MyValue.Add(new KeyValuePair<int, double>(11, 270));
            //MyValue.Add(new KeyValuePair<int, double>(50, 140));

            //LineChart1.DataContext = MyValue;
        }

        private void PopulateTasks(object sender, RoutedEventArgs e)
        {
            PopulateTimePeriod();
            PopulateTickers();
        }

        private void PopulateTimePeriod()
        {
            cmbTimePeriod.Items.Add("3 months");
            cmbTimePeriod.Items.Add("6 months");
            cmbTimePeriod.Items.Add("1 year");
        }

        private void PopulateTickers() // this will take the string array they send and populate the cmbBox
        {
            string getURL = "";
            WebClient getWC = new WebClient();
            Stream getStream = getWC.OpenRead(getURL);
            DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(List<string>));
            List<string> allTickers = (List<string>)DCJS.ReadObject(getStream);

            //List<string> allTickers = new List<string>();
            foreach (string ticker in allTickers)
                lstTickers.Items.Add(ticker);
        }

        private void ShowStockDetails(object sender, SelectionChangedEventArgs e)
        {
            string getURL = "";
            WebClient getWC = new WebClient();
            Stream getStream = getWC.OpenRead(getURL);
            DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(MarketStockDetails));
            MarketStockDetails allDetails = (MarketStockDetails)DCJS.ReadObject(getStream);

            lblTickerName.Content = allDetails.getStockInfoMarket[0].id.ticker;
            lblOpen.Content = allDetails.getStockInfoMarket[0].open;
            lblClose.Content = allDetails.getStockInfoMarket[0].close;
            lblDayHigh.Content = allDetails.getStockInfoMarket[0].high;
            lblDayLow.Content = allDetails.getStockInfoMarket[0].low;
            lblVolume.Content = allDetails.getStockInfoMarket[0].volume;
            lbl52High.Content = allDetails.get52WeekHigh;
            lbl52Low.Content = allDetails.get52WeekLow;
        }

        private void DrawGraphs(object sender, RoutedEventArgs e)
        {
            //AllPoints allPoints = new AllPoints();
            List<KeyValuePair<int,double>> pointsToPlot = CreateKeyValuePairsFromPoints(pointsToDraw);

            LineSeries lineSeries = new LineSeries();
            lineSeries.Title = "Microsoft";
            lineSeries.ItemsSource = pointsToPlot;
            lineSeries.DependentValuePath = "Value";
            lineSeries.IndependentValuePath = "Key";
            chtWindow.Series.Add(lineSeries);
        }

        private List<KeyValuePair<int, double>> CreateKeyValuePairsFromPoints(AllPoints allPoints)
        {
            List<KeyValuePair<int, double>> pointsToPlot = new List<KeyValuePair<int, double>>();
            foreach (Point point in allPoints.stockCloseValueList)
            {
                pointsToPlot.Add(new KeyValuePair<int, double>
                    (allPoints.stockCloseValueList.Count, allPoints.stockCloseValueList.Capacity));
            }
            return pointsToPlot;

        }

        private void Test(object sender, RoutedEventArgs e)
        {
            string getURL = "http://10.87.199.84:8080/MarketDataAnalysisToolWeb/rest/firstfunction";
            WebClient getWC = new WebClient();

            Stream getStream = getWC.OpenRead(getURL);
            DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(AllPoints));
            AllPoints allPoints = (AllPoints)DCJS.ReadObject(getStream);
            pointsToDraw = allPoints;
            //txtSearch.Text = pointsToDraw.ToString();
        }

        AllPoints pointsToDraw = new AllPoints();
    }
}
