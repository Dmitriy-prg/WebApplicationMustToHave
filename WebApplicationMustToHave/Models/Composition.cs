using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Repository;

namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Интерфейс, представляющий произведение с универсальными типами для единицы измерения и версии рейтинга
    /// </summary>
    /// <typeparam name="T">Тип значения.</typeparam>
    /// <typeparam name="U">Тип единицы измерения, который должен реализовывать IMeasureUnit.</typeparam>
    /// <typeparam name="V">Тип значения жанра.</typeparam>
    /// <typeparam name="R">Тип версии рейтинга, который должен реализовывать IRatingVersion.</typeparam>
    public interface IComposition<T, U, V, R>
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор произведения.
        /// </summary>
        public long Id { get; set; }

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
        public U? YearBirth { get; set; }

        /// <summary>
        /// Возвращает или задает тип произведения.
        /// </summary>
        public CompositionType Type { get; set; }

        /// <summary>
        /// Возвращает или задает обхем произведения, с универсальным типом значения T и единицей измерения M.
        /// </summary>
        public IVolume<T, IMeasureUnit>? Volume { get; set; }

        /// <summary>
        /// Возвращает или задает список жанров произведения, с универсальным типом значения T (необязательно).
        /// </summary>
        public List<IGenre<V>>? Genres { get; set; }

        /// <summary>
        /// Возвращает или задает список рейтингов произведения, с универсальным типом значения T и версией рейтинга R (необязательно).
        /// </summary>
        public List<IRating<R, IRatingVersion>>? Ratings { get; set; }
    }

    /// <summary>
    /// Базовый класс, представляющий произведение с универсальными типами для единицы измерения и версии рейтинга
    /// </summary>
    public class Composition : IEntity, IComposition<int, uint?, string, double>
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор произведения.
        /// </summary>
        public required long Id { get; set; }

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
        /// Возвращает или задает тип произведения.
        /// </summary>
        public required CompositionType Type { get; set; }

        /// <summary>
        /// Возвращает или задает обхем произведения, с универсальным типом значения T и единицей измерения IMeasureUnit.
        /// </summary>
        public IVolume<int, IMeasureUnit>? Volume { get; set; }

        /// <summary>
        /// Возвращает или задает список жанров произведения, с универсальным типом значения T (необязательно).
        /// </summary>
        public List<IGenre<string>>? Genres { get; set; }

        /// <summary>
        /// Возвращает или задает список рейтингов произведения, с универсальным типом значения T и версией рейтинга IRatingVersion (необязательно).
        /// </summary>
        public List<IRating<double, IRatingVersion>>? Ratings { get; set; }

        public static IComposition<int, uint?, string, double>? GetObjFromDb(DbComposition? dbComposition)
        {
            if (dbComposition == null) return null;
            Composition composition = new()
            {
                Id = dbComposition.Id,
                Name = dbComposition.Name,
                Type = CompositionType.GetObjFromDb(dbComposition.Type!),
                Description = dbComposition.Description,
                YearBirth = (uint)(dbComposition.YearBirth ?? 0)
            };
            //if (dbComposition.Volume != null) 
            //{
            //    Volume = dbComposition?.Volume.
            //}
            //composition.Performers = dbComposition.Performers?.Where(c => c != null).Select(c => (c as IPerson)!).ToList() ?? [];
            //composition.Directors = dbComposition.Directors?.Where(c => c != null).Select(c => (c as IPerson)!).ToList() ?? [];
            //composition.BitrateAudio = (IBitrate<uint, IMeasureUnit>?)(dbComposition?.BitrateAudio);
            //composition.BitrateVideo = (IBitrate<uint, IMeasureUnit>?)(dbComposition?.BitrateVideo);
            //composition.Resolution = (IResolution<uint>?)(dbComposition?.Resolution);
            return composition;
        }

        //public static async Task<IEnumerable<IComposition<int, uint?, string, double>>> GetCollectionsAsync(AppDbContext db, CancellationToken cancellationToken)
        //{
        //    List<DbComposition> dbCompositions = await new DbCompositionManager(db).GetCompositionsAsync(cancellationToken);
        //    List<Composition> CompositionsList = [];
        //    foreach (var dbComposition in dbCompositions)
        //    {
        //        if (dbComposition != null)
        //        {
        //            Composition? composition = (Composition?)GetObjFromDb(dbComposition);
        //            if (composition != null) CompositionsList.Add(composition);
        //        }
        //    }
        //    return CompositionsList;
        //}
    }
}
