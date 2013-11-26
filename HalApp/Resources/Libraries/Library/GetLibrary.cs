namespace HalApp.Resources.Libraries.Library
{
	public class GetLibrary : IGet<Entities.Library, int>
	{
		public int Id { get; set; }

		public Entities.Library Get(dynamic args = null)
		{
			return FakeData.Libraries[Id];
		}
	}
}