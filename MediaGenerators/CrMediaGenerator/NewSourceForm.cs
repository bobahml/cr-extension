using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrMediaGenerator
{
	public partial class NewSourceForm : Form
	{
		private readonly string _parentFolder;
		public string FolderName { get; private set; }
		public string ClassNamePrefix { get; private set; }
		public string RootUri { get; private set; }
		public string MainPageDescription { get; private set; }
		public SourceSection[] Sections { get; private set; }

		public NewSourceForm(string inputFileName, string parentFolder)
		{
			_parentFolder = parentFolder;
			InitializeComponent();
			rootAddressUrl.Text = inputFileName;
		}

		private async void Ok_Click(object sender, EventArgs e)
		{
			var rootStr = rootAddressUrl.Text.Trim().AddUrlScheme();

			try
			{
				var uri = new Uri(rootStr);
			}
			catch (Exception)
			{
				var res = MessageBox.Show($"Базовый урл не валиден. {Environment.NewLine} Продолжить?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (res != DialogResult.OK)
				{
					return;
				}
			}

			RootUri = rootStr;
			ClassNamePrefix = rootStr.ConvertToClassName();
			FolderName = ClassNamePrefix.ToLower();
			var existing = Path.Combine(_parentFolder, FolderName);

			if (Directory.Exists(existing))
			{
				var res = MessageBox.Show($"Директория уже существует {Environment.NewLine} {existing} {Environment.NewLine} Попробовать все равно?"
					, "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (res != DialogResult.OK)
					return;
			}

			MainPageDescription = await (needDescription.Checked
				? DescriptionLoader.TryLoadDescriptionFromTitle(rootStr)
				: Task.FromResult(rootStr));

			var sectionsList = string.IsNullOrWhiteSpace(sectionsListText.Text)
				? new[] { rootStr }
				: sectionsListText.Lines;

			if (sectionsList.Length > 40)
			{
				MessageBox.Show("Будет обработано только 40 разделов!");
			}

			var tasks = sectionsList.Select(GenerateSource);

			Sections = await Task.WhenAll(tasks);

			DialogResult = DialogResult.OK;
			Close();
		}

		private async Task<SourceSection> GenerateSource(string url)
		{
			var uri = url.AddUrlScheme();
			var section = new SourceSection
			{
				Url = uri,
				ClassName = uri.ConvertToClassName(),
			};

			var shortNameString = uri.StripPrefix(RootUri).Trim(StringExtensions.AllowedExtraCharacters.ToArray());
			section.ShortClassName = !string.IsNullOrEmpty(shortNameString) ? shortNameString.ConvertToClassName() : "All";

			if (needDescription.Checked)
				section.Description = await DescriptionLoader.TryLoadDescriptionFromTitle(section.Url);
			else
				section.Description = section.Url;

			return section;
		}



		private void Cancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
