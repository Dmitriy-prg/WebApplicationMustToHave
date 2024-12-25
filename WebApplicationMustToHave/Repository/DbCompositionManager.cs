using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.Repository
{
    /// <summary>
    /// Менеджер произведений (интерфейс)
    /// </summary>
    public interface IDbCompositionManager
    {
        // Возвращает список всех произведений.
        /// <summary>
        /// Возвращает список всех произведений
        /// </summary>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>список</returns>
        public Task<List<IViewable>> GetCompositionViewsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает список всех произведений отфильтрованный по типу
        /// "Книга" = 1, "Аудиокнига" = 2, "Фильм" = 3, "Песня" = 4
        /// </summary>
        /// <param name="typeId"> Книга = 1, Аудиокнига = 2, Фильм = 3, Песня = 4</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>список представлений произведений</returns>
        public Task<List<IViewable>> GetCompositionViewsByTypeAsync(int typeId, CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает список всех произведений
        /// </summary>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>список всех произведений</returns>
        public Task<List<IDbComposition>> GetCompositionsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает список всех произведений отфильтрованный по типу
        /// </summary>
        /// <param name="typeId"> Книга = 1, Аудиокнига = 2, Фильм = 3, Песня = 4</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>список</returns>
        public Task<List<IDbComposition>> GetCompositionsByTypeAsync(int typeId, CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает произведение по id.
        /// </summary>
        /// <param name="id">Ключ произведения</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>произведение</returns>
        public Task<IDbComposition?> GetCompositionByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет произведение.
        /// </summary>
        /// <param name="dbComposition">произведение</param>
        /// <param name="cancellationToken">токен отмены</param>
        public Task UpdateCompositionAsync(IDbComposition dbComposition, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет произведение.
        /// </summary>
        /// <param name="id">Ключ произведения</param>
        /// <param name="cancellationToken">токен отмены</param>
        public Task DeleteCompositionByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет произведение.
        /// </summary>
        /// <param name="dbComposition">произведение</param>
        /// <param name="cancellationToken">токен отмены</param>
        public Task AddCompositionAsync(IDbComposition dbComposition, CancellationToken cancellationToken);

        /// <summary>
        /// Получить тип произведения
        /// </summary>
        /// <param name="typeId">Id произведения</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>тип произведения</returns>
        public Task<DbCompositionType?> GetCompositionTypeByIdAsync(uint typeId, CancellationToken cancellationToken);
    }

    /// <summary>
    /// Менеджер произведений
    /// </summary>
    public class DbCompositionManager: IDbCompositionManager
    {
        private readonly AppDbContext _db;
        
        public DbCompositionManager(AppDbContext db)
        {
            _db = db;
        }

        // GET: DbCompositions
        // Возвращает список всех произведений.
        /// <summary>
        /// Возвращает список всех произведений
        /// </summary>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>список</returns>
        public async Task<List<IViewable>> GetCompositionViewsAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return [];
            if (_db.CompositionTypes == null | _db.CompositionTypes.Local.Count == 0) _db.CompositionTypes?.Load();
            List<IViewable> compositions = await _db.Compositions.Where(c => c != null).Select(c => (c as IViewable)!).ToListAsync();
            return compositions ?? [];
        }

        // GET: DbCompositions
        // Возвращает список всех представлений произведений с типом. "Книга" = 1, "Аудиокнига" = 2, "Фильм" = 3, "Песня" = 4
        /// <summary>
        /// Возвращает список всех произведений отфильтрованный по типу
        /// </summary>
        /// <param name="typeId"> Книга = 1, Аудиокнига = 2, Фильм = 3, Песня = 4</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>список представлений произведений</returns>
        public async Task<List<IViewable>> GetCompositionViewsByTypeAsync(int typeId, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return [];
            return await _db.Compositions.Where(c => c != null && c.Type != null && c.Type.Id == typeId).Select(c => (c as IViewable)!).ToListAsync() ?? [];
        }

        // GET: DbCompositions
        // Возвращает список всех произведений с типом. "Книга" = 1, "Аудиокнига" = 2, "Фильм" = 3, "Песня" = 4
        /// <summary>
        /// Возвращает список всех произведений
        /// </summary>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>список всех произведений</returns>
        public async Task<List<IDbComposition>> GetCompositionsAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return [];
            return await _db.Compositions.Select(c => c as IDbComposition).ToListAsync() ?? [];
        }

        // GET: DbCompositions
        // Возвращает список всех произведений с типом. "Книга" = 1, "Аудиокнига" = 2, "Фильм" = 3, "Песня" = 4
        /// <summary>
        /// Возвращает список всех произведений отфильтрованный по типу
        /// </summary>
        /// <param name="typeId"> Книга = 1, Аудиокнига = 2, Фильм = 3, Песня = 4</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>список</returns>
        public async Task<List<IDbComposition>> GetCompositionsByTypeAsync(int typeId, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return [];
            return await _db.Compositions.Where(c => c.Type != null && c.Type.Id == typeId).Select(c => c as IDbComposition).ToListAsync() ?? [];
        }

        /// <summary>
        /// Возвращает произведение по id.
        /// </summary>
        /// <param name="id">Ключ произведения</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>произведение</returns>
        public async Task<IDbComposition?> GetCompositionByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            IDbComposition dbComposition = await _db.Compositions.Where(c => c.Type != null && c.Id == id).Select(c => c as IDbComposition).FirstOrDefaultAsync();
            if (dbComposition == null) return null;
            if (dbComposition.Type == null) dbComposition.Type = await GetCompositionTypeByIdAsync(dbComposition.DbCompositionTypeId, cancellationToken);
            return dbComposition;
        }

        /// <summary>
        /// Обновляет произведение.
        /// </summary>
        /// <param name="dbComposition">произведение</param>
        /// <param name="cancellationToken">токен отмены</param>
        public async Task UpdateCompositionAsync(IDbComposition dbComposition, CancellationToken cancellationToken)
        {
            if (dbComposition != null)
            {
                if (cancellationToken.IsCancellationRequested) return;
                _db.Compositions.Update((dbComposition as DbComposition)!);
                await _db.SaveChangesAsync(cancellationToken);
            }
            else Console.WriteLine("!!!Warning UpdateCompositionAsync() dbComposition = null");
        }

        /// <summary>
        /// Удаляет произведение.
        /// </summary>
        /// <param name="id">Ключ произведения</param>
        /// <param name="cancellationToken">токен отмены</param>
        public async Task DeleteCompositionByIdAsync(int id, CancellationToken cancellationToken)
        {
            DbComposition? dbComposition = _db.Compositions.FirstOrDefault(c => c.Id == id);
            if (dbComposition != null)
            {
                if (cancellationToken.IsCancellationRequested) return;
                _db.Compositions.Remove(dbComposition);
                await _db.SaveChangesAsync(cancellationToken);
            }
            else Console.WriteLine("!!!Warning DeleteCompositionByIdAsync() dbComposition = null");
        }

        /// <summary>
        /// Добавляет произведение.
        /// </summary>
        /// <param name="dbComposition">произведение</param>
        /// <param name="cancellationToken">токен отмены</param>
        public async Task AddCompositionAsync(IDbComposition dbComposition, CancellationToken cancellationToken)
        {
            if (dbComposition != null)
            {
                if (cancellationToken.IsCancellationRequested) return;
                if (dbComposition.Id == 0)
                {
                    dbComposition.Id = _db.Compositions.Select(c => c.Id).Max()+1;
                }
                _db.Compositions.Add((dbComposition as DbComposition)!);
                await _db.SaveChangesAsync(cancellationToken);
            }
            else Console.WriteLine("!!!Warning AddCompositionAsync() dbComposition = null");
        }

        /// <summary>
        /// Получить тип произведения
        /// </summary>
        /// <param name="typeId">Id произведения</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>тип произведения</returns>
        public async Task<DbCompositionType?> GetCompositionTypeByIdAsync(uint typeId, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await _db.CompositionTypes.FirstOrDefaultAsync(c => c.Id == typeId);
        }

        //public static async Task<IEnumerable<IFilm<uint, uint, IMeasureUnit>>> GetCollectionsAsync(AppDbContext db)
        //{
        //    DbCompositionManager dbMan = new DbCompositionManager(db);
        //    List<IDbComposition> dbCompositions = await dbMan.GetCompositionsByTypeAsync(3);
        //    List<Film> filmsList = [];
        //    foreach (var dbComposition in dbCompositions)
        //    {
        //        if (dbComposition != null)
        //        {
        //            Film? film = (Film?)Film.GetObjFromDb(dbComposition);
        //            if (film != null) filmsList.Add(film);
        //        }
        //    }
        //    return filmsList;
        //}
    }
}
