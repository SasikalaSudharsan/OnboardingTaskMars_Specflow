using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using ProjectMars_Specflow.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMars_Specflow.Utilities;

namespace ProjectMars_Specflow.Tests
{
    [TestFixture]
    public class Language_Tests : CommonDriver
    {

        LoginPage loginPageObj = new LoginPage();
        LanguagePage languagePageObj = new LanguagePage();

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();

            loginPageObj.LoginActions();
        }
        [Test]
        public void AddLanguage_Test()
        {
            languagePageObj.Add_Language();
        }
        [Test]
        public void UpdateLanguage_Test()
        {
            languagePageObj.Update_Language();
        }
        [Test]
        public void DeleteLanguage_Test()
        {
            languagePageObj.Delete_Language();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
