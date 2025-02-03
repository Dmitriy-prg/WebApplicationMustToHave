using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Repository;

namespace WebApplicationMustToHave.Models
{
    public interface IBaseEntity<T>
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public T Id { get; set; }
    }

    public interface IEntity : IBaseEntity<long>
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
    }
    
    public interface IViewable : IBaseEntity<long>
    {
        /// <summary>
        /// Получает строку-представление.
        /// </summary>
        public string View { get; }
    }

    public interface IDbLinkable<T> where T : IEntity
    {
        public static T? GetObjFromDb(T? val) => val;

        public static T? CastToObjDb(T? val) => val;
    }
}
