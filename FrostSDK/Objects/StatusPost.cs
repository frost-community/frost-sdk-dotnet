using Newtonsoft.Json;
using System;

namespace FrostSDK.Objects
{
	public class StatusPost
	{
		private StatusPost() { }

		/// <summary>
		/// JSONデータからクラスのインスタンスを生成します。
		/// </summary>
		public static StatusPost FromJson(string json)
		{
			return JsonConvert.DeserializeObject<StatusPost>(json);
		}

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("createdAt")]
		public long CreatedAtRaw { get; set; }

		public DateTime CreatedAt { get => Utility.ParseUnixTime(CreatedAtRaw); }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("user")]
		public User User { get; set; }
	}
}
