using System.Collections.Generic;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Repository;

namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет фильм с общими типами для единицы измерения и версии рейтинга.
    /// </summary>
    /// <typeparam name="T">Тип значения.</typeparam>
    /// <typeparam name="V">Тип значения.</typeparam>
    /// <typeparam name="M">Тип единицы измерения, который должен реализовывать IMeasureUnit.</typeparam>
    public interface IFilm<T, V, M>
        where M : IMeasureUnit
    {
        /// <summary>
        /// Возвращает или задает список актеров (необязательно).
        /// </summary>
        public List<IPerson>? Actors { get; set; }

        /// <summary>
        /// Возвращает или задает список режиссеров фильма (необязательно).
        /// </summary>
        public List<IPerson>? Directors { get; set; }

        /// <summary>
        /// Возвращает или устанавливает битрейт аудио (необязательно).
        /// </summary>
        public IBitrate<T, M>? BitrateAudio { get; set; }

        /// <summary>
        /// Возвращает или устанавливает битрейт видео (необязательно).
        /// </summary>
        public IBitrate<T, M>? BitrateVideo { get; set; }

        /// <summary>
        /// Возвращает или устанавливает разрешение экрана (необязательно).
        /// </summary>
        public IResolution<V>? Resolution { get; set; }
    }

    /// <summary>
    /// Представляет фильм с общими типами для единицы измерения и версии рейтинга.
    /// Реализует интерфейсы IFilm<uint, uint, IMeasureUnit>, IViewable, IDbLinkable<Film>.
    /// </summary>
    /// <typeparam name="T">Тип значения.</typeparam>
    /// <typeparam name="M">Тип единицы измерения, который должен реализовывать IMeasureUnit.</typeparam>
    public class Film : Composition, IFilm<uint, uint, IMeasureUnit>, IViewable//, IDbLinkable<Film>
    {
        /// <summary>
        /// Возвращает или задает список актеров.
        /// </summary>
        public List<IPerson>? Actors { get; set; }

        /// <summary>
        /// Возвращает или задает список режиссеров фильма.
        /// </summary>
        public List<IPerson>? Directors { get; set; }

        /// <summary>
        /// Возвращает или устанавливает битрейт аудио (необязательно).
        /// </summary>
        public IBitrate<uint, IMeasureUnit>? BitrateAudio { get; set; }

        /// <summary>
        /// Возвращает или устанавливает битрейт видео (необязательно).
        /// </summary>
        public IBitrate<uint, IMeasureUnit>? BitrateVideo { get; set; }

        /// <summary>
        /// Возвращает или устанавливает разрешение кадра (необязательно).
        /// </summary>
        public IResolution<uint>? Resolution { get; set; }

        /// <summary>
        /// Получает строку-представление фильма.
        /// </summary>
        public string View { get => "Фильм " + Name + " " + YearBirth ?? ""; }

        //public static Film? GetObjFromDb(IDbComposition? dbComposition)
        //{
        //    if (dbComposition == null) return null;
        //    Film f = new Film
        //    {
        //        Id = dbComposition.Id,
        //        Name = dbComposition.Name,
        //        Type = CompositionType.GetObjFromDb(dbComposition.Type!),
        //        Description = dbComposition.Description,
        //        YearBirth = dbComposition.YearBirth
        //    };
        //    f.Actors = dbComposition.Performers?.Where(c => c != null).Select(c => (c as IPerson)!).ToList() ?? [];
        //    f.Directors = dbComposition.Directors?.Where(c => c != null).Select(c => (c as IPerson)!).ToList() ?? [];
        //    f.BitrateAudio = (IBitrate<uint, IMeasureUnit>?)(dbComposition?.BitrateAudio);
        //    f.BitrateVideo = (IBitrate<uint, IMeasureUnit>?)(dbComposition?.BitrateVideo);
        //    f.Resolution = (IResolution<uint>?)(dbComposition?.Resolution);
        //    return f;
        //}
    }
}
