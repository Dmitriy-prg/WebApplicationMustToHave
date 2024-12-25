namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет разрешение с общим типом для высоты и ширины.
    /// </summary>
    /// <typeparam name="T">Общий тип высоты и ширины.</typeparam>
    public interface IResolution<T>
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор разрешения.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Возвращает или устанавливает высоту разрешения.
        /// </summary>
        public T Height { get; set; }

        /// <summary>
        /// Возвращает или устанавливает ширину разрешения.
        /// </summary>
        public T Width { get; set; }
    }

    /// <summary>
    /// Представляет разрешение с общим типом для высоты и ширины.
    /// </summary>
    public class Resolution: IResolution<uint>, IViewable
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор разрешения.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Возвращает или устанавливает высоту разрешения.
        /// </summary>
        public required uint Height { get; set; }

        /// <summary>
        /// Возвращает или устанавливает ширину разрешения.
        /// </summary>
        public required uint Width { get; set; }

        /// <summary>
        /// Получает строку-представление разрешения.
        /// </summary>
        public string View { get => Width + " X " + Height; }
    }
}
