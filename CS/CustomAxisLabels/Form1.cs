using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraCharts;
// ...

namespace CustomAxisLabels {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create an empty chart.
            ChartControl chartControl1 = new ChartControl();

            // Create a bar series and add points to it.
            Series series1 = new Series("Series 1", ViewType.Bar);
            series1.Points.Add(new SeriesPoint("A", new double[] { 10 }));
            series1.Points.Add(new SeriesPoint("B", new double[] { 12 }));
            series1.Points.Add(new SeriesPoint("C", new double[] { 17 }));
            series1.Points.Add(new SeriesPoint("D", new double[] { 14 }));
            series1.Points.Add(new SeriesPoint("E", new double[] { 17 }));

            // Add the series to the chart.
            chartControl1.Series.Add(series1);

            // Hide the legend and series labels (if necessary).
            chartControl1.Legend.Visible = false;
            series1.Label.Visible = false;

            // Cast the chart's diagram to the XYDiagram type, to access its axes.
            XYDiagram diagram = chartControl1.Diagram as XYDiagram;

            // Add two custom labels to the X-axis' collection.
            diagram.AxisX.CustomLabels.Add(new CustomAxisLabel("Custom Label 1"));
            diagram.AxisX.CustomLabels.Add(new CustomAxisLabel("Custom Label 2"));

            // Define their AxisValue. Since the custom labels belong to the X-axis,
            // this property determines the series argument, to which labels should stick.
            diagram.AxisX.CustomLabels[0].AxisValue = "B";
            diagram.AxisX.CustomLabels[1].AxisValue = "D";

            // Customize the custom labels' appearance.
            diagram.AxisX.Label.TextColor = Color.Red;

            // Add a title to the chart (if necessary).
            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "Custom Axis Labels";
            chartControl1.Titles.Add(chartTitle1);

            // Add the chart to the form.
            chartControl1.Dock = DockStyle.Fill;
            this.Controls.Add(chartControl1);
        }

    }
}