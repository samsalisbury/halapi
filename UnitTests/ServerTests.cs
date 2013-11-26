using System.Collections.Generic;
using HalApp.Entities;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace HalApp.UnitTests
{
	public class ServerTests
	{
		public class when_calling_get_root : with_server
		{
			[Test]
			public void it_returns_the_root_json()
			{
				var result = Server.Get("/");

				var deserialised = JsonConvert.DeserializeObject<Resource>(result);
				var entity = JsonConvert.DeserializeObject<Root>(deserialised.Content.ToString());

				entity.Title.ShouldBe("This is the root!");
			}
		}

		public class when_calling_get_libraries : with_server
		{
			[Test]
			public void it_should_return_a_list_of_libraries()
			{
				var result = Server.Get("/libraries");

				var deserialised = JsonConvert.DeserializeObject<Resource>(result);
				var entity = JsonConvert.DeserializeObject<IList<Library>>(deserialised.Content.ToString());

				entity.Count.ShouldBe(3);
			}
		}

		public class when_calling_get_library : with_server
		{
			[Test]
			public void it_should_return_the_library_details()
			{
				var result = Server.Get("/libraries/2");

				var deserialised = JsonConvert.DeserializeObject<Resource>(result);
				var entity = JsonConvert.DeserializeObject<Library>(deserialised.Content.ToString());

				entity.Name.ShouldBe("Haringey Library");
			}
		}

		public abstract class with_server
		{
			protected Server Server;

			[SetUp]
			public void create_server()
			{
				var resolver = new RequestResolver(Route.BuildRoutes());
				Server = new Server(resolver);
			}
		}
	}
}