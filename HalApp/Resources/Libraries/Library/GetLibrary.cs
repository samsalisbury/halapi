namespace HalApp.Resources.Libraries.Library
{
	public class GetLibrary : IGetSingle<Entities.Library>
	{
		public int LibraryId { get; set; }

		public Entities.Library Get(dynamic args = null)
		{
			return FakeData.Libraries[LibraryId];
		}
	}
}
