namespace HalApp
{
	public interface IRequestHandler
	{
	}

	public interface IGet<out TEntity> : IRequestHandler
	{
		TEntity Get(dynamic args = null);
	}

	public interface IGet<out TEntity, TId> : IGet<TEntity>
	{
		TId Id { get; set; }
	}
}