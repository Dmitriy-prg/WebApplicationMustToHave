namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет интерфейс рейтинга, со значением типа T and версией типа R.
    /// </summary>
    /// <typeparam name="T">Тип значения рейтинга.</typeparam>
    /// <typeparam name="R">Тип версии рейтинга, который должен реализовывать интерфейс IRatingVersion.</typeparam>
    public interface IRating<T, R> where R : IRatingVersion
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для рейтинга.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Возвращает или задает версию рейтинга.
        /// </summary>
        public R Version { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение рейтинга.
        /// </summary>
        public T Value { get; set; }
    }

    /// <summary>
    /// Представляет объект версии рейтинга.
    /// </summary>
    public class Rating: IRating<double, IRatingVersion>, IViewable
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор для рейтинга.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Возвращает или задает версию рейтинга.
        /// </summary>
        /// <remarks>Это свойство является обязательным и не может иметь значения null.</remarks>
        public required IRatingVersion Version { get; set; }

        /// <summary>
        /// Возвращает или устанавливает значение рейтинга. (необязательно).
        /// </summary>
        /// <remarks>Это свойство является обязательным и не может иметь значения null.</remarks>
        public required double Value { get; set; }

        /// <summary>
        /// Получает строку-представление рейтинга.
        /// </summary>
        public string View { get => Version.Name + ": " + Value; }
    }
}
