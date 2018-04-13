namespace RestConGraph.Controllers
{
    using Binders;
    using Core;
    using Graph;
    using GraphQL;
    using GraphQL.Types;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Web.Http.ModelBinding;

    [Route("GraphQL")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GraphQLController : ApiController
    {
        GraphQLQuery _query;

        public GraphQLController(GraphQLQuery query)
        {
            _query = query;
        }

        [HttpGet]
        public string Get()
        {
            return "ok";
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([ModelBinder(typeof(ConsultaBinder))]Consulta consulta)
        {
            var schema = new Schema { Query = _query };
            var result = await new DocumentExecuter().ExecuteAsync(options =>
            {
                options.Schema = schema;
                options.Query = consulta;
            })
            .ConfigureAwait(false);

            var resultado = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            resultado.Content = new StringContent(JsonConvert.SerializeObject(result.Data), Encoding.UTF8, "application/json");

            return resultado;
        }
    }
}