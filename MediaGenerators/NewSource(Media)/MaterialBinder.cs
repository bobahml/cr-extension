using System;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using Mindscan.Media.DomainObjects.Integration;

namespace $rootnamespace$.$foldername$
{
	public class $classnameprefix$MaterialBinder: MaterialBinder
    {
		public override async Task<Material> BindAsync(IBindContext context)
		{
			IDocument document = await OpenAsync(context).ConfigureAwait(false);

			Material material = new Material
			{
				SourceName = $classnameprefix$SupportedSource.SourceName
			};

			BindLinks(document, material);
			BindText(document, material);
			BindTitle(document, material);
			BindPublishedAt(document, material);
			BindAuthor(document, material);

			return material;
		}

		private static void BindText(IDocument document, Material model)
		{

		}

		private static void BindTitle(IDocument document, Material model)
		{

		}

		private static void BindLinks(IDocument document, Material model)
		{

		}

		private void BindPublishedAt(IDocument document, Material material)
		{

		}

		private void BindAuthor(IDocument document, Material material)
		{

		}
	}
}
