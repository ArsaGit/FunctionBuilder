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
		}

		private void DrawLine((double x, double y) p1, (double x, double y) p2)
		{
			Line line = new();

			line.X1 = p1.x;
			line.Y1 = p1.y;
			line.X2 = p1.x;
			line.Y2 = p1.y;
			line.Stroke = Brushes.Black;
			line.StrokeThickness = 1;

			canvas.Children.Add(line);
		}
	}
}
