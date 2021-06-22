using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionBuilder
{
	public class Function
	{
		private string expression;
		private double x0, x1, step;

		RPN RPN = new RPN();
		object[] rpn;

		//Point[] points;

		public Function(string[] functionData)
		{
			expression = functionData[0];
			x0 = ConvertToDouble(functionData[1]);
			x1 = ConvertToDouble(functionData[2]);
			step = ConvertToDouble(functionData[3]);

			rpn = RPN.ConvertToRPN(expression);

			//points = GetPoints();
		}

		private double ConvertToDouble(string strNumber)
		{
			return double.Parse(strNumber, System.Globalization.CultureInfo.InvariantCulture);
		}

		private double Calculate(double argumentValue)
		{
			Stack<double> result = new Stack<double>();

			foreach (object element in rpn)
			{
				if (element is double number)
				{
					result.Push(number);
				}
				else if (element is Argument)
				{
					result.Push(argumentValue);
				}
				else
				{
					Operation operation = (Operation)element;
					double[] arguments = new double[operation.NumberOfOperands];

					for (int i = operation.NumberOfOperands; i > 0; i--)
					{
						arguments[i - 1] = result.Pop();
					}

					double subResult = operation.Execute(arguments);
					result.Push(subResult);
				}
			}

			return result.Pop();
		}

		public Point[] GetPoints()
		{
			List<Point> points = new List<Point>();

			for(double argumentValue = x0; argumentValue <= x1; argumentValue += step)
			{
				var point = new Point(argumentValue, Calculate(argumentValue));
				points.Add(point);
			}

			return points.ToArray();
		}

	}
}
