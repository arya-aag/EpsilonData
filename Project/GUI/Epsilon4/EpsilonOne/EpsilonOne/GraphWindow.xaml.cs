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

namespace EpsilonOne
{
    /// <summary>
    /// Interaction logic for GraphParamsWindow.xaml
    /// </summary>
    public partial class GraphWindow : Window
    {
        App appXaml = (App)Application.Current;

        AllPoints pointsToDraw = new AllPoints();
        //List<KeyValuePair<int, double>> pointsToPlot = new List<KeyValuePair<int, double>>();
        LineSeries lineSeries1 = new LineSeries();
        LineSeries lineSeries2 = new LineSeries();


        public GraphWindow()
        {
            InitializeComponent();
            lblTicker1.Content = appXaml.ticker1;
        }

        private void PopulateOnWindowsLoaded(object sender, RoutedEventArgs e)
        {
            PopulateStockIndicatorDropdown();
            PopulateMovingAverageDropdown();
            SetTimeWindow();
            DrawGraphs();

        }

        private void PopulateStockIndicatorDropdown()
        {
            List<string> stockIndiList = new List<string>()
            { "Open Value", "Close Value", "Day High", "Day Low", "Volume Traded"};
            foreach (string str in stockIndiList)
            {
                cmbStockIndicator.Items.Add(str);
            }
        }

        private void PopulateMovingAverageDropdown()
        {
            List<string> movingAvgList = new List<string>() {"None",
                "7 Day Moving Average", "Exponential Moving Average", "Deviation from Simple Moving Avg." };
            foreach (string str in movingAvgList)
            {
                cmbMovingAvg.Items.Add(str);
            }
        }

        private void SetTimeWindow()
        {
            datStartDate.SelectedDate = new DateTime(2009,8,21);
            datEndDate.SelectedDate = new DateTime(2010, 11, 5);
        }
        
        //private void Test(object sender, RoutedEventArgs e)
        //{
        //    string getURL = appXaml.ipRest+"FirstFunction";
        //    WebClient getWC = new WebClient();

        //    Stream getStream = getWC.OpenRead(getURL);
        //    DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(AllPoints));
        //    AllPoints allPoints = (AllPoints)DCJS.ReadObject(getStream);
        //    pointsToDraw = allPoints;
        //}

        private void SetDates(DateTime start, DateTime end)
        {
            datStartDate.SelectedDate = start;
            datEndDate.SelectedDate = end;
        }

        private void ClearQuarterBolds()
        {
            List<Button> listButtons = new List<Button>() { btn92, btn93, btn94, btn101, btn102};
            foreach (Button btn in listButtons)
            {
                btn.FontWeight = FontWeights.Normal;
                btn.Foreground = Brushes.White;
                btn.BorderBrush = Brushes.Transparent;
            }
        }

        private void HighlightQuarter(Button btn)
        {
            btn.FontWeight = FontWeights.Bold;
            btn.Foreground = Brushes.Turquoise;
            btn.BorderBrush = Brushes.White;
        }

        private void Set09Q2(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            HighlightQuarter(btn92);
            SetDates(new DateTime(2009, 8, 21), new DateTime(2009, 9, 30));
            UpdatePlots();
        }

        private void Set09Q3(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            HighlightQuarter(btn93);
            SetDates(new DateTime(2009, 10, 1), new DateTime(2009, 12, 31));
            UpdatePlots();
        }

        private void Set09Q4(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            HighlightQuarter(btn94);
            SetDates(new DateTime(2010, 1, 1), new DateTime(2010, 3, 31));
            UpdatePlots();
        }

        private void Set10Q1(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            HighlightQuarter(btn101);
            SetDates(new DateTime(2010, 4, 1), new DateTime(2010, 6, 30));
            UpdatePlots();
        }

        private void Set10Q2(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            HighlightQuarter(btn102);
            SetDates(new DateTime(2010, 7, 1), new DateTime(2010, 9, 30));
            UpdatePlots();
        }

        /*private void Set10Q3(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            HighlightQuarter(btn103);
            SetDates(new DateTime(2010, 10, 1), new DateTime(2010, 11, 5));
            UpdatePlots();
        }*/

