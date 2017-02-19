using System.Collections.Generic;
using System.Text;

namespace CrMediaGenerator
{
	internal static class StringExtensions
	{
		#region Translit

		private static readonly Dictionary<char, string> Transliter = new Dictionary<char, string>
		{
			{'à', "a"},
			{'á', "b"},
			{'â', "v"},
			{'ã', "g"},
			{'ä', "d"},
			{'å', "e"},
			{'¸', "yo"},
			{'æ', "zh"},
			{'ç', "z"},
			{'è', "i"},
			{'é', "j"},
			{'ê', "k"},
			{'ë', "l"},
			{'ì', "m"},
			{'í', "n"},
			{'î', "o"},
			{'ï', "p"},
			{'ð', "r"},
			{'ñ', "s"},
			{'ò', "t"},
			{'ó', "u"},
			{'ô', "f"},
			{'õ', "h"},
			{'ö', "c"},
			{'÷', "ch"},
			{'ø', "sh"},
			{'ù', "sch"},
			{'ú', "j"},
			{'û', "i"},
			{'ü', "j"},
			{'ý', "e"},
			{'þ', "yu"},
			{'ÿ', "ya"}
		};

		public static string Transliterate(this string sourceText)
		{
			var ans = new StringBuilder();
			foreach (var c in sourceText)
			{
				string repl;
				if (Transliter.TryGetValue(c, out repl))
				{
					ans.Append(repl);
				}
				else
				{
					ans.Append(c);
				}
			}
			return ans.ToString();
		}

		#endregion

		#region ExtraCharacters
		public static readonly HashSet<char> AllowedExtraCharacters = new HashSet<char>
		{
			'/',
			'.',
			'?',
			'!',
			'-',
			'~',
			'_',
			'&',
			'$',
			'\'',
			'[',
			']',
			'(',
			')',
			'=',
			'+',
			'*',
			',',
			':',
			'#',
			'%',
			'@',
		};

		public static string ToPascalCase(this string sourceText)
		{
			if (string.IsNullOrEmpty(sourceText))
				return string.Empty;

			var ans = new StringBuilder();
			var firstChar = sourceText[0];
			if (char.IsDigit(firstChar))
			{
				ans.Append($"Http{firstChar}");
			}
			else
			{
				ans.Append(char.ToUpper(firstChar));
			}

			for (var i = 1; i < sourceText.Length; i++)
			{
				var prevCharIsExtraChar = false;
				while (i < sourceText.Length && AllowedExtraCharacters.Contains(sourceText[i]))
				{
					prevCharIsExtraChar = true;
					i++;
				}
				if (i >= sourceText.Length)
					break;

				ans.Append(prevCharIsExtraChar ? char.ToUpper(sourceText[i]) : sourceText[i]);
			}
			return ans.ToString();
		}


		public static string StipScheme(this string uriStr)
		{
			return uriStr.Trim().TrimEnd('/')
				.StripPrefix("https://")
				.StripPrefix("http://")
				.StripPrefix("www.");
		}



		#endregion


		public static string ConvertToClassName(this string uriStr)
		{
			var lower = uriStr.ToLower();
			uriStr = lower.StipScheme();
			uriStr = uriStr.Transliterate();
			uriStr = uriStr.ToPascalCase();

			return uriStr;
		}


		public static string AddUrlScheme(this string uriStr)
		{
			var lower = uriStr.Trim().ToLower();
			if (!lower.StartsWith("http"))
			{
				lower = $"http://{lower}";
			}

			return lower;
		}


		public static string StripPrefix(this string text, string prefix)
		{
			return text.StartsWith(prefix) ? text.Substring(prefix.Length) : text;
		}
	}
}