namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет песню с общими типами для единицы измерения и версии рейтинга.
    /// </summary>
    /// <typeparam name="T">Тип значения.</typeparam>
    /// <typeparam name="M">Тип единицы измерения, который должен реализовывать IMeasureUnit.</typeparam>
    public interface ISong<T, M>
        where M : IMeasureUnit
    {
        /// <summary>
        /// Возвращает или задает список исполнителей для песни (необязательно).
        /// </summary>
        public List<IPerson>? Performers { get; set; }

        /// <summary>
        /// Возвращает или задает список авторов песни (необязательно).
        /// </summary>
        public List<IPerson>? Authors { get; set; }

        /// <summary>
        /// Возвращает или устанавливает список композиторов для песни (необязательно).
        /// </summary>
        public List<IPerson>? Composers { get; set; }

        /// <summary>
        /// Возвращает или устанавливает битрейт песни (необязательно).
        /// </summary>
        public IBitrate<T, M>? Bitrate { get; set; }
    }

    /// <summary>
    /// Представляет композицию с общими типами для единицы измерения и версии рейтинга. Реализует интерфейсы ISong и IViewable.
    /// </summary>
    /// <typeparam name="T">Тип значения.</typeparam>
    /// <typeparam name="M">Тип единицы измерения, который должен реализовывать IMeasureUnit.</typeparam>
    /// <typeparam name="R">Тип версии рейтинга, который должен реализовывать IRatingVersion.</typeparam>
    public class Song : Composition, ISong<uint, IMeasureUnit>, IViewable
    {
        /// <summary>
        /// Возвращает или задает список исполнителей для песни (необязательно).
        /// </summary>
        public List<IPerson>? Performers { get; set; }

        /// <summary>
        /// Возвращает или задает список авторов песни (необязательно).
        /// </summary>
        public List<IPerson>? Authors { get; set; }

        /// <summary>
        /// Возвращает или устанавливает список композиторов для песни (необязательно).
        /// </summary>
        public List<IPerson>? Composers { get; set; }

        /// <summary>
        /// Возвращает или устанавливает битрейт песни (необязательно).
        /// </summary>
        public IBitrate<uint, IMeasureUnit>? Bitrate { get; set; }

        /// <summary>
        /// Получает строку-представление песни.
        /// </summary>
        public string View { get => "Песня " + Name + " " + YearBirth ?? ""; }
    }
}
