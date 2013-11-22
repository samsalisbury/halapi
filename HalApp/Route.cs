using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HalApp
{
	public class Route
	{
		public string Name { get; set; }
		public IList<Route> Children { get; set; }
		public IHttpHandler Handler { get; set; }

		public static Route BuildRoots()
		{
			var root = new Route();

			var types = Assembly.GetExecutingAssembly().DefinedTypes.ToList();
			var handlers = types.Where(IsHandler).ToList();

			foreach (var h in handlers)
			{
				var path =
					string.Format("{0}.{1}", h.Namespace, h.Name)
						.Replace("HalApp.Resources.", "")
						.Replace(".", "/")
						.Replace(h.Name, "");


				//f(types.Where(t => t.Name == ))
				

				Console.WriteLine("\"{0}\"", path);
			}

			return null;
		}

		private static bool IsHandler(Type t)
		{
			return typeof (IHttpHandler).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract;
		}

		public Route Find(string method, string path)
		{
			if (path.Length == 0)
				return this;

			var route = Children.SingleOrDefault(r => r.Name == Pop(ref path));

			if (route == null)
				return null;

			return route.Find(method, path);
		}

		static string Pop(ref string path)
		{
			var returnable = path.Split(new[] {'/'}, 2)[0];
			path = path.Substring(returnable.Length + 1);

			return returnable;
		}
	}
}