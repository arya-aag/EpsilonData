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
                "Simple Moving Average", "Exponential Moving Average", "Deviation from Simple Moving Avg." };
            foreach (string str in movingAvgList)
            {
                cmbMovingAvg.Items.Add(str);
            }
        }

        private void SetTimeWindow()
        {
            datStartDate.SelectedDate = new DateTime(2009,8,21);
            datEndDate.SelectedDate = new DateTime(2009, 11, 5);
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
            List<Button> listButtons = new List<Button>() { btn92, btn93, btn94, btn101, btn102, btn103 };
            foreach (Button btn in listButtons)
            {
                btn.FontWeight = FontWeights.Normal;
                btn.Foreground = Brushes.Black;
            }
        }

        private void HighlightQuarter(Button btn)
        {
            btn.FontWeight = FontWeights.Bold;
            btn.Foreground = Brushes.Blue;
        }

        private void Set09Q2(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            HighlightQuarter(btn92);
            SetDates(new DateTime(2009, 8, 21), new DateTime(2009, 9, 30));
        }

        private void Set09Q3(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            HighlightQuarter(btn93);
            SetDates(new DateTime(2009, 10, 1), new DateTime(2009, 12, 31));
        }

        private void Set09Q4(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            HighlightQuarter(btn94);
            SetDates(new DateTime(2010, 1, 1), new DateTime(2010, 3, 31));
        }

        private void Set10Q1(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            HighlightQuarter(btn101);
            SetDates(new DateTime(2010, 4, 1), new DateTime(2010, 6, 30));
        }

        private void Set10Q2(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            HighlightQuarter(btn102);
            SetDates(new DateTime(2010, 7, 1), new DateTime(2010, 9, 30));
        }

        private void Set10Q3(object sender, RoutedEventArgs e)
        {
            ClearQuarterBolds();
            HighlightQuarter(btn103);
            SetDates(new DateTime(2009, 10, 1), new DateTime(2010, 11, 5));
        }

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

        private void DrawGraphs()
        {
            string getURL =  SetURL();

            WebClient getWC = new WebClient();
            Stream getStream = getWC.OpenRead(getURL);
            DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(AllPoints));
            AllPoints allPoints = (AllPoints)DCJS.ReadObject(getStream);

            CreateKeyValuePairsFromPoints(allPoints);

            lineSeries1.Title = appXaml.ticker1;
            lineSeries1.ItemsSource = appXaml.pointsToPlot1;
            lineSeries1.DependentValuePath = "Value";
            lineSeries1.IndependentValuePath = "Key";
            chtWindow.Title =appXaml.ticker1;
            chtWindow.Series.Add(lineSeries1);
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

            return URL;
        }

        private string appendDate(DateTime date)
        {
            return ""+date.Day.ToString()+"-"+ date.Month.ToString()+"-"+ date.Year.ToString();
        }

        private void CreateKeyValuePairsFromPoints(AllPoints allPoints)
        {
            //appXaml.pointsToPlot1 = new List<KeyValuePair<int, double>>();
            foreach (Point point in allPoints.stockCloseValueList)
            {
                appXaml.pointsToPlot1.Add(new KeyValuePair<int, double>
                    (point.date, point.yCoordinate));
            }
            //return appXaml.pointsToPlot1;
        }
        private void UpdatePlot(object sender, RoutedEventArgs e)
        {
            Boolean negativeTime = 
                CheckNegativeTime((DateTime)datStartDate.SelectedDate,(DateTime)datEndDate.SelectedDate);

            if (!negativeTime)
            {
                chtWindow.Series.Clear();
                DrawGraphs();
                /*
                string getURL = appXaml.ipFF + appXaml.ticker1 + "/close/21-08-2009/05-11-2010";
                WebClient getWC = new WebClient();
                Stream getStream = getWC.OpenRead(getURL);
                DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(AllPoints));
                AllPoints allPoints = (AllPoints)DCJS.ReadObject(getStream);

                CreateKeyValuePairsFromPoints(allPoints);

                //LineSeries lineSeries = new LineSeries();
                lineSeries1.Title = appXaml.ticker1;
                lineSeries1.ItemsSource = appXaml.pointsToPlot1;
                lineSeries1.DependentValuePath = "Value";
                lineSeries1.IndependentValuePath = "Key";
                chtWindow.Series.Add(lineSeries1);
                //chtWindow.Series.Remove(lineSeries);


                //chtWindow.Series.Remove(lineSeries1);
                //try { chtWindow.Series.Remove(lineSeries2); } catch { }
                */
            }
            else
            {
                MessageBox.Show("The Start Date lies after the End Date. Please choose again.");
            }
        }
    }
}
