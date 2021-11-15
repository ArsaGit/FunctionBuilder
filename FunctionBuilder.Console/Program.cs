using FunctionBuilder.Logic;

namespace FunctionBuilder.Console
{
	using System;

	class Program
	{
		static void Main(string[] args)
		{
			var IO = new InputOutput();
			var Printer = new Printer();

			string[] dataFunction = IO.ReadFile();

			string expression = dataFunction[0];
			double x0 = ConvertToDouble(dataFunction[1]);
			double x1 = ConvertToDouble(dataFunction[2]);
			double step = ConvertToDouble(dataFunction[3]);

			var function = new Function(expression, x0, x1, step);

			Printer.Print(function.Points);
		}

		static double ConvertToDouble(string strNumber)
		{
			return double.Parse(strNumber, System.Globalization.CultureInfo.InvariantCulture);
		}
	}
}
