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

namespace EpsilonOne
{
    /// <summary>
    /// Interaction logic for GraphParamsWindow.xaml
    /// </summary>
    public partial class GraphParamsWindow : Window
    {
        public GraphParamsWindow()
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
    }
}
