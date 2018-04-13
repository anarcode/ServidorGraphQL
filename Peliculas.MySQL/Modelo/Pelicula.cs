namespace Peliculas.MySQL.Modelo
{
    using Core.Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Peliculas")]
    public class Pelicula : IPelicula
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        public virtual ICollection<Actor> Actores { get; set; }

        internal static Pelicula FromInterface(IPelicula entidad)
        {
            return new Pelicula
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre
            };
        }
    }
}