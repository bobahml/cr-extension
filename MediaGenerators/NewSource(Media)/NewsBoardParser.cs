using System;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;

namespace $rootnamespace$.$foldername$
{
	public sealed class $classnameprefix$BoardParser : NewsBoardParser
    {
		public override async Task<IOneNews[]> ParseAsync(IParseContext parseContext)
		{
			IDocument html = await OpenAsync(parseContext).ConfigureAwait(false);

			var result = html.QuerySelectorAll("")
				.OfType<IHtmlAnchorElement>()
				.Select(__a => CreateOneNews(new Uri(__a.Href, UriKind.Absolute)))
				.ToArray();

			return result;
		}
	}
}
