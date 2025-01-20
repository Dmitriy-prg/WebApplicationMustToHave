namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Представляет объект разрешение.
    /// </summary>
    public class DbResolution
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор разрешения.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Возвращает или устанавливает высоту разрешения.
        /// </summary>
        public required int Height { get; set; }

        /// <summary>
        /// Возвращает или устанавливает ширину разрешения.
        /// </summary>
        public required int Width { get; set; }
    }
}
