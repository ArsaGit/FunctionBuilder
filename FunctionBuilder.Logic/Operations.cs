using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionBuilder.Logic
{
	public class Parenthesis
	{
		public bool IsOpening { get; }
		public int Priority = 0;

		public Parenthesis(string element)
		{
			IsOpening = element.Equals("(");
		}

		public override string ToString()
		{
			return IsOpening ? "(" : ")";
		}
	}

	public abstract class Operation
	{
		public abstract string Name { get; }
		public abstract int Priority { get; }
		public abstract int NumberOfOperands { get; }
		public abstract bool IsPostfix { get; }
		public abstract bool IsPrefix { get; }

		public abstract double Execute(double[] @params);

		public override string ToString()
		{
			return Name;
		}
	}

	public class Plus : Operation
	{
		public override string Name => "+";
		public override int Priority => 1;
		public override int NumberOfOperands => 2;
		public override bool IsPostfix => false;
		public override bool IsPrefix => false;

		public override double Execute(double[] @params)
		{
			if (@params.Length != NumberOfOperands)
				throw new ArgumentException("Неверное кол-во аргументов");

			return @params[0] + @params[1];
		}
	}

	public class Minus : Operation
	{
		public override string Name => "-";
		public override int Priority => 1;
		public override int NumberOfOperands => 2;
		public override bool IsPostfix => false;
		public override bool IsPrefix => false;

		public override double Execute(double[] @params)
		{
			if (@params.Length != NumberOfOperands)
				throw new ArgumentException("Неверное кол-во аргументов");

			return @params[0] - @params[1];
		}
	}

	public class Multiply : Operation	//times
	{
		public override string Name => "*";
		public override int Priority => 2;
		public override int NumberOfOperands => 2;
		public override bool IsPostfix => false;
		public override bool IsPrefix => false;

		public override double Execute(double[] @params)
		{
			if (@params.Length != NumberOfOperands)
				throw new ArgumentException("Неверное кол-во аргументов");

			return @params[0] * @params[1];
		}
	}

	public class Divide : Operation		//obelus
	{
		public override string Name => "/";
		public override int Priority => 2;
		public override int NumberOfOperands => 2;
		public override bool IsPostfix => false;
		public override bool IsPrefix => false;

		public override double Execute(double[] @params)
		{
			if (@params.Length != NumberOfOperands)
				throw new ArgumentException("Неверное кол-во аргументов");

			return @params[0] / @params[1];
		}
	}

	public class Power : Operation
	{
		public override string Name => "^";
		public override int Priority => 3;
		public override int NumberOfOperands => 2;
		public override bool IsPostfix => false;
		public override bool IsPrefix => false;

		public override double Execute(double[] @params)
		{
			if (@params.Length != NumberOfOperands)
				throw new ArgumentException("Неверное кол-во аргументов");

			return Math.Pow(@params[0],@params[1]);
		}
	}
}
