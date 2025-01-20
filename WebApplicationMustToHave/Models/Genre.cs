using System.Xml.Linq;

namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет интерфейс жанра, со значением типа T.
    /// </summary>
    /// <typeparam name="T">Тип значения жанра.</typeparam>
    public interface IGenre<T>
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для жанра.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Возвращает или задает тип жанра.
        /// </summary>
        public GenreType GenreType { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение жанра.
        /// </summary>
        public T Value { get; set; }
    }

    /// <summary>
    /// Представляет объект жанра, реализует интерфейс IGenre.
    /// </summary>
    public class Genre: IGenre<string>, IViewable
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для жанра.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Возвращает или задает тип жанра.
        /// </summary>
        public required GenreType GenreType { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение жанра.
        /// </summary>
        public required string Value { get; set; }

        /// <summary>
        /// Получает строку-представление жанра.
        /// </summary>
        public string View { get => Value; }
    }
}
