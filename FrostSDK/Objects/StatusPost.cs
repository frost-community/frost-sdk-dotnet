using Newtonsoft.Json;

namespace FrostSDK.Objects
{
	public class StatusPost
	{
		public static StatusPost FromJson(string json)
		{
			return JsonConvert.DeserializeObject<StatusPost>(json);
		}

		[JsonProperty("createdAt")]
		public long CreatedAt { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
