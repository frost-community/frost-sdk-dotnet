using FrostSDK.Objects;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FrostSDK.Example
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var accessToken = "set_your_access_token";
			var userId = "set_your_user_id";
			var apiUrl = "http://localhost:8000";

			var frost = new RestApi(accessToken, apiUrl);

			while (true)
			{
				Console.WriteLine("commands:");
				Console.WriteLine("- post (message)");
				Console.WriteLine("- timeline home");
				Console.WriteLine("- exit");
				Console.Write("> ");
				var command = Console.ReadLine();
				Console.WriteLine();

				if (command.StartsWith("exit"))
				{
					break;
				}
				else if (command.StartsWith("timeline home"))
				{
					var timeline = await frost.GetHomeTimeline(userId);

					Console.WriteLine("-- Timeline --");

					foreach (var post in timeline)
					{
						var statusPost = post as StatusPost;
						Console.WriteLine($"@{statusPost.User.ScreenName}さん - {statusPost.Text}");
					}
					Console.WriteLine();
				}
				else if (Regex.IsMatch(command, "^post .+"))
				{
					var message = Regex.Match(command, "^post (.+)").Groups[1].Value;
					try
					{
						Console.Write("ポストを投稿しています...");
						var statusPost = await frost.CreateStatusPost(message);
						Console.WriteLine($"成功しました！ Text={statusPost.Text} CreatedAt={statusPost.CreatedAt}");
					}
					catch (Exception ex)
					{
						Console.WriteLine($"失敗しました: {ex.Message}");
					}
					Console.WriteLine();
				}
				else
				{
				}
			}
		}
	}
}
