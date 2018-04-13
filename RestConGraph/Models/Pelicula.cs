namespace RestConGraph.Models
{
    using Peliculas.Core.Interfaces;

    public class Pelicula : IPelicula
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
    }
}