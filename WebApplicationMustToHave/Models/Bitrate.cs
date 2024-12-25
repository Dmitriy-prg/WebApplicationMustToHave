namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет собой общий интерфейс битрейта со значением типа T.
    /// </summary>
    /// <typeparam name="T">Тип значения объема.</typeparam>
    /// <typeparam name="M">Тип единицы измерения, который должен реализовывать интерфейс IMeasureUnit.</typeparam>
    public interface IBitrate<T, M> where M : IMeasureUnit
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор битрейта.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Возвращает или устанавливает единицу измерения битрейта.
        /// </summary>
        public M Unit { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение битрейта.
        /// </summary>
        public T Value { get; set; }
    }

    /// <summary>
    /// Представляет собой объект битрейта.
    /// </summary>
    public class Bitrate : IBitrate<uint, IMeasureUnit>, IViewable
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор битрейта.
        /// </summary>
        public required uint Id { get; set; }

        /// <summary>
        /// Возвращает или устанавливает единицу измерения битрейта.
        /// </summary>
        public required IMeasureUnit Unit { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение битрейта.
        /// </summary>
        public required uint Value { get; set; }

        /// <summary>
        /// Получает строку-представление битрейта.
        /// </summary>
        public string View { get => Value + " " + Unit.ShortName; }
    }
}
