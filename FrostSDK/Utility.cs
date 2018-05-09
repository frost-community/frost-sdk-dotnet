using System;

namespace FrostSDK
{
    public class Utility
    {
		private static readonly DateTime _UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public static long SerializeUnixTime(DateTime time)
			=> (long)(time.ToUniversalTime() - _UnixEpoch).TotalSeconds;

		public static DateTime ParseUnixTime(long unixTime)
			=> _UnixEpoch.AddSeconds(unixTime).ToLocalTime();
	}
}
