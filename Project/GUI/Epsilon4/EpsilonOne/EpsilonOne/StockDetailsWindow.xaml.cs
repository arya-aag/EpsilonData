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
            DrawPiePlot();
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

            //string fileName = @"context/allTickers.txt";
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
                DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(MarketStockDetails));

                string getURL = appXaml.ipRest+"FirstFunction/stockInfo/"+appXaml.ticker1;
                WebClient getWC = new WebClient();
                Stream getStream = getWC.OpenRead(getURL);
                MarketStockDetails allDetails = (MarketStockDetails)DCJS.ReadObject(getStream);
                
                //string fileName = @"context/AAPLstockinfo.txt";
                //StreamReader reader = new StreamReader(fileName);
                //MarketStockDetails allDetails = (MarketStockDetails)DCJS.ReadObject(reader.BaseStream);

                lblTickerName.Content = appXaml.ticker1;
                lblOpen.Content = "            Open Value: " + allDetails.marketIndicators.open.ToString() +" $";
                lblClose.Content = "            Close Value: " + allDetails.marketIndicators.close.ToString() + " $";
                lblDayHigh.Content = "                Day High: " + allDetails.marketIndicators.high.ToString() + " $";
                lblDayLow.Content = "                 Day Low: " + allDetails.marketIndicators.low.ToString() + " $";
                lblVolume.Content = "                  Volume: " + allDetails.marketIndicators.volume.ToString();
                lbl52High.Content = "        52 Week High: " + allDetails.get52WeekHigh.ToString() + " $";
                lbl52Low.Content = "         52 Week Low: " + allDetails.get52WeekLow.ToString() + " $";
            
                //honest risk
                riskValue = (allDetails.risk);
                // hard coded random risk
                Random rnd = new Random();
                double risk1000 = rnd.Next(1001);
                riskValue = risk1000 / 100.0;

                lblRiskName.Content = "      Volatility Meter: " + riskValue;

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
                //Boolean? resultGraph = graphWindow.ShowDialog();
                graphWindow.Show();
                this.Close();
            }
        }

// PIE PLOT STUFF STARTS HERE ========================================================================================

        //private void ShowPiePlot(object sender, RoutedEventArgs e)
        //{
        //    SectoralPerformanceByVolumeWindow pieWindow = new SectoralPerformanceByVolumeWindow();
        //    Boolean? result = pieWindow.ShowDialog();
        //}

        private void DrawPiePlot()
        {
            DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(List<VolumeShare>));

            string getURL = appXaml.ipFF + "volume/" + appXaml.pieQuarter;
            WebClient getWC = new WebClient();
            Stream getStream = getWC.OpenRead(getURL);
            List<VolumeShare> piePlotDetails = (List<VolumeShare>)DCJS.ReadObject(getStream);

            //string fileName = @"context/pieQuarter.txt";
            //StreamReader reader = new StreamReader(fileName);
            //List<VolumeShare> piePlotDetails = (List<VolumeShare>)DCJS.ReadObject(reader.BaseStream);

            List<KeyValuePair<string, long>> pointsToPiePlot = new List<KeyValuePair<string, long>>();
            pointsToPiePlot = CreateKeyValuePairsFromVolumes(piePlotDetails);

            PieSeries pieSeries = new PieSeries();
            pieSeries.ItemsSource = null;
            pieSeries.ItemsSource = pointsToPiePlot;
            pieSeries.DependentValuePath = "Value";
            pieSeries.IndependentValuePath = "Key";

            long[] vols = new long[4];
            int i = 0;
            foreach (VolumeShare vs in piePlotDetails)
            {
                vols[i++] = vs.volume;
            }
            double[] percs = new double[4];
            percs = CalculatePercentages(vols);

            UpdatePiePlotTitle(percs);
            chtPieChart.Title = piePlotTitle;

            chtPieChart.Series.Add(pieSeries);
        }

        private double[] CalculatePercentages(long[] vols)
        {
            double[] percs = new double[4];
            long sumOfVols = vols.Sum();
            for (int i = 0; i < 4; i++)
            {
                percs[i] = ((double)vols[i] / (double)sumOfVols)*100;
                percs[i] = Math.Round(percs[i], 2);
            }
            return percs;
        }

        private void UpdatePiePlot()
        {
            chtPieChart.Series.Clear();
            DrawPiePlot();
        }

        private List<KeyValuePair<string, long>> CreateKeyValuePairsFromVolumes(List<VolumeShare> listOfVolShares)
        {
            List<KeyValuePair<string, long>> piePoints = new List<KeyValuePair<string, long>>();
            foreach (VolumeShare volShare in listOfVolShares)
            {
                piePoints.Add(new KeyValuePair<string, long>
                    (volShare.type_, volShare.volume));
            }
            return piePoints;
        }

        string piePlotTitle = "";

        private void UpdatePiePlotTitle(double[] percs)
        {
            piePlotTitle = string.Format
                ("Banking: {0}%, Beverage: {1}%, \nEnergy: {2}%, Pharma: {3}%",percs[0],percs[1],percs[2],percs[3]);
        }

        private void ShowQ2Volume(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            btnQ2.FontWeight = FontWeights.Bold;
            btnQ2.Foreground = Brushes.Turquoise;
            appXaml.pieQuarter = "Q2";
            UpdatePiePlot();
        }
        private void ShowQ3Volume(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            btnQ3.FontWeight = FontWeights.Bold;
            btnQ3.Foreground = Brushes.Turquoise;
            appXaml.pieQuarter = "Q3";
            UpdatePiePlot();
        }
        private void ShowQ4Volume(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            btnQ4.FontWeight = FontWeights.Bold;
            btnQ4.Foreground = Brushes.Turquoise;
            appXaml.pieQuarter = "Q4";
            UpdatePiePlot();
        }
        private void ClearQuarterBolds()
        {
            List<Button> listOfButtons = new List<Button>() { btnQ2,btnQ3,btnQ4};
            foreach (Button btn in listOfButtons)
            {
                btn.FontWeight = FontWeights.Normal;
                btn.Foreground = Brushes.White;
            }
        }

        private void GoToWelcome(object sender, RoutedEventArgs e)
        {
            WelcomeWindow ww = new WelcomeWindow();
            ww.Show();
            this.Close();
        }
    }
}
