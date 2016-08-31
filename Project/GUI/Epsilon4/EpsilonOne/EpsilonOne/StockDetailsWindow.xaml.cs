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
using System.Text.RegularExpressions;

namespace EpsilonOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StockDetailsWindow : Window
    {
        public StockDetailsWindow()
        {
            InitializeComponent();
        }

        List<string> allTickers = new List<string>();

        private void PopulateTasks(object sender, RoutedEventArgs e)
        {
            //PopulateTimePeriod();
            PopulateTickers();
        }

        //private void PopulateTimePeriod()
        //{
        //    cmbTimePeriod.Items.Add("3 months");
        //    cmbTimePeriod.Items.Add("6 months");
        //    cmbTimePeriod.Items.Add("1 year");
        //}

        private void PopulateTickers() // this will take the string array they send and populate the cmbBox
        {
            DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(List<string>));

            //string getURL = "http://10.87.231.72:8080/MarketDataAnalysisToolWeb/rest/FirstFunction/allTickers";
            //WebClient getWC = new WebClient();
            //Stream getStream = getWC.OpenRead(getURL);
            //allTickers = (List<string>)DCJS.ReadObject(getStream);

            string fileName = @"jsondump/allTickers.txt";
            StreamReader reader = new StreamReader(fileName);
            allTickers = (List<string>)DCJS.ReadObject(reader.BaseStream);

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
        
        private void SearchTickers(object sender, TextChangedEventArgs e)
        {
            string input = txtSearch.Text;
            input = input.ToUpper();
            int lengths = input.Length;
            lstTickers.Items.Clear();
            foreach (string ticker in allTickers)
            {
                try
                {
                    string trial = ticker.Substring(0, lengths);
                    if (trial == input)
                    {
                        lstTickers.Items.Add(ticker);
                    }
                }
                catch
                {

                }
            }
        }

        private void ShowGraphWindow(object sender, RoutedEventArgs e)
        {
            GraphWindow graphWindow = new GraphWindow();
            graphWindow.Show();
        }
    }
}
