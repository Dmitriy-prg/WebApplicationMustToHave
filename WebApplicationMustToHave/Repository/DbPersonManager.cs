using Microsoft.EntityFrameworkCore;
using System;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.Repository
{
    public class DbPersonManager
    {
        private readonly AppDbContext _db;
        
        public DbPersonManager(AppDbContext db)
        {
            _db = db;
        }

        // GET: DbCompositions
        // Возвращает список всех произведений.
        /// <summary>
        /// Возвращает список всех произведений
        /// </summary>
        /// <returns>список</returns>
        public async Task<List<IViewable>> GetPersonViewsAsync()
        {
            try
            {
                List<IViewable> persons = await _db.persons.Where(c => c != null).Select(c => (c as IViewable)!).ToListAsync();
                return persons ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!Error GetPersonViewsAsync()");
                throw;
            }
        }

        public async Task<IEnumerable<IDbPerson<uint, uint?>>> GetPersonsAsync() => await _db.persons.ToListAsync();

        public async Task<IDbPerson<uint, uint?>?> GetPersonByIdAsync(int id) => await _db.persons.FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddPersonAsync(IDbPerson<uint, uint?> dbPerson)
        {
            if (dbPerson != null)
            {
                try
                {
                    if (dbPerson.Id == 0)
                    {
                        dbPerson.Id = _db.persons.Select(c => c.Id).Max() + 1;
                    }
                    await _db.persons.AddAsync((DbPerson)dbPerson);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("!!!Error AddPersonAsync()");
                    throw;
                }
            }
            Console.WriteLine("!!!Warning AddPersonAsync() dbPerson = null");
        }

        public async Task UpdatePersonAsync(DbPerson dbPerson)
        {
            if (dbPerson != null)
            {
                _db.persons.Update(dbPerson);
                await _db.SaveChangesAsync();
            }
            Console.WriteLine("!!!Warning UpdatePersonAsync() dbPerson = null");
        }

        public async Task DeletePersonAsync(DbPerson dbPerson)
        {
            if (dbPerson != null)
            {
                _db.persons.Remove(dbPerson);
                await _db.SaveChangesAsync();
            }
            Console.WriteLine("!!!Warning DeletePersonAsync() dbPerson = null");
        }

        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}
