using System.Xml.Linq;

namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет интерфейс аудиокниги с общими типом для значения плотности бумаги.
    /// </summary>
    public interface IAudioBook<T>
    {
        /// <summary>
        /// Возвращает или задает список авторов книги (необязательно).
        /// </summary>
        public List<IPerson>? Authors { get; set; }

        /// <summary>
        /// Возвращает или задает исполнителя (необязательно).
        /// </summary>
        public IPerson? Performer { get; set; }

        /// <summary>
        /// Возвращает или устанавливает издательство аудиокниги (необязательно).
        /// </summary>
        public IPublishing? Publishing { get; set; }

        /// <summary>
        /// Возвращает или устанавливает битрейт аудиокниги (необязательно).
        /// </summary>
        public IBitrate<T, IMeasureUnit>? Bitrate { get; set; }
    }

    /// <summary>
    /// Представляет интерфейс аудиокниги с общими типом для значения плотности бумаги.
    /// </summary>
    public class AudioBook : Composition, IAudioBook<uint>, IViewable
    {
        /// <summary>
        /// Возвращает или задает список авторов книги (необязательно).
        /// </summary>
        public List<IPerson>? Authors { get; set; }

        /// <summary>
        /// Возвращает или задает исполнителя (необязательно).
        /// </summary>
        public IPerson? Performer { get; set; }

        /// <summary>
        /// Возвращает или устанавливает издательство аудиокниги (необязательно).
        /// </summary>
        public IPublishing? Publishing { get; set; }

        /// <summary>
        /// Возвращает или устанавливает битрейт аудиокниги (необязательно).
        /// </summary>
        public IBitrate<uint, IMeasureUnit>? Bitrate { get; set; }

        /// <summary>
        /// Получает строку-представление аудиокниги.
        /// </summary>
        public string View { get => "Аудиокнига " + Name + ", исполнитель: " + Performer ?? "неизвестен"; }
    }
}
