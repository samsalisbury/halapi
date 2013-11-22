using HalApp.Resources.Libraries;
using NUnit.Framework;
using Shouldly;

namespace HalApp.UnitTests
{
	public class GetLibrariesTests
	{
		public class when_calling_get_libraries
		{
			[Test]
			public void it_returns_all_the_libraries()
			{
				var getter = new GetLibraries();

				var result = getter.Get();

				result.Count.ShouldBe(3);
			}
		}
	}
}