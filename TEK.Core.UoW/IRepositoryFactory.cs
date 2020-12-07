namespace TEK.Core.UoW
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> GetRepository<T>() where T : class;
    }
}
