namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Класс, представляющий тип произведения.
    /// </summary>
    public class DbCompositionType
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор типа произведения.
        /// </summary>
        public required long Id { get; set; }

        /// <summary>
        /// Возвращает или задает название типа произведения.
        /// </summary>
        public required string Name { get; set; }
    }
}
