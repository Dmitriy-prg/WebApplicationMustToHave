using WebApplicationMustToHave.DataModels;

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
        uint Id { get; set; }

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
    public class Person : IPerson, IDbPerson<uint, uint?>, IViewable
    {
        /// <summary>
        /// Уникальный идентификатор человека.
        /// </summary>
        public required uint Id { get; set; }

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
    }
}
