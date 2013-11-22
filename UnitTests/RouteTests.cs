using HalApp.Resources;
using NUnit.Framework;
using Shouldly;

namespace HalApp.UnitTests
{
	public class RouteTests
	{
		[Test]
		public void it_builds_routes_from_assembly()
		{
			var routes = Route.BuildRoots();

			routes.Find("GET", "/").Handler.ShouldBeTypeOf<GetRoot>();
		}
	}
}
