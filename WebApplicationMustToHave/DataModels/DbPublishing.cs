using System.Xml.Linq;

namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Представляет собой интерфейс издательской организации.
    /// </summary>
    public interface IDbPublishing
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для издательства.
        /// </summary>
        public uint Id { get; set; }

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
    /// Представляет собой издательскую организацию. Реализует интерфейс IDbPublishing.
    /// </summary>
    public class DbPublishing: IDbPublishing
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для издательства.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Возвращает или задает имя издательства.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Возвращает или задает краткое имя издательства (необязательно).
        /// </summary>
        public string? ShortName { get; set; }
    }
}
