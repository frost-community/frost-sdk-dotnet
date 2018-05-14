using Newtonsoft.Json;
using System;

namespace FrostSDK.Objects
{
	public class StatusPost : IPost
	{
		private StatusPost() { }

		/// <summary>
		/// JSONデータからクラスのインスタンスを生成します。
		/// </summary>
		public static StatusPost FromJson(string json)
		{
			return JsonConvert.DeserializeObject<StatusPost>(json);
		}

		public string Id { get; set; }

		[JsonProperty("createdAt")]
		public long CreatedAtRaw { get; set; }

		public DateTime CreatedAt { get => Utility.ParseUnixTime(CreatedAtRaw); }

		public string Type { get; set; }

		public string Text { get; set; }

		public User User { get; set; }
	}
}
