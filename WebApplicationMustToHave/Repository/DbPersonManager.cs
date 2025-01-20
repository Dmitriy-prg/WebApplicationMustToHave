using Microsoft.EntityFrameworkCore;
using System;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.Repository
{
    /// <summary>
    /// Менеджер персон
    /// </summary>
    public interface IDbPersonManager
    {
        /// <summary>
        /// Возвращает список всех представлений персон
        /// </summary>
        /// <returns>список представлений персон</returns>
        public Task<List<IViewable>> GetPersonViewsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает список всех персон
        /// </summary>
        /// <returns>список персон</returns>
        public Task<List<DbPerson>> GetPersonsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает персону по id
        /// </summary>
        /// <param name="id">id персоны</param>
        /// <returns>персона</returns>
        public Task<DbPerson?> GetPersonByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет персону
        /// </summary>
        /// <param name="dbPerson"></param>
        /// <returns></returns>
        public Task AddPersonAsync(DbPerson dbPerson, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет персону
        /// </summary>
        /// <param name="dbPerson"></param>
        /// <returns></returns>
        public Task UpdatePersonAsync(DbPerson dbPerson, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет персону
        /// </summary>
        /// <param name="dbPerson"></param>
        /// <returns></returns>
        public Task DeletePersonAsync(DbPerson dbPerson, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет персону
        /// </summary>
        /// <param name="id">id персоны</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        public Task DeletePersonByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Сохраняет изменения
        /// </summary>
        /// <returns></returns>
        public Task SaveChangesAsync(CancellationToken cancellationToken);
    }

    /// <summary>
    /// Менеджер персон
    /// </summary>
    public class DbPersonManager: IDbPersonManager
    {
        private readonly IAppDbContext _db;

        /// <summary>
        /// Менеджер персон
        /// </summary>
        /// <param name="db">AppDbContext</param>
        public DbPersonManager(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Возвращает список всех представлений персон
        /// </summary>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>список представлений персон</returns>
        public async Task<List<IViewable>> GetPersonViewsAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken != null && cancellationToken.IsCancellationRequested) return [];
            List<IViewable> persons = await _db.Persons.Where(c => c != null).Select(c => (c as IViewable)!).ToListAsync();
            return persons ?? [];
        }

        /// <summary>
        /// Возвращает список всех персон
        /// </summary>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>список персон</returns>
        public async Task<List<DbPerson>> GetPersonsAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken != null && cancellationToken.IsCancellationRequested) return [];
            List<DbPerson> persons = await _db.Persons.Where(c => c != null).Select(c => (c as DbPerson)!).ToListAsync();
            return persons ?? [];
        }

        /// <summary>
        /// Возвращает персону по id
        /// </summary>
        /// <param name="id">id персоны</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns>персона</returns>
        public async Task<DbPerson?> GetPersonByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (cancellationToken != null && cancellationToken.IsCancellationRequested) return null;
            return await _db.Persons.FirstOrDefaultAsync(p => p.Id == id);
        }
        /// <summary>
        /// Добавляет персону
        /// </summary>
        /// <param name="dbPerson"></param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        public async Task AddPersonAsync(DbPerson dbPerson, CancellationToken cancellationToken)
        {
            if (dbPerson != null)
            {
                if (cancellationToken != null && cancellationToken.IsCancellationRequested) return;
                if (dbPerson.Id == 0)
                {
                    dbPerson.Id = _db.Persons.Count() == 0 ? 1 : _db.Persons.Select(c => c.Id).Max() + 1;
                }
                _db.Persons.Load();
                await _db.Persons.AddAsync(dbPerson);
                //await _db.Persons.AddAsync(dbPerson as DbPerson);
                await _db.SaveChangesAsync(cancellationToken);
            }
            else Console.WriteLine("!!!Warning AddPersonAsync() dbPerson = null");
        }

        /// <summary>
        /// Обновляет персону
        /// </summary>
        /// <param name="dbPerson"></param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        public async Task UpdatePersonAsync(DbPerson dbPerson, CancellationToken cancellationToken)
        {
            if (dbPerson != null)
            {
                if (cancellationToken != null && cancellationToken.IsCancellationRequested) return;
                _db.Persons.Update(dbPerson);
                await _db.SaveChangesAsync(cancellationToken);
            }
            Console.WriteLine("!!!Warning UpdatePersonAsync() dbPerson = null");
        }

        /// <summary>
        /// Удаляет персону
        /// </summary>
        /// <param name="dbPerson"></param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        public async Task DeletePersonAsync(DbPerson dbPerson, CancellationToken cancellationToken)
        {
            if (dbPerson != null)
            {
                if (cancellationToken != null && cancellationToken.IsCancellationRequested) return;
                _db.Persons.Remove(dbPerson);
                await _db.SaveChangesAsync(cancellationToken);
            }
            Console.WriteLine("!!!Warning DeletePersonAsync() dbPerson = null");
        }

        /// <summary>
        /// Удаляет персону
        /// </summary>
        /// <param name="id">id персоны</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        public async Task DeletePersonByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (cancellationToken != null && cancellationToken.IsCancellationRequested) return;
                DbPerson? dbPerson = await _db.Persons.FirstOrDefaultAsync(p => p.Id == id);
                if (dbPerson != null) await DeletePersonAsync(dbPerson, cancellationToken);
            }
            Console.WriteLine("!!!Warning DeletePersonAsync() dbPerson = null");
        }

        /// <summary>
        /// Сохраняет изменения
        /// </summary>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        public async Task SaveChangesAsync(CancellationToken cancellationToken) => await _db.SaveChangesAsync(cancellationToken);

        //public IEnumerable<IPerson> CastToPersonCollection(IEnumerable<IDbPerson> dbPersons)
        //{
        //    List<Person> personsList = [];
        //    foreach (var dbPerson in dbPersons)
        //    {
        //        if (dbPerson != null)
        //        {
        //            Person? person = (Person?)Person.GetObjFromDb(dbPerson);
        //            if (person != null) personsList.Add(person);
        //        }
        //    }
        //    return personsList;
        //}
    }
}
