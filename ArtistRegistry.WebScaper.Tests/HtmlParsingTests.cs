using ArtistEntryRegistry.Standard.Data.Providers;
using ArtistRegistry.Core.WebScraperLibrary;
using ArtistRegistry.Standard.Common;
using ArtistRegistry.Standard.Data;
using ArtistRegistry.Standard.Data.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.WebScaper.Tests
{
	[TestClass]
	public class HtmlParsingTests
	{
		public string LoadContentFile(string fileName)
		{
			return File.ReadAllText(fileName);
		}

		[TestMethod]
		public void TestParseContentDiv()
		{
			string source = LoadContentFile(@"M:\Visual Studio Solutions\ArtistRegistry\OhioArtistryPages\Index\A-2.html");

			int count = 0;
			int startIndex = 0;
			while (true)
			{
				ParseResult result = HtmlParser.GetCnCircledContentDiv(source, startIndex);
				if (result.HasValue == false) break;

				startIndex = result.EndIndex + 1;

				Console.WriteLine("=================================");
				Console.WriteLine(result.Content);
				Console.WriteLine("");
				++count;
			}

			Console.WriteLine($"Found {count} entries");

		}

		[TestMethod]
		public void TestParseContentFields()
		{
			string source = File.ReadAllText(@"M:\Visual Studio Solutions\ArtistRegistry\ArtistRegistry.WebScaper.Tests\SampleEntry.html");

			string slug;
			slug = HtmlParser.ParseSlug(source);
			Console.WriteLine($"Slug={slug}");


			string htmlTag = "span";
			string cssClass = "given-name";
			string value = HtmlParser.ParseCircledContentSpanHtml(source, htmlTag, cssClass);
			Console.WriteLine($"{cssClass}={value}");

			//cssClass = "family-name";
			//value = HtmlParser.ParseCircledContentSpanHtml(source, htmlTag, cssClass);
			//Console.WriteLine($"{cssClass}={value}");

			htmlTag = "div";
			cssClass = "cn-excerpt";
			value = HtmlParser.ParseCircledContentSpanHtml(source, htmlTag, cssClass);
			Console.WriteLine($"{cssClass}={value}");

		}

		[TestMethod]
		public async Task TestParseAndUpsertIndexFile()
		{
			await OhioArtistRegistryImportService.ImportIndexPage("D", 1);

		}

		[TestMethod]
		public async Task TestParseAndUpsertFirstLetter()
		{
			await OhioArtistRegistryImportService.ImportFirstLetter("F");

		}

		[TestMethod]
		public async Task TestParseAndUpsertAll()
		{
			await OhioArtistRegistryImportService.ImportAll();

		}

	}  // end of class
}  // end of namespace
