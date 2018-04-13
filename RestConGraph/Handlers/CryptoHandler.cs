namespace RestConGraph.Handlers
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class CryptoHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken)
             .ContinueWith(task =>
             {
                 var response = task.Result;
                 var bytes = response.Content.ReadAsByteArrayAsync().Result;
                 var base64 = Convert.ToBase64String(bytes);
                 response.Content = new StringContent(base64);
                 return response;
             });
        }
    }
}