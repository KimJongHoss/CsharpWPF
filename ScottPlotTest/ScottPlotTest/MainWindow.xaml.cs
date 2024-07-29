using ScottPlot;
using ScottPlot.Plottables;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace ScottPlotTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //scottPlat1
            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };
            WpfPlot1.Plot.Add.Scatter(dataX, dataY);
            WpfPlot1.Refresh();

            //scottPlat1
            var myScatter = WpfPlot2.Plot.Add.Scatter(dataX, dataY);
            myScatter.Color = Colors.Green.WithOpacity(.2);
            myScatter.LineWidth = 5;
            myScatter.MarkerSize = 15;

            WpfPlot2.Plot.Add.Scatter(dataX, dataY);
            WpfPlot2.Refresh();

            //scottPlat3
            double[] sin = Generate.Sin(51);
            double[] cos = Generate.Cos(51);
            WpfPlot3.Plot.Add.Signal(sin);
            WpfPlot3.Plot.Add.Signal(cos);

            WpfPlot3.Refresh();

            //scottPlat4
            double[] data = Generate.RandomWalk(1_000_000);
            WpfPlot4.Plot.Add.Signal(data);
            WpfPlot4.Plot.Title("Signal plot with one million points");

            WpfPlot4.Refresh();

            //scottPlat5
            WpfPlot5.Plot.Add.Signal(Generate.Sin(51));
            WpfPlot5.Plot.Add.Signal(Generate.Cos(51));

            WpfPlot5.Plot.XLabel("Horizonal Axis");
            WpfPlot5.Plot.YLabel("Vertical Axis");
            WpfPlot5.Plot.Title("Plot Title");

            WpfPlot5.Refresh();

            //scottPlat6
            var sig1 = WpfPlot6.Plot.Add.Signal(Generate.Sin(51));
            sig1.LegendText = "Sin";

            var sig2 = WpfPlot6.Plot.Add.Signal(Generate.Cos(51));
            sig2.LegendText = "Cos";

            WpfPlot6.Plot.ShowLegend();
            WpfPlot6.Refresh();

            //scottPlat7
            ScottPlot.Plottables.Arrow arrow = new()
            {
                Base = new Coordinates(1, 2),
                Tip = new Coordinates(3, 4),
            };

            // add the custom plottable to the plot
            WpfPlot7.Plot.Add.Plottable(arrow);

            WpfPlot7.Plot.ShowLegend();
            WpfPlot7.Refresh();

            //Right Axis
            // plot data with very different scales
            var sig3 = RightAxis.Plot.Add.Signal(Generate.Sin(mult: 0.01));
            var sig4 = RightAxis.Plot.Add.Signal(Generate.Cos(mult: 100));

            // tell each signal plot to use a different axis
            sig1.Axes.YAxis = RightAxis.Plot.Axes.Left;
            sig2.Axes.YAxis = RightAxis.Plot.Axes.Right;

            // add additional styling options to each axis
            RightAxis.Plot.Axes.Left.Label.Text = "Left Axis";
            RightAxis.Plot.Axes.Right.Label.Text = "Right Axis";
            RightAxis.Plot.Axes.Left.Label.ForeColor = sig3.Color;
            RightAxis.Plot.Axes.Right.Label.ForeColor = sig4.Color;

            RightAxis.Refresh();


            //Multi-Axis
            // plottables use the standard X and Y axes by default
            var sig5 = Multi_Axis.Plot.Add.Signal(ScottPlot.Generate.Sin(51, mult: 0.01));
            sig5.Axes.XAxis = Multi_Axis.Plot.Axes.Bottom; // standard X axis
            sig5.Axes.YAxis = Multi_Axis.Plot.Axes.Left; // standard Y axis
            Multi_Axis.Plot.Axes.Left.Label.Text = "Primary Y Axis";

            // create a second axis and add it to the plot
            var yAxis2 = Multi_Axis.Plot.Axes.AddLeftAxis();

            // add a new plottable and tell it to use the custom Y axis
            var sig6 = Multi_Axis.Plot.Add.Signal(ScottPlot.Generate.Cos(51, mult: 100));
            sig6.Axes.XAxis = Multi_Axis.Plot.Axes.Bottom; // standard X axis
            sig6.Axes.YAxis = yAxis2; // custom Y axis
            yAxis2.LabelText = "Secondary Y Axis";

            Multi_Axis.Refresh();
        }
    }
}
