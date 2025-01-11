namespace WebApplicationMustToHave.DataModels
{
    ///// <summary>
    ///// Представляет интерфейс версии рейтинга.
    ///// </summary>
    //public interface IDbRatingVersion<T> where T : class?
    //{
    //    /// <summary>
    //    /// Возвращает или задает уникальный идентификатор для версии рейтинга.
    //    /// </summary>
    //    public uint Id { get; set; }

    //    /// <summary>
    //    /// Возвращает или задает наименование для версии рейтинга.
    //    /// </summary>
    //    public string Name { get; set; }

    //    /// <summary>
    //    /// Возвращает или устанавливает ссылку (сайт) для версии рейтинга (необязательно).
    //    /// </summary>
    //    public T? Link { get; set; }
    //}

    /// <summary>
    /// Представляет объект версии рейтинга.
    /// </summary>
    public class DbRatingVersion
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для версии рейтинга.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Возвращает или задает наименование для версии рейтинга.
        /// </summary>
        /// <remarks>Это свойство является обязательным и не может иметь значения null.</remarks>
        public required string Name { get; set; }

        /// <summary>
        /// Возвращает или устанавливает ссылку (сайт) для версии рейтинга (необязательно).
        /// </summary>
        public string? Link { get; set; }
    }
}
