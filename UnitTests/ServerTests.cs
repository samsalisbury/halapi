using System.Collections;
using System.Collections.Generic;
using HalApp.Entities;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace HalApp.UnitTests
{
	public class ServerTests
	{
		public class when_calling_get_root
		{
			[Test]
			public void it_returns_the_root_json()
			{
				var server = new Server();
				var result = server.Get("/");

				var deserialised = JsonConvert.DeserializeObject<Resource>(result);
				var entity = JsonConvert.DeserializeObject<Root>(deserialised.Content.ToString());

				entity.Title.ShouldBe("This is the root!");
			}
		}

		public class when_calling_get_libraries
		{
			[Test]
			public void it_should_return_a_list_of_libraries()
			{
				var server = new Server();
				var result = server.Get("/libraries");

				var deserialised = JsonConvert.DeserializeObject<Resource>(result);
				var entity = JsonConvert.DeserializeObject<IList<Library>>(deserialised.Content.ToString());

				entity.Count.ShouldBe(3);
			}
		}
	}
}