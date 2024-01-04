using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectMars_Specflow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_Specflow.Pages
{
    public class SkillsPage : CommonDriver
    {
        public void Add_Skills(string skill, string skillLevel)
        {
            Thread.Sleep(2000);
            //Click Add new button
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            //Enter the skill that needs to be added
            IWebElement addSkill = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkill.SendKeys(skill);
            //Choose the skill level
            IWebElement skillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));

            SelectElement chooseSkillLevel = new SelectElement(skillLevelDropdown);
            chooseSkillLevel.SelectByValue(skillLevel);
            //Click add button
            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();

            Thread.Sleep(4000);
            //Get the text of the added skill message 
            IWebElement successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string actualMessage = successMessage.Text;

            Console.WriteLine(actualMessage);
        }

        public string getSkill(string skill)
        {
            Thread.Sleep(2000);

            IWebElement newSkill = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{skill}']"));
            return newSkill.Text;
        }

        public string getSkillLevel(string skillLevel)
        {
            Thread.Sleep(2000);

            IWebElement newLanguageLevel = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{skillLevel}']"));
            return newLanguageLevel.Text;
        }

        public void Edit_Skills(string existingSkill, string existingSkillLevel)
        {
            Thread.Sleep(4000);

            //Click the edit icon that needs to be updated
            IWebElement editButton = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{existingSkill}']/following-sibling::td[last()]/span[1]"));
            editButton.Click();
        }

        public void Update_Skills(string skill, string skillLevel)
        {
            Thread.Sleep(2000);
            //Clear and enter the skill that needs to be updated
            IWebElement updateSkill = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            updateSkill.Clear();
            updateSkill.SendKeys(skill);

            IWebElement updateSkillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
            //Choose the skill level
            SelectElement updateSkillLevel = new SelectElement(updateSkillLevelDropdown);
            updateSkillLevel.SelectByValue(skillLevel);
            //Click the update button
            IWebElement updateNewButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateNewButton.Click();
        }

        public void Delete_Skills(string skill)
        {
            Thread.Sleep(4000);
            //Click the delete button that needs to be deleted
            IWebElement deleteButton = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{skill}']/following-sibling::td[last()]/span[2]"));
            deleteButton.Click();
        }

        public string getDeletedSkill(string skill)
        {
            Thread.Sleep(2000);

            try
            {
                IWebElement deletedSkill = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{skill}']"));
                return deletedSkill.Text;
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
