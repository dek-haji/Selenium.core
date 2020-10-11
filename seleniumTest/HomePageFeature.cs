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
            wait.Until(ExpectedConditions.ElementIsVisible(LoginButtonLocator));

            //created new variables to target the part of the element that we targeting
            var userNameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(LoginButtonLocator);

           //I dont know what's going on
                
        }
        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
