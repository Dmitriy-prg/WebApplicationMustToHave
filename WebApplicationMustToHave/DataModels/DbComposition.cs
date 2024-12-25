using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Интерфейс, представляющий произведение.
    /// </summary>
    public interface IDbComposition

    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор произведения.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Возвращает или задает наименование произведения.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает описание произведения (необязательно).
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Возвращает или задает год создания произведения (необязательно).
        /// </summary>
        public uint? YearBirth { get; set; }

        /// <summary>
        /// Возвращает или устанавливает плотность бумаги (необязательно).
        /// </summary>
        public uint? Density { get; set; }

        /// <summary>
        /// Возвращает или задает тип произведения.
        /// </summary>
        public DbCompositionType? Type { get; set; }

        /// <summary>
        /// Возвращает или устанавливает переплет книги (необязательно).
        /// </summary>
        public DbBookBinder? Binder { get; set; }

        /// <summary>
        /// Возвращает или задает объем произведения, с универсальным типом значения T и единицей измерения M.
        /// </summary>
        public DbVolume? Volume { get; set; }

        /// <summary>
        /// Возвращает или устанавливает издательство произведения (необязательно).
        /// </summary>
        public DbPublishing? Publishing { get; set; }

        /// <summary>
        /// Возвращает или устанавливает битрейт видео произведения (необязательно).
        /// </summary>
        public DbBitrate? BitrateVideo { get; set; }

        /// <summary>
        /// Возвращает или устанавливает битрейт аудио произведения (необязательно).
        /// </summary>
        public DbBitrate? BitrateAudio { get; set; }

        /// <summary>
        /// Возвращает или устанавливает разрешение (кадра) (необязательно).
        /// </summary>
        public DbResolution? Resolution { get; set; }

        /// <summary>
        /// Возвращает или задает список жанров произведения, с универсальным типом значения T (необязательно).
        /// </summary>
        public List<DbGenre>? Genres { get; set; }

        /// <summary>
        /// Возвращает или задает список рейтингов произведения, с универсальным типом значения T и версией рейтинга R (необязательно).
        /// </summary>
        public List<DbRating>? Ratings { get; set; }

        /// <summary>
        /// Возвращает или задает список авторов произведения (необязательно).
        /// </summary>
        public List<DbPerson>? Authors { get; set; }

        /// <summary>
        /// Возвращает или задает список исполнителей произведения (необязательно).
        /// </summary>
        public List<DbPerson>? Performers { get; set; }

        /// <summary>
        /// Возвращает или устанавливает список композиторов произведения (необязательно).
        /// </summary>
        public List<DbPerson>? Composers { get; set; }

        /// <summary>
        /// Возвращает или задает список режиссеров произведения (необязательно).
        /// </summary>
        public List<DbPerson>? Directors { get; set; }

        /// <summary>
        /// Ключт типа произведения.
        /// </summary>
        public uint DbCompositionTypeId { get; set; }

        /// <summary>
        /// Ключ переплета книги (необязательно).
        /// </summary>
        public uint? DbBookBinderId { get; set; }

        /// <summary>
        /// Ключ объема произведения (необязательно).
        /// </summary>
        public uint? DbVolumeId { get; set; }

        /// <summary>
        /// Ключ издательства произведения (необязательно).
        /// </summary>
        public uint? DbPublishingId { get; set; }

        /// <summary>
        /// Ключ битрейта произведения (необязательно).
        /// </summary>
        public uint? DbBitrate_BitrateVideoId { get; set; }

        /// <summary>
        /// Ключ битрейта произведения (необязательно).
        /// </summary>
        public uint? DbBitrate_BitrateAudioId { get; set; }

        /// <summary>
        /// Ключ разрешения (кадра) (необязательно).
        /// </summary>
        public uint? DbResolutionId { get; set; }
    }

    /// <summary>
    /// Базовый класс, представляющий произведение. Реализует интерфейс IDbComposition.
    /// </summary>
    public class DbComposition : IEntity, IDbComposition, IViewable
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор произведения.
        /// </summary>
        public required uint Id { get; set; }

        /// <summary>
        /// Возвращает или задает наименование произведения.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Возвращает или задает описание произведения (необязательно).
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Возвращает или задает год создания произведения (необязательно).
        /// </summary>
        public uint? YearBirth { get; set; }

        /// <summary>
        /// Возвращает или устанавливает плотность бумаги (необязательно).
        /// </summary>
        public uint? Density { get; set; }

        /// <summary>
        /// Возвращает или задает тип произведения.
        /// </summary>
        public DbCompositionType? Type { get; set; }

        /// <summary>
        /// Возвращает или устанавливает переплет книги (необязательно).
        /// </summary>
        public DbBookBinder? Binder { get; set; }

        /// <summary>
        /// Возвращает или задает объем произведения, с универсальным типом значения T и единицей измерения IMeasureUnit.
        /// </summary>
        public DbVolume? Volume { get; set; }

        /// <summary>
        /// Возвращает или устанавливает разрешение (кадра) (необязательно).
        /// </summary>
        public DbResolution? Resolution { get; set; }

        /// <summary>
        /// Возвращает или устанавливает издательство произведения (необязательно).
        /// </summary>
        public DbPublishing? Publishing { get; set; }

        /// <summary>
        /// Возвращает или устанавливает битрейт видео произведения (необязательно).
        /// </summary>
        public DbBitrate? BitrateVideo { get; set; }

        /// <summary>
        /// Возвращает или устанавливает битрейт аудио произведения (необязательно).
        /// </summary>
        public DbBitrate? BitrateAudio { get; set; }

        /// <summary>
        /// Возвращает или задает список жанров произведения, с универсальным типом значения T (необязательно).
        /// </summary>
        public List<DbGenre>? Genres { get; set; }

        /// <summary>
        /// Возвращает или задает список рейтингов произведения, с универсальным типом значения T и версией рейтинга IRatingVersion (необязательно).
        /// </summary>
        public List<DbRating>? Ratings { get; set; }

        /// <summary>
        /// Возвращает или задает список авторов произведения (необязательно).
        /// </summary>
        public List<DbPerson>? Authors { get; set; }

        /// <summary>
        /// Возвращает или задает список исполнителей произведения (необязательно).
        /// </summary>
        public List<DbPerson>? Performers { get; set; }

        /// <summary>
        /// Возвращает или устанавливает список композиторов произведения (необязательно).
        /// </summary>
        public List<DbPerson>? Composers { get; set; }

        /// <summary>
        /// Возвращает или задает список режиссеров произведения (необязательно).
        /// </summary>
        public List<DbPerson>? Directors { get; set; }

        /// <summary>
        /// Ключт типа произведения.
        /// </summary>
        public uint DbCompositionTypeId { get; set; }

        /// <summary>
        /// Ключ переплета книги (необязательно).
        /// </summary>
        public uint? DbBookBinderId { get; set; }

        /// <summary>
        /// Ключ объема произведения (необязательно).
        /// </summary>
        public uint? DbVolumeId { get; set; }

        /// <summary>
        /// Ключ издательства произведения (необязательно).
        /// </summary>
        public uint? DbPublishingId { get; set; }

        /// <summary>
        /// Ключ битрейта произведения (необязательно).
        /// </summary>
        public uint? DbBitrate_BitrateVideoId { get; set; }

        /// <summary>
        /// Ключ битрейта произведения (необязательно).
        /// </summary>
        public uint? DbBitrate_BitrateAudioId { get; set; }

        /// <summary>
        /// Ключ разрешения (кадра) (необязательно).
        /// </summary>
        public uint? DbResolutionId { get; set; }

        /// <summary>
        /// Получает строку-представление.
        /// </summary>
        public string View { get => Type?.Name + " " + Name + " " + YearBirth ?? ""; }
    }
}
