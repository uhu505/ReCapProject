namespace Core.Utilities.Results.Abstract
{
    public interface IDataResult<out TEntity> : IResult
    {
        TEntity Data { get; }
    }
}