using HalApp.Resources;
using HalApp.Resources.Libraries;
using HalApp.Resources.Libraries.Library;
using NUnit.Framework;
using Shouldly;

namespace HalApp.UnitTests
{
	public class RouteTests
	{
		[Test]
		public void it_finds_the_root_route()
		{
			var routes = Route.BuildRoutes();

			routes.Find("GET", "/").HandlerType.FullName.ShouldBe(typeof (GetRoot).FullName);
		}

		[Test]
		public void it_finds_a_collection_route()
		{
			var routes = Route.BuildRoutes();

			routes.Find("GET", "/libraries").HandlerType.FullName.ShouldBe(typeof(GetLibraries).FullName);
		}

		[Test]
		public void it_finds_an_item_route()
		{
			var routes = Route.BuildRoutes();

			routes.Find("GET", "/libraries/2'").HandlerType.FullName.ShouldBe(typeof(GetLibrary).FullName);
		}
	}
}