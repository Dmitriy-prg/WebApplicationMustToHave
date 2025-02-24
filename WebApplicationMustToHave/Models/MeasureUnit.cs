﻿namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет интерфейс единиц измерения.
    /// </summary>
    public interface IMeasureUnit
    {
        /// <summary>
        ///Возвращает или задает уникальный идентификатор единицы измерения.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Возвращает или задает наименование единицы измерения.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает краткое наименование единицы измерения.
        /// </summary>
        public string ShortName { get; set; }
    }

    /// <summary>
    /// Представляет класс единиц измерения, который реализует интерфейс IMeasureUnit.
    /// </summary>
    public class MeasureUnit : IMeasureUnit, IEntity, IViewable
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
        /// Получает строку-представление человека.
        /// </summary>
        public string View { get => ShortName; }
    }
}
