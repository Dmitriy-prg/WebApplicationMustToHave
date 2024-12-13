namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет интерфейс версии рейтинга.
    /// </summary>
    public interface IRatingVersion
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для версии рейтинга.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Возвращает или задает наименование для версии рейтинга.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или устанавливает ссылку (сайт) для версии рейтинга (необязательно).
        /// </summary>
        public string? Link { get; set; }
    }

    /// <summary>
    /// Представляет объект версии рейтинга.
    /// </summary>
    public class RatingVersion: IRatingVersion, IViewable
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для версии рейтинга.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Возвращает или задает наименование для версии рейтинга.
        /// </summary>
        /// <remarks>Это свойство является обязательным и не может иметь значения null.</remarks>
        public required string Name { get; set; }

        /// <summary>
        /// Возвращает или устанавливает ссылку (сайт) для версии рейтинга (необязательно).
        /// </summary>
        public string? Link { get; set; }

        /// <summary>
        /// Получает строку-представление для версии рейтинга.
        /// </summary>
        public string View { get => Name; }
    }
}
