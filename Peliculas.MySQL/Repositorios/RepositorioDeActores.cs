namespace Peliculas.MySQL.Repositorios
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Interfaces;
    using Modelo;

    public class RepositorioDeActores : IRepositorio<IActor>
    {
        ModeloPeliculas _modelo;

        internal RepositorioDeActores(ModeloPeliculas modelo)
        {
            _modelo = modelo;
        }

        public IActor Buscar(int id)
        {
            return _modelo.Actores.Where(a => a.Id == id).FirstOrDefault();
        }

        public ICollection<IActor> Todas()
        {
            return new List<IActor>(_modelo.Actores.ToArray());
        }

        public int Guardar(IActor entidad)
        {
            int resultado = 0;
            if(entidad.Id == 0)
            {
                entidad.Id = _modelo.Actores.Max(p => p.Id) + 1;
                Actor actor = Actor.FromInterface(entidad);
                _modelo.Actores.Add(actor);
                resultado = entidad.Id;
            }
            else
            {
                var actualizacion = _modelo.Actores.Where(p => p.Id == entidad.Id).FirstOrDefault();
                if(actualizacion != null)
                {
                    _modelo.Entry(actualizacion).CurrentValues.SetValues(entidad);
                }
                resultado = entidad.Id;
            }
            
            _modelo.SaveChanges();
            return resultado;
        }

        public void Borrar(int id)
        {
            var actor = _modelo.Actores.Where(p => p.Id == id).FirstOrDefault();
            if (actor != null)
            {
                _modelo.Actores.Remove(actor);
                _modelo.SaveChanges();
            }
        }
    }
}