
namespace Sample.Tests
{
	[TestFixture]
	public class Test
	{
		// Make sure that the screenshots folder exists already (testdroid-samples/appium/sample-scripts/csharp/screenshots).
		readonly String SCREENSHOT_FOLDER = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/screenshots/";
		AndroidDriver<AndroidElement> driver;

		[OneTimeSetUp]
		public void BeforeAll()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			String BITBAR_APIKEY = Environment.GetEnvironmentVariable("BITBAR_APIKEY");
			String BITBAR_APP_ID = Environment.GetEnvironmentVariable("BITBAR_APP_ID");

			AppiumOptions capabilities = new AppiumOptions();
			capabilities.AddAdditionalCapability("device", "Android");

			capabilities.AddAdditionalCapability("deviceName", "Android");
			capabilities.AddAdditionalCapability("platformName", "Android");
			capabilities.AddAdditionalCapability("bitbar_apiKey", BITBAR_APIKEY);
			capabilities.AddAdditionalCapability("bitbar_project", "C# Appium");
			capabilities.AddAdditionalCapability("bitbar_testrun", "Android Run Sample");

			// See available devices at: https://cloud.bitbar.com/#public/devices
			capabilities.AddAdditionalCapability("bitbar_device", "Google Pixel 3a Android 12");
			capabilities.AddAdditionalCapability("bitbar_app", BITBAR_APP_ID);

			Console.WriteLine("WebDriver request initiated. Waiting for response, this typically takes 2-3 mins");

			driver = new AndroidDriver<AndroidElement>(new Uri("https://eu-mobile-hub.bitbar.com/wd/hub"), capabilities, TimeSpan.FromSeconds(300));
			Console.WriteLine("WebDriver response received.");

		}

		[OneTimeTearDown]
		public void AfterAll()
		{
			driver.Quit();
		}


		[Test]
		public void TestSampleApp()
		{
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
			TakeScreenshot("First");
			driver.FindElement(By.XPath("//android.widget.RadioButton[@text='Use Testdroid Cloud']")).Click();
			driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='com.bitbar.testdroid:id/editText1']")).SendKeys("C Sharp");
			TakeScreenshot("Second");
			driver.Navigate().Back();
			TakeScreenshot("Third");
			driver.FindElement(By.XPath("//android.widget.ScrollView[1]/android.widget.LinearLayout[1]/android.widget.LinearLayout[2]/android.widget.Button[1]")).Click();
			TakeScreenshot("Fourth");
		}

		public void TakeScreenshot(String filename)
		{
			Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
			String filepath = SCREENSHOT_FOLDER + filename + ".png";
			Console.WriteLine("Taking screenshot: " + filepath);
			ss.SaveAsFile(filepath, ScreenshotImageFormat.Png);
		}
	}
}
