using System;
using System.Collections.Generic;

namespace FunctionBuilder
{
	class Program
	{
		static void Main(string[] args)
		{
			var IO = new InputOutput();
			var Printer = new Printer();
			string[] dataFunction = IO.ReadFile();
			var function = new Function(dataFunction);
			Printer.Print(function.GetPoints());
		}
	}
}
