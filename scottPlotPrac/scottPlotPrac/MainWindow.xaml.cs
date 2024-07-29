using ScottPlot;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace scottPlotPrac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };
            WpfPlot1.Plot.Add.Scatter(dataX, dataY);

            // plot data with very different scales
            var sig1 = WpfPlot1.Plot.Add.Signal(Generate.Sin(mult: 0.01));
            var sig2 = WpfPlot1.Plot.Add.Signal(Generate.Cos(mult: 100));

            // tell each signal plot to use a different axis
            sig1.Axes.YAxis = WpfPlot1.Plot.Axes.Left;
            sig2.Axes.YAxis = WpfPlot1.Plot.Axes.Right;

            // add additional styling options to each axis
            WpfPlot1.Plot.Axes.Left.Label.Text = "Left Axis";
            WpfPlot1.Plot.Axes.Right.Label.Text = "Right Axis";
            WpfPlot1.Plot.Axes.Left.Label.ForeColor = sig1.Color;
            WpfPlot1.Plot.Axes.Right.Label.ForeColor = sig2.Color;

            WpfPlot1.Plot.HideGrid();
            WpfPlot1.Refresh();
        }
    }
}