using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Core.WebScraperLibrary
{
	public class HtmlParser
	{
		static public int FindText(string source, string token, int startIndex)
		{
			return source.IndexOf(token, startIndex);
		}

		static public ParseResult GetCnCircledContentDiv(string source, int startIndex)
		{
			string startToken = $"<div class=\"cn-circled-content\"";
			string endToken = $"<!-- END .cn-circled-content -->";

			int divStartIndex = FindText(source, startToken, startIndex);
			if (divStartIndex < 0) return new ParseResult("", 0, 0);

			int divEndIndex = FindText(source, endToken, startIndex + startToken.Length);
			if (divEndIndex < 0) throw new Exception("End token not found");

			StringBuilder sb = new StringBuilder(divEndIndex - divStartIndex + 1);
			int pos = divStartIndex;
			for (pos = divStartIndex; pos < divEndIndex; ++pos)
			{
				sb.Append(source[pos]);
			}
			string html = sb.ToString().TrimEnd();
			return new ParseResult(html, divStartIndex, pos);
		}


		static public string ParseCircledContentSpanHtml(string source, string htmlTag, string cssClass)
		{
			string startToken = $"<{htmlTag} class=\"{cssClass}\">";
			string endToken = $"</{htmlTag}>";

			int startPos = FindText(source, startToken, 0);
			if (startPos < 0) return "";
			int endPos = FindText(source, endToken, startPos + 1);
			if (endPos < 0) throw new Exception($"End token {endToken} not found");

			int trueStart = startPos + startToken.Length;

			string content = source.Substring(trueStart, endPos - trueStart);
			return content;
		}

		static public string ParseSlug(string source)
		{
			string startToken = $"href=\"https://oovar.ohioartscouncil.org/name/";
			string endToken = $"#top";

			int startPos = FindText(source, startToken, 0);
			if (startPos < 0) return "";
			int endPos = FindText(source, endToken, startPos + 1);
			if (endPos < 0) throw new Exception($"End token {endToken} not found");

			int trueStart = startPos + startToken.Length;

			string content = source.Substring(trueStart, endPos - trueStart);
			return content;
		}


		static public ArtistResult ParseArtistResult(string source)
		{
			ArtistResult result = new ArtistResult();

			result.Slug = ParseSlug(source);

			string htmlTag = "span";
			string cssClass = "given-name";
			string value = HtmlParser.ParseCircledContentSpanHtml(source, htmlTag, cssClass);

			result.GivenName = value;

			cssClass = "family-name";
			value = HtmlParser.ParseCircledContentSpanHtml(source, htmlTag, cssClass);
			result.FamilyName = value;

			return result;
		}

	}  // end of class
}  // end of namespace
