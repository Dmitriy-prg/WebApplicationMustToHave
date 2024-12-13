using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Models
{
    public interface ICompositionType
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор типа произведения.
        /// </summary>
        public uint Id { get; set; }

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
        public required uint Id { get; set; }

        /// <summary>
        /// Возвращает или задает название типа произведения.
        /// </summary>
        public required string Name { get; set; }

        public static CompositionType GetObjFromDb(IDbCompositionType dbCompositionType)
        { 
            return new CompositionType { Id = dbCompositionType.Id, Name = dbCompositionType.Name };
        }
    }
}
