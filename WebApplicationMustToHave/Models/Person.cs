using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Repository;

namespace WebApplicationMustToHave.Models
{
    /// <summary>
    /// Представляет человека с идентификатором, именем, фамилией и необязательными полями для указания отчества и года рождения.
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// Уникальный идентификатор человека.
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// Имя человека.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Фамилия человека.
        /// </summary>
        string Surname { get; set; }

        /// <summary>
        /// Отчество человека (необязательно).
        /// </summary>
        string? Patronymic { get; set; }

        /// <summary>
        /// Год рождения человека (необязательно).
        /// </summary>
        uint? YearBirth { get; set; }
    }

    /// <summary>
    /// Представляет человека с идентификатором, именем, фамилией и необязательными полями для указания отчества и года рождения.
    /// </summary>
    public class Person : IPerson, IEntity, IViewable
    {
        /// <summary>
        /// Уникальный идентификатор человека.
        /// </summary>
        public required long Id { get; set; }

        /// <summary>
        /// Имя человека.
        /// </summary>
        /// <remarks>Это свойство является обязательным и не может иметь значения null.</remarks>
        public required string Name { get; set; }

        /// <summary>
        /// Фамилия человека.
        /// </summary>
        /// <remarks>Это свойство является обязательным и не может иметь значения null.</remarks>
        public required string Surname { get; set; }

        /// <summary>
        /// Отчество человека (необязательно).
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Год рождения человека (необязательно).
        /// </summary>
        public uint? YearBirth { get; set; }

        /// <summary>
        /// Получает строку-представление человека.
        /// </summary>
        public string View { get => Name + " " + Surname + " " + Patronymic ?? "" + " " + YearBirth + " г." ?? ""; }

        public static IPerson? GetObjFromDb(DbPerson? dbPerson)
        {
            if (dbPerson == null) return null;
            Person person = new()
            {
                Id = dbPerson.Id,
                Name = dbPerson.Name,
                Surname = dbPerson.Surname,
                Patronymic = dbPerson.Patronymic,
                YearBirth = (uint)dbPerson.YearBirth
            };
            return person;
        }

        public static DbPerson? CastToObjDb(IPerson? person)
        {
            if (person == null) return null;
            DbPerson dbPerson = new()
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                Patronymic = person.Patronymic,
                YearBirth = (int)(person.YearBirth ?? 0)
            };
            return dbPerson;
        }
    }
}
