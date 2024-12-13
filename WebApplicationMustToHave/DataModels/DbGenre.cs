using System.Xml.Linq;

namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Представляет интерфейс жанра, со значением типа T.
    /// </summary>
    /// <typeparam name="T">Тип значения жанра.</typeparam>
    public interface IDbGenre<T> where T : class
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для жанра.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Возвращает или задает тип жанра.
        /// </summary>
        public DbGenreType GenreType { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение жанра.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Возвращает или задает уникальный идентификатор типа жанра.
        /// </summary>
        public uint DbGenreTypeId { get; set; }
    }

    /// <summary>
    /// Представляет объект жанра, реализует интерфейс IDbGenre.
    /// </summary>
    public class DbGenre: IDbGenre<string>
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для жанра.
        /// </summary>
        public uint Id { get; set; }

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
        public required uint DbGenreTypeId { get; set; }
    }
}
