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

        [Given(@"User logged into Mars URL successfully")]
        public void GivenUserLoggedIntoMarsURLSuccessfully()
        {
            //Login page object initialization and definition
            loginPageObj.LoginActions();
        }

        [When(@"User add '([^']*)' and '([^']*)' to the language list")]
        public void WhenUserAddAndToTheLanguageList(string language, string languageLevel)
        {
            languagePageObj.Add_Language(language, languageLevel);
        }

        [When(@"The '([^']*)' and '([^']*)' should be added successfully")]
        public void WhenTheAndShouldBeAddedSuccessfully(string language, string languageLevel)
        {
            string newLanguage = languagePageObj.getLanguage();
            string newLanguageLevel = languagePageObj.getLanguageLevel();

            Assert.That(newLanguage == language, "Actual language and expected language do not match");
            Assert.That(newLanguageLevel == languageLevel, "Actual language level and expected language level  do not match");
        }


        [When(@"User update the '([^']*)' and '([^']*)' of an existing language")]
        public void WhenUserUpdateTheAndOfAnExistingLanguage(string language, string languageLevel)
        {
            languagePageObj.Update_Language(language, languageLevel);
        }

        [When(@"The '([^']*)' and '([^']*)' should be updated successfully")]
        public void WhenTheAndShouldBeUpdatedSuccessfully(string language, string languageLevel)
        {
            string updatedLanguage = languagePageObj.getUpdatedLanguage();
            string updatedLanguageLevel = languagePageObj.getUpdatedLanguageLevel();

            Assert.That(updatedLanguage == language, "Updated language and expected language do not match");
            Assert.That(updatedLanguageLevel == languageLevel, "Updated language level and expected language level do not match");
        }

        [When(@"User delete the '([^']*)' of an existing language")]
        public void WhenUserDeleteTheOfAnExistingLanguage(string language)
        {
            languagePageObj.Delete_Language(language);
        }

        [When(@"The '([^']*)' should be deleted successfully")]
        public void WhenTheShouldBeDeletedSuccessfully(string language)
        {
            string deletedLanguage = languagePageObj.getDeletedLanguage();

            Assert.That(deletedLanguage != language, "Expected language has not been deleted");
        }

        [When(@"The special characters '([^']*)' should not be added")]
        public void WhenTheSpecialCharactersShouldNotBeAdded(string language)
        {
            string updatedLanguage = languagePageObj.getUpdatedLanguage();

            Assert.That(updatedLanguage != language, "Special characters has not been added in the language list");
        }

        [When(@"The Empty '([^']*)' should not be added")]
        public void WhenTheEmptyShouldNotBeAdded(string language)
        {
            string updatedLanguage = languagePageObj.getUpdatedLanguage();

            Assert.That(updatedLanguage != language, "Empty language has not been added");
        }

        [When(@"The existing language '([^']*)' should not be added in the language list")]
        public void WhenTheExistingLanguageShouldNotBeAddedInTheLanguageList(string language)
        {
            string updatedLanguage = languagePageObj.getUpdatedLanguage();

            Assert.That(updatedLanguage != language, "Existing language has not been added");
        }

    }
}
