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
    /// Interaction logic for SectoralPerformanceByVolumeWindow.xaml
    /// </summary>
    public partial class SectoralPerformanceByVolumeWindow : Window
    {
        App appXaml = (App)Application.Current;
        
        public SectoralPerformanceByVolumeWindow()
        {
            InitializeComponent();
            //DrawPiePlot();
            PopulateQuarterList();
        }

        private void PopulateQuarterList()
        {
            List<string> quarters = new List<string>() { "Q2", "Q3", "Q4" };
            foreach (string quart in quarters) {
                cmbPieQuarter.Items.Add(quart);
            }
        }

        private void DrawPiePlot()
        {
            string getURL = appXaml.ipRest + "FirstFunction/volume/"+appXaml.pieQuarter;
            WebClient getWC = new WebClient();
            Stream getStream = getWC.OpenRead(getURL);
            DataContractJsonSerializer DCJS = new DataContractJsonSerializer(typeof(List<VolumeShare>));
            List<VolumeShare> piePlotDetails = (List<VolumeShare>)DCJS.ReadObject(getStream);

            List<KeyValuePair<string, long>> pointsToPiePlot = new List<KeyValuePair<string, long>>();
            pointsToPiePlot = CreateKeyValuePairsFromVolumes(piePlotDetails);

            PieSeries pieSeries = new PieSeries();
            pieSeries.ItemsSource = null;
            pieSeries.ItemsSource = pointsToPiePlot;
            pieSeries.DependentValuePath = "Value";
            pieSeries.IndependentValuePath = "Key";
            chtPieChart.Title = "Sectoral Performance By Volume for "+appXaml.pieQuarter;
            chtPieChart.Series.Add(pieSeries);
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

        private void UpdatePiePlot(object sender, SelectionChangedEventArgs e)
        {
            chtPieChart.Series.Clear();
            appXaml.pieQuarter = (string)cmbPieQuarter.SelectedItem;
            DrawPiePlot();
        }

        private void ExitGraph(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }

}
