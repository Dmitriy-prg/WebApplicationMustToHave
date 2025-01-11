namespace WebApplicationMustToHave.DataModels
{
    ///// <summary>
    ///// Интерфейс, представляющий тип произведения.
    ///// </summary>
    //public interface IDbCompositionType
    //{
    //    /// <summary>
    //    /// Возвращает или задает уникальный идентификатор типа произведения.
    //    /// </summary>
    //    public uint Id { get; set; }

    //    /// <summary>
    //    /// Возвращает или задает название типа произведения.
    //    /// </summary>
    //    public string Name { get; set; }
    //}

    /// <summary>
    /// Класс, представляющий тип произведения.
    /// </summary>
    public class DbCompositionType
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор типа произведения.
        /// </summary>
        public required long Id { get; set; }

        /// <summary>
        /// Возвращает или задает название типа произведения.
        /// </summary>
        public required string Name { get; set; }
    }
}
