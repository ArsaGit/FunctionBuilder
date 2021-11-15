using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionBuilder.Logic
{
	public class Function
	{
		private string expression;
		private double x0, x1, step;

		private readonly RPN RPN;
		private object[] rpn;

		public Point[] Points { get; private set; }

		public Function(string expression, double x0, double x1, double step)
		{
			this.expression = expression;
			this.x0 = x0;
			this.x1 = x1;
			this.step = step;

			RPN = new(expression);
			rpn = RPN.ConvertToRPN(expression);

			Points = CalculatePoints();
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

		private Point[] CalculatePoints()
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
