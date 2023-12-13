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
        public void Add_Language()
        {
            Thread.Sleep(4000);

            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            IWebElement addLanguageTextbox = driver.FindElement(By.XPath("//input[@name='name']"));
            addLanguageTextbox.SendKeys("French");

            IWebElement languageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));

            SelectElement languageLevel = new SelectElement(languageLevelDropdown);
            languageLevel.SelectByValue("Fluent");

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

        public void Update_Language()
        {

            Thread.Sleep(4000);

            IWebElement newLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            if (newLanguage.Text == "French")
            {
                IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]"));
                updateButton.Click();

                IWebElement updateLanguage = driver.FindElement(By.XPath("//input[@name='name']"));
                updateLanguage.Clear();
                updateLanguage.SendKeys("Spanish");

                IWebElement updateLanguageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));

                SelectElement updateLanguageLevel = new SelectElement(updateLanguageLevelDropdown);
                updateLanguageLevel.SelectByValue("Conversational");

                IWebElement updateNewButton = driver.FindElement(By.XPath("//input[@value='Update']"));
                updateNewButton.Click();

                Assert.That(updateLanguage.Text == "Spanish", "Updated language and expected language do not match");
               
            }
            else
            {
                Console.WriteLine("Language to be updated hasn't been found");
            }
        }

        public void Delete_Language()
        {
            Thread.Sleep(4000);

            IWebElement updatedLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (updatedLanguage.Text == "Spanish")
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]"));
                deleteButton.Click();
                Console.WriteLine("Deleted successfully");
            }
            else
            {
                Console.WriteLine("Language to be deleted hasn't been found");
            }
        }
    }
}
