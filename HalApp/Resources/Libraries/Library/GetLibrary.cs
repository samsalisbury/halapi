namespace HalApp.Resources.Libraries.Library
{
	public class GetLibrary : Getter<Entities.Library, int>
	{
		public new int Id { get; set; }

		public override Entities.Library Get(dynamic args = null)
		{
			return FakeData.Libraries[Id];
		}
	}
}