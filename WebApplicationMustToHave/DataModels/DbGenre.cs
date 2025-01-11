using System.Xml.Linq;

namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Представляет жанр произведения.
    /// </summary>
    public class DbGenre
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для жанра.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Возвращает или задает тип жанра.
        /// </summary>
        public required DbGenreType GenreType { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение жанра.
        /// </summary>
        public required string Value { get; set; }

        /// <summary>
        /// Возвращает или задает уникальный идентификатор типа жанра.
        /// </summary>
        public required long DbGenreTypeId { get; set; }
    }
}
