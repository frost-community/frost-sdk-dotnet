using Newtonsoft.Json;

namespace FrostSDK.Objects
{
    public abstract class ApiObject<T>
    {
		public static T FromJson(string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}
	}
}
