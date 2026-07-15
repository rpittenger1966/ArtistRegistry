using ArtistRegistry.Standard.Data;
using System.Diagnostics;
using System.Text;

namespace ArtistRegistry.Core.WebScraperLibrary
{
	public class OhioArtistScaperService
	{
		private const string ScriptFileName = @"M:\Visual Studio Solutions\WebScraperResearch\Scrape2\index.js";

		public void DownloadContentForFirstLetter(FirstLetter firstLetter, string outputFolder)
		{
			firstLetter.PageCount = null;

			string outputFileName = Path.Combine(outputFolder, $"{firstLetter.FirstLetterId}.html");
			string diagFileName = Path.Combine(outputFolder, $"{firstLetter.FirstLetterId}.diagnostic.txt");

			string commandLineArguments = $"\"{ScriptFileName}\" {firstLetter.UrlCalculated} \"{outputFileName}\"";
			Console.WriteLine(commandLineArguments);


			Process proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "node",
					Arguments = commandLineArguments,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				}
			};

			StringBuilder sb = new StringBuilder();

			proc.Start();
			while (!proc.StandardOutput.EndOfStream)
			{
				string line = proc.StandardOutput.ReadLine();
				sb.AppendLine(line);
			}

			File.WriteAllText(diagFileName, sb.ToString());
			firstLetter.PageCount = CountPages(firstLetter.FirstLetterId[0], outputFileName);
		}

		static public int CountPages(char character, string fileName)
		{

			string content = File.ReadAllText(fileName);
			int test = 25;

			while (true)
			{
				string token = $"https://oovar.ohioartscouncil.org/pg/{test}/?cn-char={Char.ToLower(character)}";
				if (content.IndexOf(token) >= 0)
				{
					return test;
				}
				--test;
				if (test < 0) return 1;
			}

			return 1;
		}


		static public void DownloadIndexPages(FirstLetter firstLetter, string outputFolder)
		{
			if (firstLetter.PageCount == null) return;
			if (firstLetter.PageCount.Value == 1) return;
			int page;
			for (page = 2; page <= firstLetter.PageCount.Value; ++page)
			{
				string outputFileName = Path.Combine(outputFolder, $"{firstLetter.FirstLetterId}-{page}.html");
				string diagFileName = Path.Combine(outputFolder, $"{firstLetter.FirstLetterId}-{page}.diagnostic.txt");
				string url = $"https://oovar.ohioartscouncil.org/pg/{page}/?cn-char={firstLetter.FirstLetterId.ToLower()}&page_id=19";

				string commandLineArguments = $"\"{ScriptFileName}\" {url} \"{outputFileName}\"";
				Console.WriteLine(commandLineArguments);


				Process proc = new Process
				{
					StartInfo = new ProcessStartInfo
					{
						FileName = "node",
						Arguments = commandLineArguments,
						UseShellExecute = false,
						RedirectStandardOutput = true,
						CreateNoWindow = true
					}
				};

				StringBuilder sb = new StringBuilder();

				proc.Start();
				while (!proc.StandardOutput.EndOfStream)
				{
					string line = proc.StandardOutput.ReadLine();
					sb.AppendLine(line);
				}

				File.WriteAllText(diagFileName, sb.ToString());
			}

		}




	}  // end of class
}  // end of namespace
