using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InterceptorDemo
{
	public class CallLogger : IInterceptor
	{
		TextWriter _output;

		public CallLogger(TextWriter output)
		{
			_output = output;
		}

		public void Intercept(IInvocation invocation)
		{
			//_output.Write("Calling method {0} with parameters {1}... ",
			//  invocation.Method.Name,
			//  string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

			//invocation.Proceed();

			//_output.WriteLine("Done: result was {0}.", invocation.ReturnValue);

			_output.Write("Calling method {0} with parameters {1}... ",
			  invocation.Method.Name,
			  string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

			try
			{
				invocation.Proceed();
				_output.WriteLine("Done: result was {0}.", invocation.ReturnValue);
			}
			catch (Exception ex)
			{
				_output.WriteLine($"Oops! Error: {ex.Message}, StackTrace {ex.StackTrace}");
				throw;
			}
		}
	}
}
