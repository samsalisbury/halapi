using HalApp.Resources;
using NUnit.Framework;
using Shouldly;

namespace HalApp.UnitTests
{
    public class GetRootTests
    {
	    public class when_calling_get_root
	    {
			[Test]
		    public void it_returns_the_root_entity()
		    {
			    var getter = new GetRoot();

			    var result = getter.Get();

			    result.ShouldNotBe(null);
		    }
	    }
    }
}
