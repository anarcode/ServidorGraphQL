namespace Peliculas.MySQL.Modelo
{
    using Core.Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Actores")]
    public class Actor : IActor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }

        internal static Actor FromInterface(IActor entidad)
        {
            return new Actor
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre
            };
        }
    }
}