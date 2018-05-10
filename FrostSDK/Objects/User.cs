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

		public string Id { get; set; }

		[JsonProperty("createdAt")]
		public long CreatedAtRaw { get; set; }

		public DateTime CreatedAt { get => Utility.ParseUnixTime(CreatedAtRaw); }

		public string ScreenName { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
	}
}
