using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HalApp
{
	public class Route
	{
		public string Name { get; set; }
		public ISet<Route> Children { get; set; }
		public Type Handler { get; set; }

		public static Route BuildRoots()
		{
			var root = new Route();
			var types = Assembly.GetExecutingAssembly().DefinedTypes.ToList();
			var handlers = types.Where(IsHandler).ToList();

			foreach (var handler in handlers)
			{
				var path = ExtractPath(handler);

				root.AddChildren(path, handler);
			}

			return root;
		}

		public void AddChildren(Stack<string> path, Type handler)
		{
			if (path.Count == 0)
			{
				Handler = handler;
			}
			else
			{
				var pathPart = path.Pop();

				if (!HasChild(pathPart))
					Children.Add(new Route {Name = pathPart});

				Children.Single(c => c.Name == pathPart).AddChildren(path, handler);
			}
		}

		private bool HasChild(string name)
		{
			return Children.Any(c => c.Name == name);
		}

		private static bool IsHandler(Type t)
		{
			return typeof(IHttpHandler).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract;
		}

		private static Stack<string> ExtractPath(Type handler)
		{
			return new Stack<string>(
				string.Format("{0}.{1}", handler.Namespace, handler.Name)
					.Replace("HalApp.Resources.", "")
					.Replace(".", "/")
					.Replace(handler.Name, "")
					.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries).Reverse());
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