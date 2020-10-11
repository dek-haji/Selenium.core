using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace seleniumTest
{
    [TestClass]
    public class HomePageFeature
    {
        IWebDriver _driver;
        [TestMethod]
        public void MustBeAbleToLogin()
        {
            var outPutDirectory =
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
             _driver = new ChromeDriver(outPutDirectory);
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var LoginButtonLocator = By.ClassName("login-button");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(
                ExpectedConditions.ElementIsVisible(LoginButtonLocator))

        }
        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
