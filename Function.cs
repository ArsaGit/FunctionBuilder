using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionBuilder
{
	public class Function
	{
		private string expression;
		private double x0, x1, step;

		public Function(string[] functionData)
		{
			expression = functionData[0];
			x0 = ConvertToDouble(functionData[1]);
			x1 = ConvertToDouble(functionData[2]);
			step = ConvertToDouble(functionData[3]);
		}

		private double ConvertToDouble(string strNumber)
		{
			return double.Parse(strNumber, System.Globalization.CultureInfo.InvariantCulture);
		}

	}
}
