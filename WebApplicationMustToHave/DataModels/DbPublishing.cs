using System.Xml.Linq;
using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Представляет собой издательскую организацию.
    /// </summary>
    public class DbPublishing : IEntity
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
    }
}
