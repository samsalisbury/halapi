using System.Collections.Generic;
using HalApp.Entities;
using HalApp.Resources;
using HalApp.Resources.Libraries;
using Newtonsoft.Json;

namespace HalApp
{
	public class Server
	{
		public string Get(string path)
		{
			Resource resource;

			if (path == "/")
				resource = new Resource<Root>
				{
					Content = new GetRoot().Get(),
				};
			else
				resource = new Resource<IList<Library>>
				{
					Content = new GetLibraries().Get()
				};

			return JsonConvert.SerializeObject(resource);
		}
	}
}