using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Models
{
    public interface ICompositionType
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор типа произведения.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Возвращает или задает название типа произведения.
        /// </summary>
        public string Name { get; set; }
    }

    public class CompositionType : ICompositionType
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор типа произведения.
        /// </summary>
        public required long Id { get; set; }

        /// <summary>
        /// Возвращает или задает название типа произведения.
        /// </summary>
        public required string Name { get; set; }

        public static CompositionType GetObjFromDb(DbCompositionType dbCompositionType)
        { 
            return new CompositionType { Id = dbCompositionType.Id, Name = dbCompositionType.Name };
        }
    }
}
