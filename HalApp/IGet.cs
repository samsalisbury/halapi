namespace HalApp
{
	public interface IHttpMethod
	{
		
	}

	public interface IGet<T> : IHttpMethod
	{
		T Get(dynamic args = null);
	}
}