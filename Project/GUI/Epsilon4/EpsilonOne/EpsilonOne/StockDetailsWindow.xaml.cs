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

        App appXaml = (App)Application.Current;


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

            string getURL = appXaml.ipFF+"allTickers";
            WebClient getWC = new WebClient();
            Stream getStream = getWC.OpenRead(getURL);
            allTickers = (List<string>)DCJS.ReadObject(getStream);

            //string fileName = @"jsondump/allTickers.txt";
            //StreamReader reader = new StreamReader(fileName);
            //allTickers = (List<string>)DCJS.ReadObject(reader.BaseStream);

            foreach (string ticker in allTickers)
                lstTickers.Items.Add(ticker);
        }

        private void ShowStockDetails(object sender, SelectionChangedEventArgs e)
        {
            appXaml.ticker1 = (string)lstTickers.SelectedItem;

            if (appXaml.ticker1 == null)
            {
            }
            else
            {
                string getURL = appXaml.ipRest+"FirstFunction/stockInfo/"+appXaml.ticker1;
                WebClient getWC = new WebClient();
                Stream getStream = getWC.OpenRead(getURL);
                DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(MarketStockDetails));
                MarketStockDetails allDetails = (MarketStockDetails)DCJS.ReadObject(getStream);

                lblTickerName.Content = appXaml.ticker1;
                lblOpen.Content = "            Open Value: " + allDetails.marketIndicators.open.ToString();
                lblClose.Content = "            Close Value: " + allDetails.marketIndicators.close.ToString();
                lblDayHigh.Content = "                Day High: " + allDetails.marketIndicators.high.ToString();
                lblDayLow.Content = "                 Day Low: " + allDetails.marketIndicators.low.ToString();
                lblVolume.Content = "                  Volume: " + allDetails.marketIndicators.volume.ToString();
                lbl52High.Content = "        52 Week High: " + allDetails.get52WeekHigh.ToString();
                lbl52Low.Content = "         52 Week Low: " + allDetails.get52WeekLow.ToString();
            
                //honest risk
                riskValue = (allDetails.risk);
                // hard coded random risk
                Random rnd = new Random();
                double risk1000 = rnd.Next(1001);
                riskValue = risk1000 / 100.0;

                lblRiskName.Content = "              Risk Meter: " + riskValue;

                ShowRiskRectangle();
            }
        }
        private double riskValue;

        private void ShowRiskRectangle()
        {
            rectRisk.Width = riskValue*11.5 ;
            if (riskValue < 3.5) { rectRisk.Fill = new SolidColorBrush(System.Windows.Media.Colors.Green); }
            else if (riskValue < 7) { rectRisk.Fill = new SolidColorBrush(System.Windows.Media.Colors.Orange); }
            else { rectRisk.Fill = new SolidColorBrush(System.Windows.Media.Colors.Red); }
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
            appXaml.ticker1 = (string)lstTickers.SelectedItem;

            if (appXaml.ticker1 == null)
            {
                MessageBox.Show("Please select a ticker.");
            }
            else
            {
                GraphWindow graphWindow = new GraphWindow();
                Boolean? resultGraph = graphWindow.ShowDialog();
            }
        }

        private void ShowPiePlot(object sender, RoutedEventArgs e)
        {
            SectoralPerformanceByVolumeWindow pieWindow = new SectoralPerformanceByVolumeWindow();
            Boolean? result = pieWindow.ShowDialog();
        }
    }
}
