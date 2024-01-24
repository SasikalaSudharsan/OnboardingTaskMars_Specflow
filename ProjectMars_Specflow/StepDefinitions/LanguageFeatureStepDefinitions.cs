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
        LoginPage loginPageObj;
        LanguagePage languagePageObj;

        public LanguageFeatureStepDefinitions()
        {
            loginPageObj = new LoginPage();
            languagePageObj = new LanguagePage();
        }

        [Given(@"User logged into Mars URL successfully")]
        public void GivenUserLoggedIntoMarsURLSuccessfully()
        {
            loginPageObj.LoginActions();
        }

        [When(@"Delete all records in the language list")]
        public void WhenDeleteAllRecordsInTheLanguageList()
        {
            languagePageObj.Delete_All_Records();
        }

        [When(@"User add '([^']*)' and '([^']*)' to the language list")]
        public void WhenUserAddAndToTheLanguageList(string language, string languageLevel)
        {
            languagePageObj.Add_Language(language, languageLevel);
        }

        [Then(@"The '([^']*)' and '([^']*)' should be added successfully")]
        public void ThenTheAndShouldBeAddedSuccessfully(string language, string languageLevel)
        {
            string newLanguage = languagePageObj.getLanguage(language);
            string newLanguageLevel = languagePageObj.getLanguageLevel(languageLevel);

            Assert.That(newLanguage == language, "Actual language and expected language do not match");
            Assert.That(newLanguageLevel == languageLevel, "Actual language level and expected language level  do not match");
        }

        [When(@"User edit an existing '([^']*)' and '([^']*)'")]
        public void WhenUserEditAnExistingAnd(string existingLanguage, string existingLanguageLevel)
        {
            languagePageObj.Edit_Language(existingLanguage, existingLanguageLevel);
        }

        [Then(@"The '([^']*)' and '([^']*)' should be updated successfully")]
        public void ThenTheAndShouldBeUpdatedSuccessfully(string language, string languageLevel)
        {
            languagePageObj.Update_Language(language, languageLevel);

            string updatedLanguage = languagePageObj.getLanguage(language);
            string updatedLanguageLevel = languagePageObj.getLanguageLevel(languageLevel);

            Assert.That(updatedLanguage == language, "Updated language and expected language do not match");
            Assert.That(updatedLanguageLevel == languageLevel, "Updated language level and expected language level do not match");
        }

        [When(@"User delete an existing '([^']*)'")]
        public void WhenUserDeleteAnExisting(string language)
        {
            languagePageObj.Delete_Language(language);
        }

        [Then(@"The '([^']*)' should be deleted successfully")]
        public void ThenTheShouldBeDeletedSuccessfully(string language)
        {
            string deletedLanguage = languagePageObj.getDeletedLanguage(language);

            Assert.That(deletedLanguage == null, "Expected language has not been deleted");
        }

        [Then(@"The message '([^']*)' should be displayed")]
        public void ThenTheMessageShouldBeDisplayed(string expectedMessage)
        {
            string actualMessage = languagePageObj.getMessage();

            Assert.That(actualMessage == expectedMessage, "Actual message and expected message do not match");
        }

    }
}
