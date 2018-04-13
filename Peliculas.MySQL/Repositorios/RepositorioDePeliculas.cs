namespace Peliculas.MySQL.Repositorios
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Interfaces;
    using Modelo;

    public class RepositorioDePeliculas : IRepositorio<IPelicula>
    {
        ModeloPeliculas _modelo;

        internal RepositorioDePeliculas(ModeloPeliculas modelo)
        {
            _modelo = modelo; // new ModeloPeliculas();
        }

        public IPelicula Buscar(int id)
        {
            return _modelo.Peliculas.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<IPelicula> Todas()
        {
            return new List<IPelicula>(_modelo.Peliculas.ToArray());
        }

        public int Guardar(IPelicula entidad)
        {
            int resultado = 0;
            if(entidad.Id == 0)
            {
                entidad.Id = _modelo.Peliculas.Max(p => p.Id) + 1;
                Pelicula pelicula = Pelicula.FromInterface(entidad);
                _modelo.Peliculas.Add(pelicula);
                resultado = entidad.Id;
            }
            else
            {
                var actualizacion = _modelo.Peliculas.Where(p => p.Id == entidad.Id).FirstOrDefault();
                if(actualizacion != null)
                {
                    _modelo.Entry(actualizacion).CurrentValues.SetValues(entidad);
                    resultado = entidad.Id;
                }
            }
            
            _modelo.SaveChanges();
            return resultado;
        }

        public void Borrar(int id)
        {
            var pelicula = _modelo.Peliculas.Where(p => p.Id == id).FirstOrDefault();
            if (pelicula != null)
            {
                _modelo.Peliculas.Remove(pelicula);
                _modelo.SaveChanges();
            }
        }
    }
}