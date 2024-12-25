using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Представляет собой общий интерфейс объема со значением типа T и единицей измерения типа M.
    /// </summary>
    /// <typeparam name="T">Тип значения объема.</typeparam>
    /// <typeparam name="M">Тип единицы измерения, который должен реализовывать интерфейс IMeasureUnit.</typeparam>
    public interface IDbVolume<T, M> where M : IDbMeasureUnit
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор объема.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Возвращает или устанавливает единицу измерения объема.
        /// </summary>
        public M Unit { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение объема.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Возвращает или задает уникальный идентификатор единицы измерения.
        /// </summary>
        public uint? DbMeasureUnitId { get; set; }
    }

    /// <summary>
    /// Представляет собой реализацию интерфейса IDbVolume с целым значением и единицей измерения IMeasureUnit.
    /// </summary>
    public class DbVolume: IDbVolume<int, DbMeasureUnit>
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор объема.
        /// </summary>
        public required uint Id { get; set; }

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
        public uint? DbMeasureUnitId { get; set; }
    }
}
