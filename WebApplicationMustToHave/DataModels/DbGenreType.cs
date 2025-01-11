namespace WebApplicationMustToHave.DataModels
{
    ///// <summary>
    ///// Представляет интерфейс типа жанра.
    ///// </summary>
    //public interface IDbGenreType
    //{
    //    /// <summary>
    //    /// Возвращает или задает уникальный идентификатор для типа жанра.
    //    /// </summary>
    //    public uint Id { get; set; }
    //    /// <summary>
    //    /// Возвращает или задает наименование типа жанра.
    //    /// </summary>
    //    public string Name { get; set; }
    //}

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
