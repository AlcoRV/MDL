namespace MDL.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> All { get; }
        void Add(T entity);
    }
}
