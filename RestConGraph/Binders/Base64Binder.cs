namespace RestConGraph.Binders
{
    using System.Web.Http.Controllers;
    using System.Web.Http.ModelBinding;

    public abstract class Base64Binder : IModelBinder
    {
        public virtual bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var respuesta = actionContext.Request.Content.ReadAsStringAsync().Result;
            var bytes = System.Convert.FromBase64String(respuesta);
            bindingContext.Model = System.Text.Encoding.UTF8.GetString(bytes);
            return true;
        }
    }
}