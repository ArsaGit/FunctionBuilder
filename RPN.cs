using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionBuilder
{
	public class RPN
	{
		public object[] ConvertToRPN(string expression)
		{
			List<object> listExpression = ParseExpression(expression);

			Stack<object> rpn = new Stack<object>();
			Stack<object> signs = new Stack<object>();

			foreach (object element in listExpression)
			{
				if (element is double || element is Argument)   //если число или аргумент
				{
					rpn.Push(element);  //ложим его в главный стек
				}
				else if (element is Parenthesis parenthesis)    //если скобка
				{
					if (parenthesis.IsOpening)   //если открывающая скобка
					{
						signs.Push(parenthesis);    //ложим в побочный стек
					}
					else    //если закрывающая скобка
					{
						while (signs.Count != 0 && signs.Peek() is Operation)   //то пока верхним элементом не будет открывающая строка
						{
							rpn.Push(signs.Pop());  //перемещаем операции в главный стек
						}
						signs.Pop();    //выталкиваем открывающую скобку
					}
				}
				else if (element is Operation element1)	//если операция
				{
					while (signs.Count != 0 &&	//пока стек не пустой
						signs.Peek() is Operation operation	//пока на верху побочного стека операция и 
						&& (operation.Priority >= element1.Priority))   //её приоритет равен или больше, чем у element
					{
						rpn.Push(signs.Pop());	//выталкиваем из побочной в главную
					}
					signs.Push(element);	//помещаем в операцию в побочный стек
				}
			}

			while(signs.Count != 0)
			{
				rpn.Push(signs.Pop());
			}

			return ToRpnArray(rpn);
		}

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
				else if (strExpression[i] == '(' || strExpression[i] == ')')
				{
					expression.Add(new Parenthesis(strExpression[i].ToString()));
					i++;
				}
				else
				{
					i = ExtractOperationOrArgument(strExpression, i, out object element);
					expression.Add(element);
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

		private int ExtractOperationOrArgument(string strExpression, int i, out object element)
		{
			string str = "";
			bool isAlhpabetic = char.IsLetter(strExpression[i]);    //тут я подсмотрел(гениальная переменная), 
																	//но мне это пока не понадобится
			while (i < strExpression.Length
				&& !char.IsDigit(strExpression[i])
				&& !char.IsWhiteSpace(strExpression[i])
				&& strExpression[i] != '(' && strExpression[i] != ')'
				&& ((isAlhpabetic && char.IsLetter(strExpression[i]))
					|| (!isAlhpabetic && !char.IsLetter(strExpression[i]))))
			{
				str += strExpression[i];
				i++;
			}

			switch (str)
			{
				case "+":
					element = new Plus();
					break;
				case "-":
					element = new Minus();
					break;
				case "*":
					element = new Multiply();
					break;
				case "/":
					element = new Divide();
					break;
				case "^":
					element = new Power();
					break;
				case "x":
					element = new Argument();
					break;
				default:
					throw new Exception("Unknown operation");
			}

			return i;
		}

		private object[] ToRpnArray(Stack<object> stackRpn)
		{
			object[] rpnArray = new object[stackRpn.Count];
			for (int i = rpnArray.Length - 1; i >= 0; i--)
				rpnArray[i] = stackRpn.Pop();
			return rpnArray;
		}
	}
}