        private Boolean CheckNegativeTime(DateTime startDate, DateTime endDate)
        {
            if ((endDate - startDate).TotalDays <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        string fileLocation = "";

        private void DrawGraphs()
        {
            UpdateYAxis();

            DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(AllPoints));

            string getURL =  SetURL();
            WebClient getWC = new WebClient();
            Stream getStream = getWC.OpenRead(getURL);
            AllPoints allPoints = (AllPoints)DCJS.ReadObject(getStream);

            //fileLocation = SetLocation();
            //string fileName = 
            //    @"C:\Users\Arti Kumari\Desktop\GUI\Epsilon4\EpsilonOne\EpsilonOne\bin\Debug\context\"+fileLocation;
            //StreamReader reader = new StreamReader(fileName);
            //AllPoints allPoints = 
            //    (AllPoints)DCJS.ReadObject(reader.BaseStream);

            List<KeyValuePair<int, double>> pointsToPlot = new List<KeyValuePair<int, double>>();
            pointsToPlot = CreateKeyValuePairsFromPoints(allPoints);

            lineSeries1.Title = appXaml.ticker1;
            lineSeries1.ItemsSource = pointsToPlot;
            lineSeries1.DependentValuePath = "Value";
            lineSeries1.IndependentValuePath = "Key";
            chtWindow.Title = appXaml.ticker1;
            chtWindow.Series.Add(lineSeries1);
        }
        private string SetLocation()
        {
            string URL="";

            if (cmbMovingAvg.SelectedIndex == 1) { URL += "simpleavg.txt"; }
            else if (cmbMovingAvg.SelectedIndex == 2) { URL += "simpleavg.txt"; }
            else if (cmbMovingAvg.SelectedIndex == 3) { URL += "devFromSimlpleAvg.txt"; }
            else { URL += "closeprice.txt"; }

            return URL;
        }

        private string SetURL()
        {
            string URL = appXaml.ipFF;

            if (cmbMovingAvg.SelectedIndex == 1) { URL += "simpleAvg/"; }
            else if (cmbMovingAvg.SelectedIndex == 2) { URL += "expAvg/"; }
            else if (cmbMovingAvg.SelectedIndex == 3) { URL += "devFromAvg/"; }
            else { }

            URL += appXaml.ticker1+"/";

            switch (cmbStockIndicator.SelectedIndex)
            {
                case 0:
                    URL += "open/";
                    break;
                case 1:
                    URL += "close/";
                    break;
                case 2:
                    URL += "high/";
                    break;
                case 3:
                    URL += "low/";
                    break;
                case 4:
                    URL += "volume/";
                    break;
            }

            URL += appendDate((DateTime)datStartDate.SelectedDate);
            URL += "/";
            URL += appendDate((DateTime)datEndDate.SelectedDate);
            URL += "/";

            if (cmbMovingAvg.SelectedIndex == 3) { URL += "simple/0"; }
            //MessageBox.Show(URL);

            return URL;
        }

        private string appendDate(DateTime date)
        {
            return ""+date.Day.ToString()+"-"+ date.Month.ToString()+"-"+ date.Year.ToString();
        }

        private List<KeyValuePair<int, double>> CreateKeyValuePairsFromPoints(AllPoints allPoints)
        {
            List<KeyValuePair<int, double>> newPoints = new List<KeyValuePair<int, double>>();
            foreach (Point point in allPoints.stockCloseValueList)
            {
                newPoints.Add(new KeyValuePair<int, double>
                    (point.date, point.yCoordinate));
            }
            return newPoints;
        }

        private void UpdatePlot(object sender, RoutedEventArgs e)
        {
            UpdatePlots();
        }

        private void UpdatePlots()
        {
            Boolean negativeTime =
                CheckNegativeTime((DateTime)datStartDate.SelectedDate, (DateTime)datEndDate.SelectedDate);

            if (!negativeTime)
            {
                chtWindow.Series.Clear();
                DrawGraphs();
            }
            else
            {
                MessageBox.Show("The Start Date lies after the End Date. Please choose again.");
            }
        }


        private void UpdateYAxis()
        {
            string YAxis = "";
            if (cmbMovingAvg.SelectedIndex == 1) { YAxis += "Simple Moving Avg. of "; }
            else if (cmbMovingAvg.SelectedIndex == 2) { YAxis += "Exponential Moving Avg. of "; }
            else if (cmbMovingAvg.SelectedIndex == 3) { YAxis += "Deviation from Simple Moving Avg. of "; }
            else { }

            switch (cmbStockIndicator.SelectedIndex)
            {
                case 0:
                    YAxis += "Open value";
                    break;
                case 1:
                    YAxis += "Close value";
                    break;
                case 2:
                    YAxis += "Day high";
                    break;
                case 3:
                    YAxis += "Day low";
                    break;
                case 4:
                    YAxis += "Volume traded";
                    break;
            }
            txtblkYAxis.Text = YAxis;
        }

        private void GoToStockDetails(object sender, RoutedEventArgs e)
        {
            StockDetailsWindow sdw = new StockDetailsWindow();
            sdw.Show();
            this.Close();
        }
        
        
    }
}
