using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Представляет класс единиц измерения.
    /// </summary>
    public class DbMeasureUnit : IViewable, IEntity
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор единицы измерения.
        /// </summary>
        /// <remarks>Это свойство является обязательным и не может иметь значения null.</remarks>
        public required long Id { get; set; }

        /// <summary>
        /// Возвращает или задает наименование единицы измерения.
        /// </summary>
        /// <remarks>Это свойство является обязательным и не может иметь значения null.</remarks>
        public required string Name { get; set; }

        /// <summary>
        /// Возвращает или задает краткое наименование единицы измерения.
        /// </summary>
        /// <remarks>Это свойство является обязательным и не может иметь значения null.</remarks>
        public required string ShortName { get; set; }

        /// <summary>
        /// Получает строку-представление единицы измерения.
        /// </summary>
        public string View { get => ShortName == null ? Name : ShortName; }
    }
}
