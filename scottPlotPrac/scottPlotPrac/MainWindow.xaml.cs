﻿using ScottPlot;
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

            double[] dataX = { 6, 12, 18, 24, 30 };
            double[] dataY = { 1, 4, 9, 16, 25 };
            WpfPlot1.Plot.Add.Scatter(dataX, dataY);

            // plot data with very different scales
            var sig1 = WpfPlot1.Plot.Add.Signal(Generate.Sin(mult: 5));
            var sig2 = WpfPlot1.Plot.Add.Signal(Generate.Cos(mult: 0.01));

            // tell each signal plot to use a different axis
            sig1.Axes.YAxis = WpfPlot1.Plot.Axes.Left;
            sig2.Axes.YAxis = WpfPlot1.Plot.Axes.Right;

            WpfPlot1.Plot.Add.Scatter(dataX, dataY);


            WpfPlot1.Plot.Add.Callout("Hello",
                textLocation: new(16, 22),
                tipLocation: new(dataX[3], dataY[3]));//dataX와 dataY에서 몇번째?

            WpfPlot1.Plot.Add.Callout("World",
                textLocation: new(24, 10),
                tipLocation: new(15.3, 4.7));

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