using OpenQA.Selenium;



namespace ArtistRegistry.Scaper.Tests
{
	[TestClass]
	public sealed class Test1
	{
		[TestMethod]
		public void TestMethod1()
		{
			string url = "https://oovar.ohioartscouncil.org/char/O/";
			string phantomJsFolderPath = @"M:\PhantomJS";

			var options = new PhantomJSOptions();
			options.AddAdditionalCapability("IsJavaScriptEnabled", true);
			IWebDriver driver = new PhantomJSDriver(phantomJsFolderPath, options);
			driver.Navigate().GoToUrl(url);

			try
			{
				string pagesource = driver.PageSource;
				driver.FindElement(By.Id("yourelement"));
				Console.Write("yourelement founded");

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);

			}

			Console.Read();

		}
	}
}
