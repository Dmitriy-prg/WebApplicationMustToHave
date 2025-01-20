namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Класс, представляющий тип жанра.
    /// </summary>
    public class DbGenreType
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для типа жанра.
        /// </summary>
        public required long Id { get; set; }
        /// <summary>
        /// Возвращает или задает наименование типа жанра.
        /// </summary>
        public required string Name { get; set; }
    }
}
