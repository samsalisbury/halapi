using System.Collections.Generic;
using HalApp.Entities;
using HalApp.Resources;
using HalApp.Resources.Libraries;
using HalApp.Resources.Libraries.Library;
using Newtonsoft.Json;

namespace HalApp
{
	public class Server
	{
		public Server(Route root)
		{
			_root = root;
		}

		private readonly Route _root;

		public string Get(string path)
		{
			Resource resource;

			var route = _root.Find("GET", path);

			if (path == "/")
				resource = new Resource<Root>
				{
					Content = new GetRoot().Get(),
				};
			else if (path == "/libraries")
				resource = new Resource<IList<Library>>
				{
					Content = new GetLibraries().Get()
				};
			else
				resource = new Resource<Library>
				{
					Content = new GetLibrary().Get()
				};

			return JsonConvert.SerializeObject(resource);
		}
	}
}