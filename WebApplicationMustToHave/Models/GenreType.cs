namespace WebApplicationMustToHave.Models
{
    public interface IGenresTypes
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для типа жанра.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Возвращает или задает наименование типа жанра.
        /// </summary>
        public string Name { get; set; }
    }

    public class GenreType: IGenresTypes
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
