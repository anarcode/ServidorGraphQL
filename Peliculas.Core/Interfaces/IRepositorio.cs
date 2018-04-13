using System.Collections.Generic;

namespace Peliculas.Core.Interfaces
{
    public interface IRepositorio<T>
    {
        T Buscar(int id);

        ICollection<T> Todas();

        int Guardar(T entidad);

        void Borrar(int id);
    }
}