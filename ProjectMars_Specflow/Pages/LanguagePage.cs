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

            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            IWebElement addLanguageTextbox = driver.FindElement(By.XPath("//input[@name='name']"));
            addLanguageTextbox.SendKeys(language);

            IWebElement languageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));

            SelectElement chooseLanguageLevel = new SelectElement(languageLevelDropdown);
            chooseLanguageLevel.SelectByValue(languageLevel);

            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();            
        }

        public string getLanguage()
        {
            Thread.Sleep(4000);

            IWebElement newLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return newLanguage.Text;

        }

        public string getLanguageLevel()
        {
            IWebElement newLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            return newLanguageLevel.Text;
        }

        public void Update_Language(string language, string languageLevel)
        {

            Thread.Sleep(4000);

            IWebElement newLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            if (newLanguage.Text == "French")
            {
                IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]"));
                updateButton.Click();

                IWebElement updateLanguage = driver.FindElement(By.XPath("//input[@name='name']"));
                updateLanguage.Clear();
                updateLanguage.SendKeys(language);

                IWebElement updateLanguageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));

                SelectElement updateLanguageLevel = new SelectElement(updateLanguageLevelDropdown);
                updateLanguageLevel.SelectByValue(languageLevel);

                IWebElement updateNewButton = driver.FindElement(By.XPath("//input[@value='Update']"));
                updateNewButton.Click();

                //Assert.That(updateLanguage.Text == "Spanish", "Updated language and expected language do not match");
               
            }
            else
            {
                Console.WriteLine("Language to be updated hasn't been found");
            }
        }

        public string getUpdatedLanguage()
        {
            Thread.Sleep(2000);
            IWebElement updatedLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return updatedLanguage.Text;
        }

        public string getUpdatedLanguageLevel()
        {
            Thread.Sleep(2000);
            IWebElement updatedLangaugeLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            return updatedLangaugeLevel.Text;
        }

        public void Delete_Language(string language, string languageLevel)
        {
            Thread.Sleep(6000);

            IWebElement updatedLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (updatedLanguage.Text == language)
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]"));
                deleteButton.Click();
            }
            else
            {
                Console.WriteLine("Language to be deleted hasn't been found");
            }
        }

        public string getDeletedLanguage()
        {
            Thread.Sleep(2000);
            IWebElement deletedLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return deletedLanguage.Text;
        }

        public string getDeletedLanguageLevel()
        {
            Thread.Sleep(2000);
            IWebElement deletedLangaugeLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            return deletedLangaugeLevel.Text;
        }

    }
}
