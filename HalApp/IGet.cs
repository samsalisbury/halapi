using System.Collections.Generic;

namespace HalApp
{
	public interface IRequestHandler
	{
		
	}

	public interface IGet : IRequestHandler
	{
		object Get(dynamic agrs = null);
	}

	public interface IGet<out TEntity> : IGet
	{
		new TEntity Get(dynamic args = null);
	}

	public interface IGet<out TEntity, TId> : IGet<TEntity>
	{
		TId Id { get; set; }
	}

	public interface IGetList<TEntity> : IGet
	{
		new IList<TEntity> Get(dynamic args = null);
	}

	public abstract class Getter<TEntity> : IGet<TEntity>
	{
		public abstract TEntity Get(dynamic args = null);

		object IGet.Get(dynamic agrs)
		{
			return Get(agrs);
		}
	}

	public abstract class Getter<TEntity, TId> : Getter<TEntity>, IGet<TEntity, TId>
	{
		public TId Id { get; set; }
	}
}