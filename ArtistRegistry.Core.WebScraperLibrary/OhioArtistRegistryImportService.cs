using ArtistEntryRegistry.Standard.Data.Providers;
using ArtistRegistry.Standard.Common;
using ArtistRegistry.Standard.Data;
using ArtistRegistry.Standard.Data.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Core.WebScraperLibrary
{
	public class OhioArtistRegistryImportService
	{

		static public async Task ImportAll()
		{
			FirstLetterProvider firstLetterProvider = new FirstLetterProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
			List<FirstLetter> list = await firstLetterProvider.GetFirstLettersAsync();
			foreach (var firstLetterEntity in list)
			{
				for (int page = 1; page <= firstLetterEntity.PageCount; ++page)
				{
					try
					{
						await ImportIndexPage(firstLetterEntity.FirstLetterId, page);
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Failed to parse/upsert {firstLetterEntity.FirstLetterId} for page {page}.  {ex.Message}");
						Console.WriteLine(ex.StackTrace);
					}
				}
			}
		}

		static public async Task ImportFirstLetter(string firstLetter)
		{
			FirstLetterProvider firstLetterProvider = new FirstLetterProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
			List<FirstLetter> list = await firstLetterProvider.GetFirstLettersAsync();
			foreach (var firstLetterEntity in list)
			{
				if (firstLetterEntity.FirstLetterId != firstLetter) continue;
				for (int page = 1; page <= firstLetterEntity.PageCount; ++page)
				{
					await ImportIndexPage(firstLetter, page);
				}
			}
		}

		static public async Task ImportIndexPage( string firstLetter, int pageNumber)
		{
			string folder = @"M:\Visual Studio Solutions\ArtistRegistry\OhioArtistryPages\Index\";
			string fileName = $"{firstLetter.ToUpper()}-{pageNumber}.html";
			if (pageNumber == 1)
			{
				folder = @"M:\Visual Studio Solutions\ArtistRegistry\OhioArtistryPages\FirstLetter";
				fileName = $"{firstLetter.ToUpper()}.html";
			}


			string fullPathAndFileName = Path.Combine(folder, fileName);
			string source = File.ReadAllText(fullPathAndFileName);

			ArtistEntryProvider artistEntryProvider = new ArtistEntryProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
			ContactProvider contactProvider = new ContactProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
			ArtistProvider artistProvider = new ArtistProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);

			int count = 0;
			int startIndex = 0;
			while (true)
			{
				ParseResult result = HtmlParser.GetCnCircledContentDiv(source, startIndex);
				if (result.HasValue == false) break;

				startIndex = result.EndIndex + 1;


				ArtistResult artistResult = HtmlParser.ParseArtistResult(result.Content);
				ArtistEntry artistEntry = new ArtistEntry();
				artistEntry.ContentFileName = fullPathAndFileName;
				artistEntry.ArtistId = null;
				artistEntry.FirstLetterId = firstLetter.ToUpper();
				artistEntry.Slug = artistResult.Slug;
				artistEntry.Url = $"https://oovar.ohioartscouncil.org/name/{artistEntry.Slug}#top/";

				ArtistEntry existing = await artistEntryProvider.GetByIdAsync(firstLetter.ToUpper(), artistResult.Slug);
				if (existing == null)
				{
					await artistEntryProvider.InsertArtistEntryAsync(artistEntry);
				}

				if (artistEntry.ArtistId == null)
				{
					Contact contact = artistResult.BuildContact(artistEntry.Url);

					contact.ContactId = await contactProvider.InsertContactAsync(contact);
					await artistProvider.InsertArtistAsync(contact.ContactId);

					artistEntry.ArtistId = contact.ContactId;

					await artistEntryProvider.UpdateArtistEntryAsync(artistEntry);
				}
				else
				{

				}


				//Console.WriteLine("=================================");
				//Console.WriteLine(result.Content);
				//Console.WriteLine("");
				++count;
			}

			Console.WriteLine($"Found {count} entries");

		}

	}  // end of class
}  // end of namespace
