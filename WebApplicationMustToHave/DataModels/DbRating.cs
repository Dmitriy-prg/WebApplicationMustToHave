namespace WebApplicationMustToHave.DataModels
{
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
