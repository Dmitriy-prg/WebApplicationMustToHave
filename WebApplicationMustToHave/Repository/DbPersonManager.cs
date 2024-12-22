using Microsoft.EntityFrameworkCore;
using System;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.Repository
{
    public interface IDbPersonManager
    {
        /// <summary>
        /// Возвращает список всех представлений персон
        /// </summary>
        /// <returns>список представлений персон</returns>
        public Task<List<IViewable>> GetPersonViewsAsync();

        /// <summary>
        /// Возвращает список всех персон
        /// </summary>
        /// <returns>список персон</returns>
        public Task<List<IDbPerson>> GetPersonsAsync();

        /// <summary>
        /// Возвращает персону по id
        /// </summary>
        /// <param name="id">id персоны</param>
        /// <returns>персона</returns>
        public Task<IDbPerson?> GetPersonByIdAsync(int id);

        /// <summary>
        /// Добавляет персону
        /// </summary>
        /// <param name="dbPerson"></param>
        /// <returns></returns>
        public Task AddPersonAsync(IDbPerson dbPerson);

        /// <summary>
        /// Обновляет персону
        /// </summary>
        /// <param name="dbPerson"></param>
        /// <returns></returns>
        public Task UpdatePersonAsync(DbPerson dbPerson);

        /// <summary>
        /// Удаляет персону
        /// </summary>
        /// <param name="dbPerson"></param>
        /// <returns></returns>
        public Task DeletePersonAsync(DbPerson dbPerson);

        /// <summary>
        /// Сохраняет изменения
        /// </summary>
        /// <returns></returns>
        public Task SaveChangesAsync();
    }


    public class DbPersonManager: IDbPersonManager
    {
        private readonly IAppDbContext _db;
        
        public DbPersonManager(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Возвращает список всех представлений персон
        /// </summary>
        /// <returns>список представлений персон</returns>
        public async Task<List<IViewable>> GetPersonViewsAsync()
        {
             List<IViewable> persons = await _db.Persons.Where(c => c != null).Select(c => (c as IViewable)!).ToListAsync();
            return persons ?? [];
        }

        /// <summary>
        /// Возвращает список всех персон
        /// </summary>
        /// <returns>список персон</returns>
        public async Task<List<IDbPerson>> GetPersonsAsync()
        {
            List<IDbPerson> persons = await _db.Persons.Where(c => c != null).Select(c => (c as IDbPerson)!).ToListAsync();
            return persons ?? [];
        }

        /// <summary>
        /// Возвращает персону по id
        /// </summary>
        /// <param name="id">id персоны</param>
        /// <returns>персона</returns>
        public async Task<IDbPerson?> GetPersonByIdAsync(int id) => await _db.Persons.FirstOrDefaultAsync(p => p.Id == id);

        /// <summary>
        /// Добавляет персону
        /// </summary>
        /// <param name="dbPerson"></param>
        /// <returns></returns>
        public async Task AddPersonAsync(IDbPerson dbPerson)
        {
            if (dbPerson != null)
            {
                if (dbPerson.Id == 0)
                {
                    dbPerson.Id = _db.Persons.Count() == 0 ? 1 : _db.Persons.Select(c => c.Id).Max() + 1;
                }
                DbPerson persObj = (DbPerson)dbPerson;
                _db.Persons.Load();
                await _db.Persons.AddAsync(persObj);
                //await _db.Persons.AddAsync(dbPerson as DbPerson);
                await _db.SaveChangesAsync(new CancellationTokenSource().Token);
            }
            else Console.WriteLine("!!!Warning AddPersonAsync() dbPerson = null");
        }

        /// <summary>
        /// Обновляет персону
        /// </summary>
        /// <param name="dbPerson"></param>
        /// <returns></returns>
        public async Task UpdatePersonAsync(DbPerson dbPerson)
        {
            if (dbPerson != null)
            {
                _db.Persons.Update(dbPerson);
                await _db.SaveChangesAsync(new CancellationTokenSource().Token);
            }
            Console.WriteLine("!!!Warning UpdatePersonAsync() dbPerson = null");
        }

        /// <summary>
        /// Удаляет персону
        /// </summary>
        /// <param name="dbPerson"></param>
        /// <returns></returns>
        public async Task DeletePersonAsync(DbPerson dbPerson)
        {
            if (dbPerson != null)
            {
                _db.Persons.Remove(dbPerson);
                await _db.SaveChangesAsync(new CancellationTokenSource().Token);
            }
            Console.WriteLine("!!!Warning DeletePersonAsync() dbPerson = null");
        }

        /// <summary>
        /// Сохраняет изменения
        /// </summary>
        /// <returns></returns>
        public async Task SaveChangesAsync() => await _db.SaveChangesAsync(new CancellationTokenSource().Token);

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
