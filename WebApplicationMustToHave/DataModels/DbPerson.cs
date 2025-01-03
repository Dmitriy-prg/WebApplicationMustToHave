﻿using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.DataModels
{
    /// <summary>
    /// Представляет интерфейс человека с идентификатором, именем, фамилией и необязательными полями для указания отчества и года рождения.
    /// </summary>
    public interface IDbPerson
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
    /// Представляет объект человека с идентификатором, именем, фамилией и необязательными полями для указания отчества и года рождения.
    ///  Реализует интерфейс IDbPerson.
    /// </summary>
    public class DbPerson : IDbPerson, IViewable
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
        /// Навигационное свойство.
        /// </summary>
        public List<DbComposition>? DbComposition_Authors { get; set; }
        /// <summary>
        /// Навигационное свойство.
        /// </summary>
        public List<DbComposition>? DbComposition_Performers { get; set; }
        /// <summary>
        /// Навигационное свойство.
        /// </summary>
        public List<DbComposition>? DbComposition_Composers { get; set; }
        /// <summary>
        /// Навигационное свойство.
        /// </summary>
        public List<DbComposition>? DbComposition_Directors { get; set; }

        /// <summary>
        /// Получает строку-представление человека.
        /// </summary>
        public string View { get => Name + " " + Surname + " " + Patronymic ?? "" + " " + YearBirth + " г." ?? ""; }
    }
}
