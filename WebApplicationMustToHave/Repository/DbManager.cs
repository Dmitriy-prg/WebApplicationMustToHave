using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;
using WebApplicationMustToHave.Services;

namespace WebApplicationMustToHave.Repository
{
    /// <summary>
    /// Менеджер работы с базой
    /// </summary>
    public class DbManager
    {
        protected readonly IAppDbContext _db;
        protected readonly ILoggerManager _logger;

        /// <summary>
        /// Менеджер работы с базой
        /// </summary>
        /// <param name="db">AppDbContext</param>
        public DbManager(AppDbContext db, ILoggerManager logger)
        {
            _db = db;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает список всех представлений
        /// </summary>
        /// <param name="cancellationToken">токен отмены</param>
        /// <typeparam name="TEntity">класс представления</typeparam>
        /// <returns>список представлений персон</returns>
        public async Task<List<IViewable>> GetViewsAsync<TEntity>(CancellationToken cancellationToken) where TEntity : class, IViewable
        {
            if (cancellationToken != null && cancellationToken.IsCancellationRequested) return [];
            List<IViewable> entities = await _db.GetDbSet<TEntity>().Where(c => c != null).Select(c => (c as IViewable)!).ToListAsync(cancellationToken);
            return entities ?? [];
        }

        /// <summary>
        /// Возвращает список всех объектов
        /// </summary>
        /// <param name="cancellationToken">токен отмены</param>
        /// <typeparam name="TEntity">класс объектов коллекции</typeparam>
        /// <returns>список персон</returns>
        public async Task<List<TEntity>> GetObjectsAsync<TEntity>(CancellationToken cancellationToken) where TEntity : class
        {
            if (cancellationToken != null && cancellationToken.IsCancellationRequested) return [];
            List<TEntity> objects = await _db.GetDbSet<TEntity>().Where(c => c != null).Select(c => (c as TEntity)!).ToListAsync(cancellationToken);
            return objects ?? [];
        }

        /// <summary>
        /// Возвращает объект по id
        /// </summary>
        /// <param name="id">id персоны</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>персона</returns>
        public async Task<TEntity?> GetObjectByIdAsync<TEntity>(long id, CancellationToken cancellationToken) where TEntity : class, IBaseEntity<long>
        {
            if (cancellationToken != null && cancellationToken.IsCancellationRequested) return null;
            return await _db.GetDbSet<TEntity>().FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Добавляет объект
        /// </summary>
        /// <param name="dbPerson"></param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        public async Task AddObjectAsync<TEntity>(TEntity newObject, CancellationToken cancellationToken) where TEntity : class, IBaseEntity<long>
        {
            if (newObject != null)
            {
                DbSet<TEntity> collect = _db.GetDbSet<TEntity>();
                if (cancellationToken != null && cancellationToken.IsCancellationRequested) return;
                if (newObject.Id == 0)
                {
                    newObject.Id = collect.Count() == 0 ? 1 : collect.Select(c => c.Id).Max() + 1;
                }
                collect.Load();
                await collect.AddAsync(newObject);
                await _db.SaveChangesAsync(cancellationToken);
            }
            else _logger.LogInformation("!!!Warning AddPersonAsync() newObject = null");
        }

        /// <summary>
        /// Обновляет объект
        /// </summary>
        /// <param name="curObject">текущий объект</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        public async Task UpdateObjectAsync<TEntity>(TEntity curObject, CancellationToken cancellationToken) where TEntity : class, IBaseEntity<long>
        {
            if (curObject != null)
            {
                if (cancellationToken != null && cancellationToken.IsCancellationRequested) return;
                _db.GetDbSet<TEntity>().Update(curObject);
                await _db.SaveChangesAsync(cancellationToken);
            }
            else _logger.LogInformation("!!!Warning UpdatePersonAsync() curObject = null");
        }

        /// <summary>
        /// Удаляет объект
        /// </summary>
        /// <param name="curObject">текущий объект</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        public async Task DeleteObjectAsync<TEntity>(TEntity curObject, CancellationToken cancellationToken) where TEntity : class, IBaseEntity<long>
        {
            if (curObject != null)
            {
                if (cancellationToken != null && cancellationToken.IsCancellationRequested) return;
                _db.GetDbSet<TEntity>().Remove(curObject);
                await _db.SaveChangesAsync(cancellationToken);
            }
            else _logger.LogInformation("!!!Warning DeletePersonAsync() dbPerson = null");
        }

        /// <summary>
        /// Удаляет объект по id
        /// </summary>
        /// <param name="id">id объекта</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        public async Task DeleteObjectByIdAsync<TEntity>(int id, CancellationToken cancellationToken) where TEntity : class, IBaseEntity<long>
        {
            if (id > 0)
            {
                if (cancellationToken != null && cancellationToken.IsCancellationRequested) return;
                TEntity curObject = await _db.GetDbSet<TEntity>().FirstOrDefaultAsync(p => p.Id == id);
                if (curObject != null) await DeleteObjectAsync<TEntity>(curObject, cancellationToken);
            }
            else _logger.LogInformation("!!!Warning DeletePersonByIdAsync() id = " + id);
        }

        /// <summary>
        /// Сохраняет изменения
        /// </summary>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        public async Task SaveChangesAsync(CancellationToken cancellationToken) => await _db.SaveChangesAsync(cancellationToken);
    }
}
