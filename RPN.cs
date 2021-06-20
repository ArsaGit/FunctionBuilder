using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionBuilder
{
	public class RPN
	{
		private List<object> ParseExpression(string strExpression)
		{
			List<object> expression = new List<object>();
			int i = 0;

			while (i < strExpression.Length)
			{
				if (char.IsDigit(strExpression[i]))
				{
					i = ExtractNumber(strExpression, i, out double number);
					expression.Add(number);
				}
				else if (char.IsWhiteSpace(strExpression[i]))
				{
					i++;
				}
				else if (strExpression[i] == '(' || strExpression[i] == ')' ||
						 strExpression[i] == 'x')
				{
					expression.Add(strExpression[i]);
					i++;
				}
				else
				{
					i = ExtractOperation(strExpression, i, out Operation operation);
					expression.Add(operation);
				}
			}

			return expression;
		}

		private int ExtractNumber(string strExpression, int i, out double number)
		{
			string str = "";
			while (i < strExpression.Length &&
				 (char.IsDigit(strExpression[i]) || strExpression[i] == '.' || strExpression[i] == ','))
			{
				str += strExpression[i];
				i++;
			}

			number = ConvertToDouble(str);
			return i;
		}

		private double ConvertToDouble(string strNumber)
		{
			return double.Parse(strNumber, System.Globalization.CultureInfo.InvariantCulture);
		}

		private int ExtractOperation(string strExpression, int i, out Operation operation)
		{
			string element = "";
			bool isAlhpabetic = char.IsLetter(strExpression[i]);    //тут я подсмотрел(гениальная переменная), 
																	//но мне это пока не понадобится
			while (i < strExpression.Length
				&& !char.IsDigit(strExpression[i])
				&& !char.IsWhiteSpace(strExpression[i])
				&& strExpression[i] != '(' || strExpression[i] != ')'
				&& ((isAlhpabetic && char.IsLetter(strExpression[i]))
					|| (!isAlhpabetic && !char.IsLetter(strExpression[i]))))
			{
				element += strExpression[i];
				i++;
			}

			switch(element)
			{
				case "+": 
					operation = new Plus();
					break;
				case "-":
					operation = new Minus();
					break;
				case "*":
					operation = new Multiply();
					break;
				case "/":
					operation = new Divide();
					break;
				case "^":
					operation = new Power();
					break;
				default:
					throw new Exception("Unknown operation");
			}

			return i;
		}
	}
}
