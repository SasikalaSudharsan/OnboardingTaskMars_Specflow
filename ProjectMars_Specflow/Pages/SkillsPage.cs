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
        private IReadOnlyCollection<IWebElement> DeleteButtons => driver.FindElements(By.XPath("//div[@data-tab='second']//i[@class='remove icon']"));
        private IWebElement AddNewButton                       => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private IWebElement AddSkill                           => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        private IWebElement SkillLevelDropdown                 =>driver.FindElement(By.XPath("//select[@name='level']"));
        private IWebElement AddButton                          => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement SuccessMessage                     => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private IWebElement UpdateSkill                        => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        private IWebElement UpdateLevelDropdown                => driver.FindElement(By.XPath("//select[@name='level']"));
        private IWebElement UpdateNewButton                    => driver.FindElement(By.XPath("//input[@value='Update']"));
        private Func<string, By> NewSkillElement = skill => By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{skill}']");
        private Func<string, By> NewSkillLevelElement = skillLevel => By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{skillLevel}']");
        private Func<string, By> EditButtonElement = existingSkill => By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{existingSkill}']/following-sibling::td[last()]/span[1]");
        private Func<string, By> DeleteButtonElement = skill => By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{skill}']/following-sibling::td[last()]/span[2]");
        private Func<string, By> DeletedSkillElement = deletedSkill => By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{deletedSkill}']");

        public void Delete_All_Records()
        {
            Thread.Sleep(8000);
            //Delete all records in the Skills list
            foreach (IWebElement deleteButton in DeleteButtons)
            {
                deleteButton.Click();
            }
        }   

        public void Add_Skills(string skill, string skillLevel)
        {
            Thread.Sleep(2000);
            //Click Add new button            
            AddNewButton.Click();
            //Enter the skill that needs to be added
            AddSkill.SendKeys(skill);
            //Choose the skill level
            SelectElement chooseSkillLevel = new SelectElement(SkillLevelDropdown);
            chooseSkillLevel.SelectByValue(skillLevel);
            //Click add button
            AddButton.Click();
            Thread.Sleep(4000);
            //Get the text of the added skill message 
            string actualMessage = SuccessMessage.Text;
            Console.WriteLine(actualMessage);
        }

        public string getSkill(string skill)
        {
            Thread.Sleep(2000);
            By skillBy = NewSkillElement(skill);
            IWebElement NewSkill = driver.FindElement(skillBy);
            return NewSkill.Text;
        }

        public string getSkillLevel(string skillLevel)
        {
            Thread.Sleep(2000);
            By skillLevelBy = NewSkillLevelElement(skillLevel);
            IWebElement NewSkillLevel = driver.FindElement(skillLevelBy);
            return NewSkillLevel.Text;
        }

        public void Edit_Skills(string existingSkill, string existingSkillLevel)
        {
            Thread.Sleep(4000);
            //Click the edit icon that needs to be updated
            By existingSkillBy = EditButtonElement(existingSkill);
            IWebElement EditButton = driver.FindElement(existingSkillBy);
            EditButton.Click();
        }

        public void Update_Skills(string skill, string skillLevel)
        {
            Thread.Sleep(2000);
            //Clear and enter the skill that needs to be updated            
            UpdateSkill.Clear();
            UpdateSkill.SendKeys(skill);            
            //Choose the skill level
            SelectElement updateSkillLevel = new SelectElement(UpdateLevelDropdown);
            updateSkillLevel.SelectByValue(skillLevel);
            //Click the update button            
            UpdateNewButton.Click();
        }

        public void Delete_Skills(string skill)
        {
            Thread.Sleep(4000);
            //Click the delete button that needs to be deleted
            By deleteSkillBy = DeleteButtonElement(skill);
            IWebElement DeleteButton = driver.FindElement(deleteSkillBy);
            DeleteButton.Click();
        }

        public string getDeletedSkill(string deletedSkill)
        {
            Thread.Sleep(2000);
            try
            {
                By deletedSkillBy = DeletedSkillElement(deletedSkill);
                IWebElement DeletedSkill = driver.FindElement(deletedSkillBy);
                return DeletedSkill.Text;
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
