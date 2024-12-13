using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.Repository
{
    public class DbCompositionManager
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
            try
            {
                List<IViewable> compositions = await _db.compositions.Where(c => c != null).Select(c => (c as IViewable)!).ToListAsync();
                return compositions ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!Error GetCompositionsAsync()");
                throw;
            }
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
            try
            {
                return await _db.compositions.Where(c => c != null && c.Type != null && c.Type.Id == typeId).Select(c => (c as IViewable)!).ToListAsync() ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!Error GetCompositionsAsync()");
                throw;
            }
        }

        // GET: DbCompositions
        // Возвращает список всех произведений с типом. "Книга" = 1, "Аудиокнига" = 2, "Фильм" = 3, "Песня" = 4
        /// <summary>
        /// Возвращает список всех произведений
        /// </summary>
        /// <returns>список всех произведений</returns>
        public async Task<List<IDbComposition>> GetCompositionsAsync()
        {
            try
            {
                return await _db.compositions.Select(c => c as IDbComposition).ToListAsync() ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!Error GetCompositionsAsync()");
                throw;
            }
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
            try
            {
                return await _db.compositions.Where(c => c.Type != null && c.Type.Id == typeId).Select(c => c as IDbComposition).ToListAsync() ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!Error GetCompositionsByTypeAsync()");
                throw;
            }
        }

        /// <summary>
        /// Возвращает произведение по id.
        /// </summary>
        /// <param name="id">Ключ произведения</param>
        /// <returns>произведение</returns>
        public async Task<IDbComposition?> GetCompositionByIdAsync(int id)
        {
            try
            {
                IDbComposition dbComposition = await _db.compositions.Where(c => c.Type != null && c.Id == id).Select(c => c as IDbComposition).FirstOrDefaultAsync();
                if (dbComposition == null) return null;
                if (dbComposition.Type == null) dbComposition.Type = await GetCompositionTypeById(dbComposition.DbCompositionTypeId);
                return dbComposition;
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!Error GetCompositionsByTypeAsync()");
                throw;
            }
        }

        /// <summary>
        /// Обновляет произведение.
        /// </summary>
        public async Task UpdateCompositionAsync(IDbComposition dbComposition)
        {
            if (dbComposition != null)
            {
                try
                {
                    _db.compositions.Update((dbComposition as DbComposition)!);
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("!!!Error UpdateCompositionAsync()");
                    throw;
                }
            }
        }

        /// <summary>
        /// Удаляет произведение.
        /// </summary>
        public async Task DeleteCompositionByIdAsync(int id)
        {
            try
            {
                DbComposition? composition = _db.compositions.FirstOrDefault(c => c.Id == id);
                if (composition != null)
                {
                    _db.compositions.Remove(composition);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!Error DeleteCompositionByIdAsync()");
                throw;
            }
        }

        /// <summary>
        /// Добавляет произведение.
        /// </summary>
        public async Task AddCompositionAsync(IDbComposition dbComposition)
        {
            if (dbComposition != null)
            {
                try
                {
                    if (dbComposition.Id == 0)
                    {
                        dbComposition.Id = _db.compositions.Select(c => c.Id).Max()+1;
                    }
                    _db.compositions.Add((dbComposition as DbComposition)!);
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("!!!Error AddCompositionAsync()");
                    throw;
                }
            }
            Console.WriteLine("!!!Warning AddCompositionAsync() dbComposition = null");
        }

        public async Task<DbCompositionType?> GetCompositionTypeById(uint typeId)
        {
            try
            {
                return await _db.composition_types.FirstOrDefaultAsync(c => c.Id == typeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!Error GetCompositionTypeById()");
                throw;
            }
        }

    }
}
