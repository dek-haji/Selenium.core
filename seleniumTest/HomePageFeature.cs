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
        public void ShouldBeAbleToLogin()
        {
            var outPutDirectory =
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outPutDirectory);
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var loginButtonLocator = _driver.FindElement(By.Id("login-button"));
            //var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            //wait.Until(
            //    ExpectedConditions.ElementIsVisible((By)loginButtonLocator));

            var userNameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            //var loginButton = _driver.FindElement(By.Id(loginButtonLocator);

            userNameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButtonLocator.Click();

            Assert.IsTrue(_driver.Url.Contains("inventorys.html"));
        }
        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
