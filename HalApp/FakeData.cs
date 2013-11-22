using System.Collections.Generic;

namespace HalApp
{
	public static class FakeData
	{
		public static IList<Entities.Library> Libraries
		{
			get
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
}