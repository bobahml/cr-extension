using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace CrMediaGenerator
{
	public class WizardImplementation : IWizard
	{
		private static ICollection<SourceSection> _sections = new SourceSection[0];

		/// <summary>
		/// This method is called before opening any item that has the OpenInEditor attribute. 
		/// </summary>
		/// <param name="projectItem"></param>
		public void BeforeOpeningFile(ProjectItem projectItem)
		{
		}

		public void ProjectFinishedGenerating(Project project)
		{
		}

		/// <summary>
		/// This method is only called for item templates,  not for project templates.
		/// </summary>
		/// <param name="projectItem"></param>
		public void ProjectItemFinishedGenerating(ProjectItem projectItem)
		{
		}

		/// <summary>
		/// This method is called after the project is created.
		/// </summary>
		public void RunFinished()
		{
		}

		/// <summary>
		/// This method is only called for item templates, not for project templates.  </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public bool ShouldAddProjectItem(string filePath)
		{
			if (filePath.Contains("CollectSourceMessage_"))
			{
				var fn = Path.GetFileNameWithoutExtension(filePath);
				var index = int.Parse(fn.StripPrefix("CollectSourceMessage_"));
				return index < _sections.Count;
			}

			return true;
		}

		public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary,
			WizardRunKind runKind, object[] customParams)
		{
			var inputFileName = GetInputFileName(replacementsDictionary);
			var folderLocation = GetFolderLocation(replacementsDictionary);
			using (var inputForm = new NewSourceForm(inputFileName, folderLocation))
			{
				if (inputForm.ShowDialog() == DialogResult.OK)
				{
					replacementsDictionary.Add("$rootsourceaddress$", inputForm.RootUri);
					replacementsDictionary.Add("$mainpagedescription$", inputForm.MainPageDescription);
					replacementsDictionary.Add("$classnameprefix$", inputForm.ClassNamePrefix);
					replacementsDictionary.Add("$foldername$", inputForm.FolderName);
					replacementsDictionary.Add("$supportedsources$", GegerateSupportedSourceClassCode(inputForm.Sections));
					replacementsDictionary.Add("$windsorcomponents$", GegerateRegistrationsCode(inputForm.Sections, replacementsDictionary));

					_sections = inputForm.Sections;

					for (var i = 0; i < inputForm.Sections.Length; i++)
					{
						var section = inputForm.Sections[i];
						var key = i.ToString("D2");
						replacementsDictionary.Add($"${key}_classname$", section.ClassName);
						replacementsDictionary.Add($"${key}_messageclasscode$", GegerateMessageClassCode(section, inputForm.ClassNamePrefix));
					}
				}
				else
				{
					throw new WizardCancelledException();
				}
			}
		}

		private static string GetInputFileName(IReadOnlyDictionary<string, string> replacementsDictionary)
		{
			string inputFileName;
			if (replacementsDictionary.TryGetValue("$rootname$", out inputFileName))
			{
				inputFileName = inputFileName.AddUrlScheme();
			}
			return inputFileName;
		}

		private static string GetFolderLocation(IReadOnlyDictionary<string, string> replacementsDictionary)
		{
			var solutionPath = replacementsDictionary["$solutiondirectory$"];
			var relativePath = replacementsDictionary["$rootnamespace$"];
			var sepIndex = relativePath.LastIndexOf('.');
			if (sepIndex > 0 && sepIndex < relativePath.Length)
			{
				relativePath = Path.Combine(relativePath.Substring(0, sepIndex),
					relativePath.Substring(sepIndex + 1, relativePath.Length - sepIndex - 1));
			}

			return Path.Combine(solutionPath, relativePath);
		}

		private static string GegerateMessageClassCode(SourceSection section, string classnameprefix)
		{
			return
	$@"internal sealed class {section.ClassName}CollectSourceMessage : CollectSourceMessage 
	{{
		public override Uri Source => {classnameprefix}SupportedSource.{section.ShortClassName}.Url;
	}}";
		}

		private static string GegerateSupportedSourceClassCode(IEnumerable<SourceSection> sections)
		{
			return string.Join(Environment.NewLine, sections.Select(GegerateSupportedSourceClassCode));
		}

		private static string GegerateSupportedSourceClassCode(SourceSection section)
		{
			return
	$@"
		public static readonly SupportedSource {section.ShortClassName} = new SupportedSource
		{{
			Url = new Uri(""{section.Url}"", UriKind.Absolute),
			Description = ""СМИ: {section.Description}""
		}};";
		}

		private static string GegerateMessageRegistrationCode(SourceSection section, string classnameprefix)
		{
			return $@"	
					Component
						.For<IMaterialBinder>()
						.ImplementedBy<{classnameprefix}MaterialBinder>()
						.AsMaterialBinderFor({classnameprefix}SupportedSource.{section.ShortClassName})
						.LifeStyle.Singleton,

					Component
						.For<INewsBoardParser>()
						.ImplementedBy<{classnameprefix}BoardParser>()
						.AsNewsBoardParserFor({classnameprefix}SupportedSource.{section.ShortClassName})
						.LifeStyle.Singleton,

					Component
						.For<ISagaControl>()
						.ImplementedBy<SagaControl<{section.ClassName}CollectSourceMessage>>()
						.AsSagaControlFor({classnameprefix}SupportedSource.{section.ShortClassName})
						.LifeStyle.Singleton";
		}

		private static string GegerateRegistrationsCode(IEnumerable<SourceSection> sections, IReadOnlyDictionary<string, string> replacementsDictionary)
		{
			var classnameprefix = replacementsDictionary["$classnameprefix$"];
			return string.Join($",{Environment.NewLine}", sections.Select(s => GegerateMessageRegistrationCode(s, classnameprefix)));
		}
	}
}