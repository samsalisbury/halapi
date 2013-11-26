using HalApp.Entities;

namespace HalApp.Resources
{
	public class GetRoot : Getter<Root>
	{
		public override Root Get(dynamic args = null)
		{
			return new Root
			{
				Title = "This is the root!",
				Desc = "Eventually there will be links to other things you can do from here."
			};
		}
	}
}