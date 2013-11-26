using System;
using System.Linq;

namespace HalApp
{
	public class RequestResolver
	{
		private readonly Route _root;

		public RequestResolver(Route root)
		{
			_root = root;
		}

		public IRequestHandler Resolve(string method, string path)
		{
			var route = _root.Find(method, path);

			var handler = (IRequestHandler) Activator.CreateInstance(route.HandlerType, null);

			if (!route.IsId)
				return handler;

			var prop = route.HandlerType.GetProperty("Id");
			var idType = prop.PropertyType;
			var idVal = path.Split('/').Last();

			if (idType == typeof (string))
				prop.SetValue(handler, idVal);
			else if(idType == typeof(Int32))
				prop.SetValue(handler, Int32.Parse(idVal));
			else
				throw new NotSupportedException("Only strings or ints can be used as IDs, for the time being.");

			return handler;
		}
	}
}
