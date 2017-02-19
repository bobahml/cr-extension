using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrMediaGenerator
{
	internal static class DescriptionLoader
	{
		private static readonly Regex TitleRegex = new Regex(@"<title>(?<title>.*)<\/title>");

		public static async Task<string> TryLoadDescriptionFromTitle(string sectionUrl)
		{
			try
			{
				using (var client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = true, UseCookies = true }))
				{
					client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36");
					client.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
					var req = await client.GetAsync(new Uri(sectionUrl)).ConfigureAwait(false);
					if (!req.IsSuccessStatusCode)
					{
						return sectionUrl;
					}

					var str = await req.Content.ReadAsStringAsync().ConfigureAwait(false);
					var match = TitleRegex.Match(str);
					if (match.Success)
					{
						return match.Groups["title"].Value.Trim();
					}
					return sectionUrl;
				}
			}
			catch (Exception)
			{
				return sectionUrl;
			}
		}
	}
}