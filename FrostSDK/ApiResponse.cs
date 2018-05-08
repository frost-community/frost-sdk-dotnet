namespace FrostSDK
{
	public class ApiResponse
	{
		public ApiResponse(int statusCode, string contentJson = null)
		{
			StatusCode = statusCode;
			ContentJson = contentJson;
		}

		public int StatusCode { get; set; }
		public string ContentJson { get; set; }
	}
}
