using HalApp.Resources.Libraries.Library;
using NUnit.Framework;
using Shouldly;

namespace HalApp.UnitTests
{
	public class GetLibraryTests
	{
		public class when_calling_get_library
		{
			[Test]
			public void it_returns_the_library()
			{
				var getter = new GetLibrary {LibraryId = 2};
				var result = getter.Get();

				result.Name.ShouldBe("Haringey Library");
			}
		}
	}
}