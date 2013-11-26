using System.Collections.Generic;

namespace HalApp.Resources.Libraries
{
	public class GetLibraries : IGetList<Entities.Library>
	{
		public IList<Entities.Library> Get(dynamic args = null)
		{
			return FakeData.Libraries;
		}

		object IGet.Get(dynamic agrs)
		{
			return Get(agrs);
		}
	}
}