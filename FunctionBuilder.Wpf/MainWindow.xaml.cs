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

namespace FunctionBuilder.Wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			Draw();
		}

		private void Draw()
		{
			canvas.Children.Clear();
			DrawCoodinateAxes();
		}

		private void DrawLine((double x, double y) p1, (double x, double y) p2)
		{
			Line line = new();

			line.X1 = p1.x;
			line.Y1 = p1.y;
			line.X2 = p2.x;
			line.Y2 = p2.y;
			line.Stroke = Brushes.Black;
			line.StrokeThickness = 1;

			canvas.Children.Add(line);
		}

		private void DrawCoodinateAxes()
		{
			double width = canvas.ActualWidth;
			double height = canvas.ActualHeight;

			//xAxis
			DrawLine((0, height / 2), (width, height / 2));
			//DrawArrowHead
			DrawLine((width, height / 2), (width - width / 80, height / 2 - height / 80));
			DrawLine((width, height / 2), (width - width / 80, height / 2 + height / 80));

			//yAxis
			DrawLine((width / 2, height), (width / 2, 0));
			//DrawArrowHead
			DrawLine((width / 2, 0), (width / 2 - width / 80, height / 80));
			DrawLine((width / 2, 0), (width / 2 + width / 80, height / 80));
		}
	}
}
