using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HalApp.Console
{
	using Console = System.Console;

	class Program
	{
		static void Main(string[] args)
		{
			var input = string.Empty;

			while (input != "exit")
			{
				input = Console.ReadLine();

				Act(input);
			}
		}

		static void Act(string input)
		{
			
		}
	}
}
