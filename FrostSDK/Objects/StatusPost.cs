using Newtonsoft.Json;
using System;

namespace FrostSDK.Objects
{
	public class StatusPost : ApiObject<StatusPost>, IPost
	{
		private StatusPost() { }

		public string Id { get; set; }

		[JsonProperty("createdAt")]
		public long CreatedAtRaw { get; set; }

		public DateTime CreatedAt { get => Utility.ParseUnixTime(CreatedAtRaw); }

		public string Type { get; set; }

		public string Text { get; set; }

		public User User { get; set; }
	}
}
