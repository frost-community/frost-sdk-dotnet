using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrostSDK.Example
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var apiUrl = "http://localhost:8000";
			var accessToken = "set_your_access_token";

			var requester = new HttpApiRequester(apiUrl);

			while (true)
			{
				Console.Write("投稿内容(exit=終了) > ");
				var text = Console.ReadLine();
				if (text == "exit") break;

				Console.Write("ポストを投稿しています...");
				var res = await requester.RequestAsync(HttpMethod.Post, "/posts/post_status", accessToken, new Dictionary<string, string> { ["text"] = text + text });
				if (res.StatusCode == 200)
				{
					Console.WriteLine("成功しました！");
				}
				else
				{
					Console.WriteLine("失敗しました。。");
					Console.WriteLine(res.ContentJson);
				}
			}
		}
	}
}
