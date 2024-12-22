using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Repository;

namespace WebApplicationMustToHave.Models
{
    public interface IEntity
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
    }
    
    public interface IViewable
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public uint Id { get; }

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
