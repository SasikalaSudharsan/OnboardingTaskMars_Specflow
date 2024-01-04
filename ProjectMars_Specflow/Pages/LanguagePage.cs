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
        public void Add_Language(string language, string languageLevel)
        {
            Thread.Sleep(6000);

            //Wait.WaitToBeClickable("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div",5);
            //Click add new button
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            //Enter the language that needs to be added
            IWebElement addLanguageTextbox = driver.FindElement(By.XPath("//input[@name='name']"));
            addLanguageTextbox.SendKeys(language);
            //Choose the language level
            IWebElement languageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));

            SelectElement chooseLanguageLevel = new SelectElement(languageLevelDropdown);
            chooseLanguageLevel.SelectByValue(languageLevel);
            //Click add new button after entering language and language level
            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();

            Thread.Sleep(4000);
            //Get the text of the added language message 
            IWebElement successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string actualMessage = successMessage.Text;
            
            Console.WriteLine(actualMessage);
        }

        public string getLanguage(string language)
        {
            Thread.Sleep(4000);

            //Wait.WaitToExist("XPath", $"//div[@class='twelve wide column scrollTable']//td[text()='{language}']", 6);
            IWebElement newLanguage = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{language}']"));
            return newLanguage.Text;
        }

        public string getLanguageLevel(string languageLevel)
        {
            IWebElement newLanguageLevel = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{languageLevel}']"));
            return newLanguageLevel.Text;
        }

        public void Edit_Language(string existingLanguage, string existingLanguageLeve)
        {
            Thread.Sleep(4000);

            //Click the edit icon that needs to be updated
            IWebElement editButton = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[1]"));
            editButton.Click();
        }
        public void Update_Language(string language, string languageLevel)
        {

            Thread.Sleep(4000);

            //Clear and enter the language that needs to be updated
            IWebElement updateLanguage = driver.FindElement(By.XPath("//input[@name='name']"));
            updateLanguage.Clear();
            updateLanguage.SendKeys(language);

            IWebElement updateLanguageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
            //Choose the language level
            SelectElement updateLanguageLevel = new SelectElement(updateLanguageLevelDropdown);
            updateLanguageLevel.SelectByValue(languageLevel);
            //Click Update button after updating language and language level
            IWebElement updateNewButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateNewButton.Click();

            Thread.Sleep(4000);
        }

        public void Delete_Language(string language)
        {
            Thread.Sleep(6000);
            //Click the delete button that needs to be deleted
            IWebElement deleteButton = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{language}']/following-sibling::td[last()]/span[2]"));
            deleteButton.Click();

            Thread.Sleep(4000);           
        }

        public string getDeletedLanguage(string language)
        {
            try
            {
                IWebElement deletedLanguage = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{language}']"));
                return deletedLanguage.Text;
            }
            catch(NoSuchElementException) 
            {
                return null;
            }
           
        }

        public string getMessage()
        {
            //Get the text message after entering language and language level
            IWebElement successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            return successMessage.Text;                      
        }
    }
}
