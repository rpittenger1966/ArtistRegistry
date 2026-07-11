namespace ArtistRegistry.Core.WebScraperLibrary
{
	public class WebScraperService
	{
		// https://stackoverflow.com/questions/24288726/scraping-webpage-generated-by-javascript-with-c-sharp

		public async Task<string> GetContentForUrl(string url)
		{
			//var driver = new PhantomJSDriver();
			//driver.Url = "http://www.regulations.gov/#!documentDetail;D=APHIS-2013-0013-0083";
			//driver.Navigate();
			////the driver can now provide you with what you need (it will execute the script)
			////get the source of the page
			//var source = driver.PageSource;
			////fully navigate the dom
			//var pathElement = driver.FindElementById("some-id");

			//return source;
			return "";
		}


	} // end of class
}  // end of namespace
