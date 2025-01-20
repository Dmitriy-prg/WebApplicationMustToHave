namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет интерфейс переплета книги.
    /// </summary>
    public interface IBookBinder
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор переплета.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Возвращает или задает наименование переплета.
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// Представляет переплет книги с общими типами для значения плотности бумаги.
    /// </summary>
    public class BookBinder: IBookBinder
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор переплета.
        /// </summary>
        public required long Id { get; set; }
        /// <summary>
        /// Возвращает или задает наименование переплета.
        /// </summary>
        public required string Name { get; set; }
    }
}
