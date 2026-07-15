using ArtistRegistry.Core.WebScraperLibrary;
using ArtistRegistry.Standard.Common;
using ArtistRegistry.Standard.Data;
using FirstLetterRegistry.Standard.Data.Providers;

namespace ArtistRegistry.WebScaper.Tests
{
	[TestClass]
	public sealed class WebScraperTests
	{

		[TestMethod]
		public async Task TestUpdateFirstLetterData()
		{
			FirstLetterProvider provider = new FirstLetterProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);

			List<FirstLetter> list = await provider.GetFirstLettersAsync();
			Console.WriteLine($"There are {list.Count} items");

			FirstLetter a = list[0];
			a.PageCount = 1;
			await provider.UpdateFirstLetterAsync(a);
		}


		[TestMethod]
		public async Task ScapeFirstLetterPages()
		{
			FirstLetterProvider provider = new FirstLetterProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);

			List<FirstLetter> list = await provider.GetFirstLettersAsync();
			Console.WriteLine($"There are {list.Count} items");

			string outputFolder = @"M:\Visual Studio Solutions\ArtistRegistry\OhioArtistryPages\FirstLetter";


			foreach (var firstLetter in list)
			{
				if (firstLetter.FirstLetterId == "A") continue;
				if (firstLetter.FirstLetterId == "B") continue;
				if (firstLetter.FirstLetterId == "C") continue;
				if (firstLetter.FirstLetterId == "D") continue;
				if (firstLetter.FirstLetterId == "E") continue;
				if (firstLetter.FirstLetterId == "F") continue;
				if (firstLetter.FirstLetterId == "G") continue;
				if (firstLetter.FirstLetterId == "H") continue;
				if (firstLetter.FirstLetterId == "I") continue;


				Console.WriteLine($"Processing {firstLetter.FirstLetterId}");
				try
				{
					OhioArtistScaperService service = new OhioArtistScaperService();
					service.DownloadContentForFirstLetter(firstLetter, outputFolder);

					await provider.UpdateFirstLetterAsync(firstLetter);

					System.Threading.Thread.Sleep(1000 * 10);
				}
				catch (Exception ex)
				{
					Console.WriteLine("**********************");
					Console.WriteLine(ex.Message);
					return;
				}
			}
		}

		[TestMethod]
		public void TestParseFirstLetterPageCount()
		{
			char character = 'e';
			string outputFolder = @"M:\Visual Studio Solutions\ArtistRegistry\OhioArtistryPages\FirstLetter";
			string fileName = Path.Combine(outputFolder, "e.html");
			int count = OhioArtistScaperService.CountPages(character, fileName);
			Console.WriteLine($"Count={count}");
		}

		[TestMethod]
		public async Task ScapeIndexPages()
		{
			FirstLetterProvider provider = new FirstLetterProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);

			List<FirstLetter> list = await provider.GetFirstLettersAsync();
			Console.WriteLine($"There are {list.Count} items");

			string outputFolder = @"M:\Visual Studio Solutions\ArtistRegistry\OhioArtistryPages\Index";


			foreach (var firstLetter in list)
			{
				if (firstLetter.FirstLetterId == "A") continue;
				if (firstLetter.FirstLetterId == "B") continue;
				if (firstLetter.FirstLetterId == "C") continue;
				if (firstLetter.FirstLetterId == "D") continue;
				if (firstLetter.FirstLetterId == "E") continue;
//				if (firstLetter.FirstLetterId == "F") return;
				//if (firstLetter.FirstLetterId == "G") continue;
				//if (firstLetter.FirstLetterId == "H") continue;
				//if (firstLetter.FirstLetterId == "I") continue;


				Console.WriteLine($"Processing {firstLetter.FirstLetterId}");
				try
				{
					OhioArtistScaperService.DownloadIndexPages(firstLetter, outputFolder);

					System.Threading.Thread.Sleep(1000 * 20);
				}
				catch (Exception ex)
				{
					Console.WriteLine("**********************");
					Console.WriteLine(ex.Message);
					return;
				}
			}
		}



	}  // end of class
}  // end of namespace
