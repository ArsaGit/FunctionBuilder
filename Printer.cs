using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionBuilder
{
	public class Printer
	{
		public void Print(Point[] points)
		{
			foreach(Point point in points)
			{
				Print(point);
			}
		}

		public void Print(Point point)
		{
			Console.WriteLine($"{Math.Round(point.X, 2)}\t{Math.Round(point.Y, 2)}");
		}
	}
}
