using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SOproject.Services
{
    public class NavApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private static HttpClient client = null;
        private static Uri BaseAddress = null;

        public NavApiService( IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        //async static Task<T> ConvertToType<T>(HttpResponseMessage response)
        //{
        //    return await response.Content.ReadAsAsync<T>().ConfigureAwait(false);
        //}
        //public async Task<T> Get<T>(string url, params object[] param)
        //{
        //    LoadConfigurations();
        //    return await ConvertToType<T>(await GetHttpClient(PopulateOrderedQueryString(BaseAddress + url, param)).ConfigureAwait(false)).ConfigureAwait(false);

        //    //await GetHttpClient(PopulateOrderedQueryString(BaseAddress + url, param)).ConfigureAwait(false);
        //}

        //async Task<HttpResponseMessage> GetHttpClient(string baseUri)
        //{
        //    var response = await client.GetAsync(baseUri);
        //    return response.EnsureSuccessStatusCode();
        //}
        //private void LoadConfigurations()
        //{
        //    client = CreateHttpClientWithNTLM();
        
        //}

        //static string PopulateOrderedQueryString(string baseUri, object[] data)
        //{
        //    foreach (var obj in data)
        //    {
        //        baseUri = baseUri + "/" + Convert.ToString(obj);
        //    }
        //    return baseUri;
        //}

        //public HttpClient CreateHttpClientWithNTLM()
        //{
        //     BaseAddress = new Uri("http://ns-hou-navdev01.netsync.com:9837/DEVNETSYNC2018/ODataV4/Company(");
        //    //var filter = "No eq 'SO559026'";
        //    //var expand = "SalesOrderSalesLines";
        //    //var uri = new Uri($"{url}'NetSync%20Network%20-%20Live')/SalesOrder?$filter={filter}&$expand={expand}");
        //    // var credentialsCache = new CredentialCache { { uri, "NTLM", CredentialCache.DefaultNetworkCredentials } };

        //    var credentialsCache = new CredentialCache { { BaseAddress, "NTLM", new NetworkCredential("sales", "Netsync01") } };
        //    var handler = new HttpClientHandler { Credentials = credentialsCache };
        //    var httpClient = new HttpClient(handler) { BaseAddress = BaseAddress };
        //    httpClient.DefaultRequestHeaders.ConnectionClose = false;
        //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // //   ServicePointManager.FindServicePoint(BaseAddress).ConnectionLeaseTimeout = 120 * 1000;  // Close connection after two minutes

        //    return httpClient;

        //}

      

    }
}
