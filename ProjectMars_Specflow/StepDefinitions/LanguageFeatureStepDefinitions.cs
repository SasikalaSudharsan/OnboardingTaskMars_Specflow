using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using ProjectMars_Specflow.Pages;
using ProjectMars_Specflow.Utilities;
using System;
using TechTalk.SpecFlow;

namespace ProjectMars_Specflow.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        LanguagePage languagePageObj = new LanguagePage();

        [Given(@"User logged in successfully")]
        public void GivenUserLoggedInSuccessfully()
        {
            //Open chrome browser
            driver = new ChromeDriver();

            //Login page object initialization and definition
            loginPageObj.LoginActions();
        }

        [When(@"User add language to the language list")]
        public void WhenUserAddLanguageToTheLanguageList()
        {
            languagePageObj.Add_Language();
        }

        [Then(@"Language should be added successfully")]
        public void ThenLanguageShouldBeAddedSuccessfully()
        {
            string newLanguage = languagePageObj.getLanguage();
            string newLanguageLevel = languagePageObj.getLanguageLevel();

            Assert.That( newLanguage == "French", "Actual language and expected language do not match");
            Assert.That(newLanguageLevel == "Fluent", "Actual language level and expected language level  do not match");
        }
    }
}
