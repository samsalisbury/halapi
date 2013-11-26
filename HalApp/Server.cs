using Newtonsoft.Json;

namespace HalApp
{
	public class Server
	{
		public Server(RequestResolver resolver)
		{
			_resolver = resolver;
		}

		private readonly RequestResolver _resolver;

		public string Get(string path)
		{
			var handler = _resolver.Resolve("GET", path);
			var result = handler.GetType().GetMethod("Get").Invoke(handler, new[] {new object()});
			var resource = new Resource {Content = result};

			return JsonConvert.SerializeObject(resource);
		}
	}
}