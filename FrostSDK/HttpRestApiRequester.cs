using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FrostSDK
{
	public class HttpRestApiRequester : IRestApiRequester
	{
		private const string ContentType = "application/json";

		public HttpRestApiRequester(string apiUrl, HttpClient httpClient = null)
		{
			ApiUrl = new Uri(apiUrl);
			_HttpHandler = new HttpClientHandler { UseCookies = false };
			_Http = httpClient ?? new HttpClient(_HttpHandler);
		}

		private HttpClient _Http { get; set; }
		private HttpClientHandler _HttpHandler { get; set; }
		public Uri ApiUrl { get; set; }

		public async Task<RestApiResponse> RequestAsync(HttpMethod method, string endpoint, string accessToken, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null)
		{
			var bodyMode = method != HttpMethod.Get && method != HttpMethod.Head;

			parameters = parameters ?? new Dictionary<string, string>();
			headers = headers ?? new Dictionary<string, string>();

			var query = "";

			if (!bodyMode)
			{
				var queryPairs = parameters.Select(p => $"{HttpUtility.UrlEncode(p.Key)}={HttpUtility.UrlEncode(p.Value)}");
				var queryContent = string.Join("&", queryPairs);
				query = $"?{queryContent}";
			}

			if (endpoint[0] == '/')
				endpoint = endpoint.Remove(0, 1);

			var request = new HttpRequestMessage(method, new Uri(ApiUrl, $"{endpoint}{query}"));
			foreach(var header in headers)
			{
				request.Headers.Add(header.Key, header.Value);
			}
			request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
			if (bodyMode)
			{
				var bodyJson = Newtonsoft.Json.JsonConvert.SerializeObject(parameters);
				request.Content = new StringContent(bodyJson);
				request.Content.Headers.ContentType.MediaType = ContentType;
			}

			var response = await _Http.SendAsync(request);
			var responseJson = await response.Content.ReadAsStringAsync();

			if (response.Content.Headers.ContentType.MediaType.ToLower() != ContentType)
			{
				throw new Exception("response is not json format");
			}

			return new RestApiResponse((int)response.StatusCode, responseJson);
		}
	}
}
