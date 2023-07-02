namespace MDL.Interfaces
{
    /// <summary>
    ///     Интерфейс, определяющий поведение репозиториев
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        ///     Свойство, предоставляющее общий перечень сущностей
        /// </summary>
        IEnumerable<T> All { get; }
        /// <summary>
        ///     Метод, добавляющий сущность в БД
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Add(T entity);
    }
}
