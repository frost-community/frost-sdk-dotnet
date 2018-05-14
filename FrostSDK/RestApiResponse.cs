namespace FrostSDK
{
	public class RestApiResponse
	{
		public RestApiResponse(int statusCode, string contentJson = null)
		{
			StatusCode = statusCode;
			ContentJson = contentJson;
		}

		public int StatusCode { get; set; }
		public string ContentJson { get; set; }
	}
}
