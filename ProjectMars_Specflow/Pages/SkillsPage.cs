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

            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            IWebElement addSkill = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkill.SendKeys(skill);

            IWebElement skillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));

            SelectElement chooseSkillLevel = new SelectElement(skillLevelDropdown);
            chooseSkillLevel.SelectByValue(skillLevel);

            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();

            Thread.Sleep(4000);
            //Get the text of the added skill message 
            IWebElement successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string actualMessage = successMessage.Text;

            Console.WriteLine(actualMessage);
        }

        public string getSkill()
        {
            Thread.Sleep(2000);

            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return newSkill.Text;
        }

        public string getSkillLevel()
        {
            Thread.Sleep(2000);

            IWebElement newLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            return newLanguageLevel.Text;
        }

        public void Update_Skills(string skill, string skillLevel)
        {
            Thread.Sleep(2000);

            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            if (newSkill.Text == "Specflow")
            {
                IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
                updateButton.Click();

                IWebElement updateSkill = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
                updateSkill.Clear();
                updateSkill.SendKeys(skill);

                IWebElement updateSkillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));

                SelectElement updateSkillLevel = new SelectElement(updateSkillLevelDropdown);
                updateSkillLevel.SelectByValue(skillLevel);

                IWebElement updateNewButton = driver.FindElement(By.XPath("//input[@value='Update']"));
                updateNewButton.Click();

                Thread.Sleep(4000);
                //Get the text of the updated skill message 
                IWebElement successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                string actualMessage = successMessage.Text;

                Console.WriteLine(actualMessage);
            }
            else
            {
                Console.WriteLine("Skill to be updated hasn't been found");
            }
        }

        public string getUpdatedSkill()
        {
            Thread.Sleep(2000);

            IWebElement updatedSkill = driver.FindElement(By.XPath("\r\n//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return updatedSkill.Text;
        }

        public string getUpdatedSkillLevel()
        {
            Thread.Sleep(2000);

            IWebElement updatedSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            return updatedSkillLevel.Text;
        }

        public void Delete_Skills(string skill)
        {
            Thread.Sleep(4000);

            IWebElement updatedSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            if(updatedSkill.Text == skill)
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]"));
                deleteButton.Click();
            }
            else
            {
                Console.WriteLine("Skill to be deleted hasn't been found");
            }
        }

        public string getDeletedSkill()
        {
            Thread.Sleep(2000);

            IWebElement deletedSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return deletedSkill.Text;

            Thread.Sleep(4000);
            //Get the text of the deleted skill message 
            IWebElement successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string actualMessage = successMessage.Text;

            Console.WriteLine(actualMessage);
        }
    }
}
