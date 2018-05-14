using Newtonsoft.Json;
using System;

namespace FrostSDK.Objects
{
    public class User : ApiObject<User>
	{
		private User() { }

		public string Id { get; set; }

		[JsonProperty("createdAt")]
		public long CreatedAtRaw { get; set; }

		public DateTime CreatedAt { get => Utility.ParseUnixTime(CreatedAtRaw); }

		public string ScreenName { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
	}
}
