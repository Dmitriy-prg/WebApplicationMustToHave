using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.Repository
{
    public interface IDbCompositionManager
    {
        // Возвращает список всех произведений.
        /// <summary>
        /// Возвращает список всех произведений
        /// </summary>
        /// <returns>список</returns>
        public Task<List<IViewable>> GetCompositionViewsAsync();

        /// <summary>
        /// Возвращает список всех произведений отфильтрованный по типу
        /// "Книга" = 1, "Аудиокнига" = 2, "Фильм" = 3, "Песня" = 4
        /// </summary>
        /// <param name="typeId"> Книга = 1, Аудиокнига = 2, Фильм = 3, Песня = 4</param>
        /// <returns>список представлений произведений</returns>
        public Task<List<IViewable>> GetCompositionViewsByTypeAsync(int typeId);

        /// <summary>
        /// Возвращает список всех произведений
        /// </summary>
        /// <returns>список всех произведений</returns>
        public Task<List<IDbComposition>> GetCompositionsAsync();

        /// <summary>
        /// Возвращает список всех произведений отфильтрованный по типу
        /// </summary>
        /// <param name="typeId"> Книга = 1, Аудиокнига = 2, Фильм = 3, Песня = 4</param>
        /// <returns>список</returns>
        public Task<List<IDbComposition>> GetCompositionsByTypeAsync(int typeId);

        /// <summary>
        /// Возвращает произведение по id.
        /// </summary>
        /// <param name="id">Ключ произведения</param>
        /// <returns>произведение</returns>
        public Task<IDbComposition?> GetCompositionByIdAsync(int id);

        /// <summary>
        /// Обновляет произведение.
        /// </summary>
        public Task UpdateCompositionAsync(IDbComposition dbComposition);

        /// <summary>
        /// Удаляет произведение.
        /// </summary>
        public Task DeleteCompositionByIdAsync(int id);

        /// <summary>
        /// Добавляет произведение.
        /// </summary>
        public Task AddCompositionAsync(IDbComposition dbComposition);

        public Task<DbCompositionType?> GetCompositionTypeById(uint typeId);
    }


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
        /// <returns>список</returns>
        public async Task<List<IViewable>> GetCompositionViewsAsync()
        {
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
        /// <returns>список представлений произведений</returns>
        public async Task<List<IViewable>> GetCompositionViewsByTypeAsync(int typeId)
        {
            return await _db.Compositions.Where(c => c != null && c.Type != null && c.Type.Id == typeId).Select(c => (c as IViewable)!).ToListAsync() ?? [];
        }

        // GET: DbCompositions
        // Возвращает список всех произведений с типом. "Книга" = 1, "Аудиокнига" = 2, "Фильм" = 3, "Песня" = 4
        /// <summary>
        /// Возвращает список всех произведений
        /// </summary>
        /// <returns>список всех произведений</returns>
        public async Task<List<IDbComposition>> GetCompositionsAsync()
        {
            return await _db.Compositions.Select(c => c as IDbComposition).ToListAsync() ?? [];
        }

        // GET: DbCompositions
        // Возвращает список всех произведений с типом. "Книга" = 1, "Аудиокнига" = 2, "Фильм" = 3, "Песня" = 4
        /// <summary>
        /// Возвращает список всех произведений отфильтрованный по типу
        /// </summary>
        /// <param name="typeId"> Книга = 1, Аудиокнига = 2, Фильм = 3, Песня = 4</param>
        /// <returns>список</returns>
        public async Task<List<IDbComposition>> GetCompositionsByTypeAsync(int typeId)
        {
            return await _db.Compositions.Where(c => c.Type != null && c.Type.Id == typeId).Select(c => c as IDbComposition).ToListAsync() ?? [];
        }

        /// <summary>
        /// Возвращает произведение по id.
        /// </summary>
        /// <param name="id">Ключ произведения</param>
        /// <returns>произведение</returns>
        public async Task<IDbComposition?> GetCompositionByIdAsync(int id)
        {
            IDbComposition dbComposition = await _db.Compositions.Where(c => c.Type != null && c.Id == id).Select(c => c as IDbComposition).FirstOrDefaultAsync();
            if (dbComposition == null) return null;
            if (dbComposition.Type == null) dbComposition.Type = await GetCompositionTypeById(dbComposition.DbCompositionTypeId);
            return dbComposition;
        }

        /// <summary>
        /// Обновляет произведение.
        /// </summary>
        public async Task UpdateCompositionAsync(IDbComposition dbComposition)
        {
            if (dbComposition != null)
            {
                _db.Compositions.Update((dbComposition as DbComposition)!);
                await _db.SaveChangesAsync(new CancellationTokenSource().Token);
            }
            else Console.WriteLine("!!!Warning UpdateCompositionAsync() dbComposition = null");
        }

        /// <summary>
        /// Удаляет произведение.
        /// </summary>
        public async Task DeleteCompositionByIdAsync(int id)
        {
            DbComposition? dbComposition = _db.Compositions.FirstOrDefault(c => c.Id == id);
            if (dbComposition != null)
            {
                _db.Compositions.Remove(dbComposition);
                await _db.SaveChangesAsync(new CancellationTokenSource().Token);
            }
            else Console.WriteLine("!!!Warning DeleteCompositionByIdAsync() dbComposition = null");
        }

        /// <summary>
        /// Добавляет произведение.
        /// </summary>
        public async Task AddCompositionAsync(IDbComposition dbComposition)
        {
            if (dbComposition != null)
            {
                if (dbComposition.Id == 0)
                {
                    dbComposition.Id = _db.Compositions.Select(c => c.Id).Max()+1;
                }
                _db.Compositions.Add((dbComposition as DbComposition)!);
                await _db.SaveChangesAsync(new CancellationTokenSource().Token);
            }
            else Console.WriteLine("!!!Warning AddCompositionAsync() dbComposition = null");
        }

        public async Task<DbCompositionType?> GetCompositionTypeById(uint typeId)
        {
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
