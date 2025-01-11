namespace WebApplicationMustToHave.DataModels
{
    ///// <summary>
    ///// Представляет интерфейс разрешения с общим типом для высоты и ширины.
    ///// </summary>
    ///// <typeparam name="T">Общий тип высоты и ширины.</typeparam>
    //public interface IDbResolution<T>
    //{
    //    /// <summary>
    //    /// Возвращает или задает уникальный идентификатор разрешения.
    //    /// </summary>
    //    public uint Id { get; set; }

    //    /// <summary>
    //    /// Возвращает или устанавливает высоту разрешения.
    //    /// </summary>
    //    public T Height { get; set; }

    //    /// <summary>
    //    /// Возвращает или устанавливает ширину разрешения.
    //    /// </summary>
    //    public T Width { get; set; }
    //}

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
