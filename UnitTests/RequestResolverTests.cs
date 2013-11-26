using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalApp.Resources;
using HalApp.Resources.Libraries;
using HalApp.Resources.Libraries.Library;
using NUnit.Framework;
using Shouldly;

namespace HalApp.UnitTests
{
	public class RequestResolverTests
	{
		[Test]
		public void it_instantiates_root_handler()
		{
			var root = Route.BuildRoutes();
			var resolver = new RequestResolver(root);

			var handler = resolver.Resolve("GET", "/");

			handler.ShouldBeTypeOf<GetRoot>();
		}

		[Test]
		public void it_instantiates_get_handler()
		{
			var root = Route.BuildRoutes();
			var resolver = new RequestResolver(root);

			var handler = resolver.Resolve("GET", "/libraries");

			handler.ShouldBeTypeOf<GetLibraries>();
		}

		[Test]
		public void it_instantiates_get_handler_with_int32_id()
		{
			var root = Route.BuildRoutes();
			var resolver = new RequestResolver(root);

			var handler = resolver.Resolve("GET", "/libraries/2");

			handler.ShouldBeTypeOf<GetLibrary>();
			((GetLibrary) handler).Id.ShouldBe(2);
		}
	}
}
