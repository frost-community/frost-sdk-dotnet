using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrostSDK
{
	public interface IApiRequester
	{
		Task<ApiResponse> RequestAsync(HttpMethod method, string endpoint, string accessToken, IDictionary<string, string> parameters = null, IDictionary<string, string> headers = null);
	}
}
