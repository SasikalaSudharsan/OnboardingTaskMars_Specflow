using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProjectMars_Specflow.Utilities;

namespace ProjectMars_Specflow.Pages
{
    public class LanguagePage : CommonDriver
    {
        private IReadOnlyCollection<IWebElement> DeleteButtons => driver.FindElements(By.XPath("//div[@data-tab='first']//i[@class='remove icon']"));
        private IWebElement AddNewButton                       =>  driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private IWebElement AddLanguageTextbox                 => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement LanguageLevelDropdown              => driver.FindElement(By.XPath("//select[@name='level']"));
        private IWebElement AddButton                          => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement SuccessMessage                     => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private IWebElement UpdateLanguage                     => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement UpdateLevelDropdown                => driver.FindElement(By.XPath("//select[@name='level']"));
        private IWebElement UpdateNewButton                    => driver.FindElement(By.XPath("//input[@value='Update']"));
        private Func<string, By> NewLanguageElement  = language          => By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{language}']");
        private Func<string, By> NewLanguageLevelElement = languageLevel => By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{languageLevel}']");
        private Func<string, By> EditButtonElement = existingLanguage    => By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[1]");
        private Func<string, By> DeleteButtonElement = language          => By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{language}']/following-sibling::td[last()]/span[2]");
        private Func<string, By> DeletedLanguageElement =deletedLanguage => By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{deletedLanguage}']");

        public void Delete_All_Records()
        {
            Thread.Sleep(8000);
            //Delete all records in the language list
            foreach (IWebElement deleteButton in DeleteButtons)
            {
                deleteButton.Click();
            }
        }

        public void Add_Language(string language, string languageLevel)
        {
            Thread.Sleep(6000);
            //Wait.WaitToBeClickable("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div",5);
            //Click add new button
            AddNewButton.Click();
            //Enter the language that needs to be added
            AddLanguageTextbox.SendKeys(language);
            //Choose the language level
            SelectElement chooseLanguageLevel = new SelectElement(LanguageLevelDropdown);
            chooseLanguageLevel.SelectByValue(languageLevel);
            //Click add new button after entering language and language level
            AddButton.Click();
            Thread.Sleep(4000);
            //Get the text of the added language message 
            string actualMessage = SuccessMessage.Text;            
            Console.WriteLine(actualMessage);
        }

        public string getLanguage(string language)
        {
            Thread.Sleep(4000);
            //Wait.WaitToExist("XPath", $"//div[@class='twelve wide column scrollTable']//td[text()='{language}']", 6);
            By languageBy = NewLanguageElement(language);
            IWebElement newLanguage = driver.FindElement(languageBy);
            return newLanguage.Text;
        }

        public string getLanguageLevel(string languageLevel)
        {
            By languageLevelBy = NewLanguageLevelElement(languageLevel);
            IWebElement newLanguageLevel = driver.FindElement(languageLevelBy);
            return newLanguageLevel.Text;
        }

        public void Edit_Language(string existingLanguage, string existingLanguageLeve)
        {
            Thread.Sleep(4000);
            //Click the edit icon that needs to be updated
            By existingLanguageBy = EditButtonElement(existingLanguage);
            IWebElement EditButton = driver.FindElement(existingLanguageBy);
            EditButton.Click();
        }
        public void Update_Language(string language, string languageLevel)
        {
            Thread.Sleep(4000);
            //Clear and enter the language that needs to be updated
            UpdateLanguage.Clear();
            UpdateLanguage.SendKeys(language);
            //Choose the language level
            SelectElement updateLanguageLevel = new SelectElement(UpdateLevelDropdown);
            updateLanguageLevel.SelectByValue(languageLevel);
            //Click Update button after updating language and language level
            UpdateNewButton.Click();
        }

        public void Delete_Language(string language)
        {
            Thread.Sleep(6000);
            //Click the delete button that needs to be deleted
            By deleteLanguageBy = DeleteButtonElement(language);
            IWebElement DeleteButton = driver.FindElement(deleteLanguageBy);
            DeleteButton.Click();
            Thread.Sleep(4000);
        }

        public string getDeletedLanguage(string deletedLanguage)
        {
            try
            {
                By deletedLanguageBy = DeletedLanguageElement(deletedLanguage);
                IWebElement DeletedLanguage = driver.FindElement(deletedLanguageBy);
                Console.WriteLine(DeletedLanguage.Text);
                return DeletedLanguage.Text;
            }
            catch(NoSuchElementException) 
            {
                return null;
            }
           
        }

        public string getMessage()
        {
            //Get the text message after entering language and language level
            return SuccessMessage.Text;                      
        }
    }
}
