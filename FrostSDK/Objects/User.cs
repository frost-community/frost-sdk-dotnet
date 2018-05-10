using Newtonsoft.Json;
using System;

namespace FrostSDK.Objects
{
    public class User
    {
		private User() { }

		/// <summary>
		/// JSONデータからクラスのインスタンスを生成します。
		/// </summary>
		public static User FromJson(string json)
		{
			return JsonConvert.DeserializeObject<User>(json);
		}

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("createdAt")]
		public long CreatedAtRaw { get; set; }

		public DateTime CreatedAt { get => Utility.ParseUnixTime(CreatedAtRaw); }

		[JsonProperty("screenName")]
		public string ScreenName { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }
	}
}
