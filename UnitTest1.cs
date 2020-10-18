using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;			
using OpenQA.Selenium.Firefox;	
using OpenQA.Selenium.Chrome;	
using OpenQA.Selenium.IE;
using static OpenQA.Selenium.IJavaScriptExecutor;

namespace ui_automation_test_example_pipeline_code
{
  /// <summary>
  /// Summary description for MySeleniumTests
  /// </summary>
  [TestClass]
  public class MySeleniumTests
  {
    private TestContext testContextInstance;
    private IWebDriver driver;
    private string appURL;

    public MySeleniumTests()
    {
    }

    [TestMethod]
    [TestCategory("Chrome")]
    public void TheBingSearchTest()
    {
      driver.Navigate().GoToUrl(appURL + "/");

      driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


      driver.FindElement(By.Id("sb_form_q")).SendKeys("Azure Pipelines");
      var searchButton=driver.FindElement(By.Id("sb_form_go"));
      IJavaScriptExecutor javaScriptExecutor=(IJavaScriptExecutor)driver;
      javaScriptExecutor.ExecuteScript("arguments[0].click();", searchButton);
      Assert.IsTrue(driver.Title.Contains("Azure Pipelines"), "Verified title of the page");
    }

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    [TestInitialize()]
    public void SetupTest()
    {
      appURL = "http://www.bing.com/";

      string browser = "Chrome";
      switch(browser)
      {
        case "Chrome":
          driver = new ChromeDriver();
          break;
        case "Firefox":
          driver = new FirefoxDriver();
          break;
        case "IE":
          driver = new InternetExplorerDriver();
          break;
        default:
          driver = new ChromeDriver();
          break;
      }

    }

    [TestCleanup()]
    public void MyTestCleanup()
    {
      driver.Quit();
    }
  }
}