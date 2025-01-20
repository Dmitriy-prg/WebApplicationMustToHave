using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Представляет собой объем произведения.
    /// </summary>
    public class DbVolume
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор объема.
        /// </summary>
        public required long Id { get; set; }

        /// <summary>
        /// Возвращает или устанавливает единицу измерения объема.
        /// </summary>
        public required DbMeasureUnit Unit { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение объема.
        /// </summary>
        public required int Value { get; set; }

        /// <summary>
        /// Возвращает или задает уникальный идентификатор единицы измерения.
        /// </summary>
        public long? DbMeasureUnitId { get; set; }
    }
}
