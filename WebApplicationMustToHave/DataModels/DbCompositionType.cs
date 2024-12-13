namespace WebApplicationMustToHave.DataModels
{
    public interface IDbCompositionType
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор типа произведения.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Возвращает или задает название типа произведения.
        /// </summary>
        public string Name { get; set; }
    }

    public class DbCompositionType: IDbCompositionType
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор типа произведения.
        /// </summary>
        public required uint Id { get; set; }

        /// <summary>
        /// Возвращает или задает название типа произведения.
        /// </summary>
        public required string Name { get; set; }
    }
}
