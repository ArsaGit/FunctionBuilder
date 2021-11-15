using NUnit.Framework;
using FunctionBuilder.Logic;
using System.Collections.Generic;

namespace FunctionBuilder.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCaseSource(nameof(TestCases))]
		public void RPN_Test(string expression, string result)
		{
			Assert.That(result, Is.EquivalentTo(new RPN(expression).ToString()));
		}

		public static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				yield return new TestCaseData("1+2", "12+");
				yield return new TestCaseData("(1+2)*4+3", "12+4*3+");
				yield return new TestCaseData("3+4*2/(1-5)^2", "342*15-2^/+");
			}
		}
	}
}