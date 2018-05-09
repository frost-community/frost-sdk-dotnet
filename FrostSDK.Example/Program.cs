using System;
using System.Threading.Tasks;

namespace FrostSDK.Example
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var apiUrl = "http://localhost:8000";
			var accessToken = "set_your_access_token";

			var api = new RestApi(accessToken, apiUrl);

			while (true)
			{
				Console.Write("投稿内容(exit=終了) > ");
				var text = Console.ReadLine();
				if (text == "exit") break;

				try
				{
					Console.Write("ポストを投稿しています...");
					var statusPost = await api.CreateStatusPost(text);
					Console.WriteLine($"成功しました！ Text={statusPost.Text} CreatedAt={statusPost.CreatedAt}");
				}
				catch(Exception ex)
				{
					Console.WriteLine($"失敗しました: {ex.Message}");
				}
			}
		}
	}
}
