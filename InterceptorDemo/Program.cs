using Autofac;
using Autofac.Extras.DynamicProxy;
using System;

namespace InterceptorDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<Calculator>().As<ICalculator>().EnableInterfaceInterceptors();
			builder.Register(c => new CallLogger(Console.Out));
			var container = builder.Build();
			var calculator = container.Resolve<ICalculator>();

			try
			{
				calculator.Add(2, 3);
				calculator.Divide(1, 0);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error {ex.Message}. {ex.StackTrace}");
			}
		}
	}
}
