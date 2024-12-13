using System.Xml.Linq;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет интерфейс книги с общими типом для значения плотности бумаги.
    /// </summary>
    /// <typeparam name="T">Значение плотности бумаги.</typeparam>
    public interface IBook<T>
    {
        /// <summary>
        /// Возвращает или задает список авторов книги (необязательно).
        /// </summary>
        public List<IPerson>? Authors { get; set; }

        /// <summary>
        /// Возвращает или устанавливает издательство книги (необязательно).
        /// </summary>
        public IPublishing? Publishing { get; set; }

        /// <summary>
        /// Возвращает или устанавливает переплет книги (необязательно).
        /// </summary>
        public BookBinder? Binder { get; set; }

        /// <summary>
        /// Возвращает или устанавливает плотность бумаги (необязательно).
        /// </summary>
        public T? Density { get; set; }
    }

    /// <summary>
    /// Представляет объект книги, реализующий интерфейсы IBook, IViewable.
    /// </summary>
    public class Book : Composition, IBook<uint?>, IViewable
    {
        /// <summary>
        /// Возвращает или задает список авторов книги (необязательно).
        /// </summary>
        public List<IPerson>? Authors { get; set; }

        /// <summary>
        /// Возвращает или устанавливает издательство книги (необязательно).
        /// </summary>
        public IPublishing? Publishing { get; set; }

        /// <summary>
        /// Возвращает или устанавливает переплет книги (необязательно).
        /// </summary>
        public BookBinder? Binder { get; set; }

        /// <summary>
        /// Возвращает или устанавливает плотность бумаги (необязательно).
        /// </summary>
        public uint? Density { get; set; }

        /// <summary>
        /// Получает строку-представление книги.
        /// </summary>
        public string View { get => "Книга " + Name + " " + YearBirth ?? ""; }
    }
}
