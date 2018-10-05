using Architect.Repositories.Abstractions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Architect.Repositories.WebRepositories
{
    public abstract class BaseWebRepository
    {
        protected CancellationTokenSource cancellationToken;
        private string baseUrl;
        private RestClient client;
        public BaseWebRepository(string baseUrl)
        {
            this.baseUrl = baseUrl;
            client = new RestClient();
        }

        private async Task<IRestResponse<K>> ExecuteAsync<K>(RestRequest request)
        {
            cancellationToken = new CancellationTokenSource();
            var result = await client.ExecuteTaskAsync<K>(request, cancellationToken.Token).ConfigureAwait(false);
            if (result.ErrorException == null) return result;
            if (result.StatusCode == 0) result.StatusCode = HttpStatusCode.BadGateway;
            throw result.ErrorException;
        }

        protected async Task<K> Request<K>(string url)
        {
            var request = new RestRequest(url);
            var result = await ExecuteAsync<K>(request).ConfigureAwait(false);
            return result.Data;
        }

        protected void Abort()
        {
            if (cancellationToken != null)
                cancellationToken.Cancel();
        }
    }
}
