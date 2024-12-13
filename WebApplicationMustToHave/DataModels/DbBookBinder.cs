namespace WebApplicationMustToHave.DataModels
{
    public interface IDbBookBinder
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор переплета.
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// Возвращает или задает наименование переплета.
        /// </summary>
        public string Name { get; set; }
    }

    public class DbBookBinder: IDbBookBinder
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор переплета.
        /// </summary>
        public required uint Id { get; set; }
        /// <summary>
        /// Возвращает или задает наименование переплета.
        /// </summary>
        public required string Name { get; set; }
    }
}
