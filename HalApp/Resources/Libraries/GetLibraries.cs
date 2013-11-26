using System.Collections.Generic;

namespace HalApp.Resources.Libraries
{
	public class GetLibraries : IGet<IList<Entities.Library>>
	{
		public IList<Entities.Library> Get(dynamic args = null)
		{
			return FakeData.Libraries;
		}
	}
}