namespace RestConGraph.Controllers
{
    using Binders;
    using Models;
    using Peliculas.Core.Interfaces;
    using Peliculas.MySQL.Servicios;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Web.Http.ModelBinding;

    [RoutePrefix("pelicula")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PeliculaController : ApiController
    {
        IRepositorio<IPelicula> _repositorio;
        ServiciosPelículas _serviciosPelículas;

        public PeliculaController(IRepositorio<IPelicula> repositorio, ServiciosPelículas servicio)
        {
            _repositorio = repositorio;
            _serviciosPelículas = servicio;
        }

        // POST: api/Pelicula
        [Route()]
        public int Post([ModelBinder(typeof(ModeloBinder))]Pelicula pelicula)
        {
            pelicula.Id = 0;
            return _repositorio.Guardar(pelicula);
        }

        [Route("{idPelicula}/actor/{idActor}")]
        public void Post(int idPelicula, int idActor)
        {
            _serviciosPelículas.AñadirActor(idPelicula, idActor);
        }

        // PUT: api/Pelicula/5
        [Route("{id}")]
        public void Put(int id, [ModelBinder(typeof(ModeloBinder))]Pelicula pelicula)
        {
            pelicula.Id = id;
            _repositorio.Guardar(pelicula);
        }

        // DELETE: api/Pelicula/5
        [Route("{id}")]
        public void Delete(int id)
        {
            _repositorio.Borrar(id);
        }
    }
}