using System.Xml.Linq;

namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет собой издательскую организацию.
    /// </summary>
    public interface IPublishing
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для издательства.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Возвращает или задает имя издательства.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает краткое имя издательства (необязательно).
        /// </summary>
        public string? ShortName { get; set; }
    }

    /// <summary>
    /// Представляет собой издательскую организацию.
    /// </summary>
    public class Publishing: IPublishing, IViewable
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для издательства.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Возвращает или задает имя издательства.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Возвращает или задает краткое имя издательства (необязательно).
        /// </summary>
        public string? ShortName { get; set; }

        /// <summary>
        /// Получает строку-представление издательства.
        /// </summary>
        public string View { get => ShortName ?? Name; }
    }
}
