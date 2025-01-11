using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Представляет собой объект битрейта.
    /// </summary>
    public class DbBitrate
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор битрейта.
        /// </summary>
        public required long Id { get; set; }

        /// <summary>
        /// Возвращает или устанавливает единицу измерения битрейта.
        /// </summary>
        public required DbMeasureUnit Unit { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение битрейта.
        /// </summary>
        public required int Value { get; set; }

        /// <summary>
        /// Возвращает или задает уникальный идентификатор единицы измерения.
        /// </summary>
        public int? DbMeasureUnitId { get; set; }
    }
}
