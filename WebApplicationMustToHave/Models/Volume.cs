using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет собой общий интерфейс объема со значением типа T и единицей измерения типа M.
    /// </summary>
    /// <typeparam name="T">Тип значения объема.</typeparam>
    /// <typeparam name="M">Тип единицы измерения, который должен реализовывать интерфейс IMeasureUnit.</typeparam>
    public interface IVolume<T, M> where M : IMeasureUnit
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
    }

    /// <summary>
    /// Представляет собой реализацию интерфейса IVolume с целым значением и единицей измерения IMeasureUnit.
    /// </summary>
    public class Volume: IVolume<int, IMeasureUnit>, IViewable
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор объема.
        /// </summary>
        public required uint Id { get; set; }

        /// <summary>
        /// Возвращает или устанавливает единицу измерения объема.
        /// </summary>
        public required IMeasureUnit Unit { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение объема.
        /// </summary>
        public required int Value { get; set; }

        /// <summary>
        /// Получает строку-представление объема.
        /// </summary>
        public string View { get => Value + " " + Unit.ShortName; }
    }
}
