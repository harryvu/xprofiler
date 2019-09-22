using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterceptorDemo
{
	public interface ICalculator
	{
		int Add(int a, int b);
		int Subtract(int a, int b);
		int Multiply(int a, int b);
		int Divide(int a, int b);
	}

	[Intercept(typeof(CallLogger))]
	public class Calculator : ICalculator
	{
		public int Add(int a, int b)
		{
			return a + b;
		}

		public int Subtract(int a, int b)
		{
			return a - b;
		}

		public int Multiply(int a, int b)
		{
			return a * b;
		}

		public int Divide(int a, int b)
		{
			return a / b;
		}
	}
}
