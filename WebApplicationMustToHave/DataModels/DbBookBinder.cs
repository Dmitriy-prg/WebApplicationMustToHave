using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.DataModels
{
    ///// <summary>
    ///// Представляет собой переплет книги.
    ///// </summary>
    //public interface IDbBookBinder
    //{
    //    /// <summary>
    //    /// Возвращает или задает уникальный идентификатор переплета.
    //    /// </summary>
    //    public uint Id { get; set; }
    //    /// <summary>
    //    /// Возвращает или задает наименование переплета.
    //    /// </summary>
    //    public string Name { get; set; }
    //}

    /// <summary>
    /// Представляет собой переплет книги.
    /// </summary>
    public class DbBookBinder : IEntity
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
