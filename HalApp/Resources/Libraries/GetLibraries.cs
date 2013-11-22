using System.Collections.Generic;

namespace HalApp.Resources.Libraries
{
	public class GetLibraries : IGet<IList<Entities.Library>>
	{
		public IList<Entities.Library> Get(dynamic args = null)
		{
			return new List<Entities.Library>
			{
				new Entities.Library {Name = "Mold Library"},
				new Entities.Library {Name = "Liverpool Library"},
				new Entities.Library {Name = "Haringey Library"}
			};
		}
	}
}