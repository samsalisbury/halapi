using System.Collections.Generic;

namespace HalApp
{
	public interface IHttpHandler
	{
		
	}

	public interface IGetSingle<T> : IHttpHandler
	{
		T Get(dynamic args = null);
	}

	public interface IGetList<T> : IHttpHandler
	{
		IList<T> Get(dynamic args = null);
	}
}