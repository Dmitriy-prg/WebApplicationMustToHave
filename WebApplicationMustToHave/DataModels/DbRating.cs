namespace WebApplicationMustToHave.DataModels
{
    ///// <summary>
    ///// Представляет интерфейс рейтинга, со значением типа T and версией типа R.
    ///// </summary>
    ///// <typeparam name="T">Тип значения рейтинга.</typeparam>
    ///// <typeparam name="R">Тип версии рейтинга, который должен реализовывать интерфейс IRatingVersion.</typeparam>
    //public interface IDbRating<T, R> where R : IDbRatingVersion<string?>
    //{
    //    /// <summary>
    //    /// Возвращает или задает уникальный идентификатор для рейтинга.
    //    /// </summary>
    //    public uint Id { get; set; }

    //    /// <summary>
    //    /// Возвращает или задает версию рейтинга.
    //    /// </summary>
    //    public R Version { get; set; }

    //    /// <summary>
    //    /// Возвращает или устанавливает значение рейтинга.
    //    /// </summary>
    //    public T Value { get; set; }

    //    /// <summary>
    //    /// Возвращает или задает уникальный идентификатор для версии рейтинга.
    //    /// </summary>
    //    public uint? DbRatingVersionId { get; set; }
    //}

    /// <summary>
    /// Представляет объект рейтинга.
    /// </summary>
    public class DbRating
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для рейтинга.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Возвращает или задает версию рейтинга.
        /// </summary>
        /// <remarks>Это свойство является обязательным и не может иметь значения null.</remarks>
        public required DbRatingVersion Version { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение рейтинга. (необязательно).
        /// </summary>
        /// <remarks>Это свойство является обязательным и не может иметь значения null.</remarks>
        public required double Value { get; set; }

        /// <summary>
        /// Возвращает или задает уникальный идентификатор для версии рейтинга.
        /// </summary>
        public long? DbRatingVersionId { get; set; }
    }
}
