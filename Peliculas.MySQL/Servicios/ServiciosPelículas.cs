namespace Peliculas.MySQL.Servicios
{
    using System.Linq;
    using Modelo;

    public class ServiciosPelículas
    {
        ModeloPeliculas _modelo;

        internal ServiciosPelículas(ModeloPeliculas modelo)
        {
            _modelo = modelo; // new ModeloPeliculas();
        }

        public void AñadirActor(int idPelícula, int idActor)
        {
            var pelicula = _modelo.Peliculas.Where(p => p.Id == idPelícula).FirstOrDefault();
            if(pelicula != null)
            {
                var actor = _modelo.Actores.Where(a => a.Id == idActor).FirstOrDefault();
                if(actor != null && !pelicula.Actores.Contains(actor))
                {
                    pelicula.Actores.Add(actor);
                    _modelo.SaveChanges();
                }
            }
        }
    }
}