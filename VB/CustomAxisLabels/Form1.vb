Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace CustomAxisLabels
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create an empty chart.
			Dim chartControl1 As New ChartControl()

			' Create a bar series and add points to it.
			Dim series1 As New Series("Series 1", ViewType.Bar)
			series1.Points.Add(New SeriesPoint("A", New Double() { 10 }))
			series1.Points.Add(New SeriesPoint("B", New Double() { 12 }))
			series1.Points.Add(New SeriesPoint("C", New Double() { 17 }))
			series1.Points.Add(New SeriesPoint("D", New Double() { 14 }))
			series1.Points.Add(New SeriesPoint("E", New Double() { 17 }))

			' Add the series to the chart.
			chartControl1.Series.Add(series1)

			' Hide the legend and series labels (if necessary).
			chartControl1.Legend.Visible = False
			series1.Label.Visible = False

			' Cast the chart's diagram to the XYDiagram type, to access its axes.
			Dim diagram As XYDiagram = TryCast(chartControl1.Diagram, XYDiagram)

			' Add two custom labels to the X-axis' collection.
			diagram.AxisX.CustomLabels.Add(New CustomAxisLabel("Custom Label 1"))
			diagram.AxisX.CustomLabels.Add(New CustomAxisLabel("Custom Label 2"))

			' Define their AxisValue. Since the custom labels belong to the X-axis,
			' this property determines the series argument, to which labels should stick.
			diagram.AxisX.CustomLabels(0).AxisValue = "B"
			diagram.AxisX.CustomLabels(1).AxisValue = "D"

			' Customize the custom labels' appearance.
			diagram.AxisX.Label.TextColor = Color.Red

			' Add a title to the chart (if necessary).
			Dim chartTitle1 As New ChartTitle()
			chartTitle1.Text = "Custom Axis Labels"
			chartControl1.Titles.Add(chartTitle1)

			' Add the chart to the form.
			chartControl1.Dock = DockStyle.Fill
			Me.Controls.Add(chartControl1)
		End Sub

	End Class
End Namespace