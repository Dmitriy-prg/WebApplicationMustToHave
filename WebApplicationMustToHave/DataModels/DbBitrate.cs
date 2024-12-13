namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Представляет собой общий интерфейс битрейта со значением типа T и единицей измерения типа M.
    /// </summary>
    /// <typeparam name="T">Тип значения объема.</typeparam>
    /// <typeparam name="M">Тип единицы измерения, который должен реализовывать интерфейс IDbMeasureUnit.</typeparam>
    public interface IDbBitrate<T, M> where M : IDbMeasureUnit
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

        /// <summary>
        /// Возвращает или задает уникальный идентификатор единицы измерения.
        /// </summary>
        public uint? DbMeasureUnitId { get; set; }
    }

    /// <summary>
    /// Представляет собой объект битрейта. Реализует интерфейс IDbBitrate.
    /// </summary>
    public class DbBitrate : IDbBitrate<uint, DbMeasureUnit>
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор битрейта.
        /// </summary>
        public required uint Id { get; set; }

        /// <summary>
        /// Возвращает или устанавливает единицу измерения битрейта.
        /// </summary>
        public required DbMeasureUnit Unit { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение битрейта.
        /// </summary>
        public required uint Value { get; set; }

        /// <summary>
        /// Возвращает или задает уникальный идентификатор единицы измерения.
        /// </summary>
        public uint? DbMeasureUnitId { get; set; }
    }
}
