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
        public void Add_Skills()
        {
            Thread.Sleep(2000);

            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            IWebElement addSkill = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkill.SendKeys("Specflow");

            IWebElement skillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));

            SelectElement chooseSkillLevel = new SelectElement(skillLevelDropdown);
            chooseSkillLevel.SelectByValue("Intermediate");

            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();

            Thread.Sleep(2000);

            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            
            if(newSkill.Text == "Specflow")
            {
                Console.WriteLine("New skill has been  added");
            }
            else
            {
                Console.WriteLine("New skill hasn't been  added");
            }

        }
        public void Update_Skills()
        {
            Thread.Sleep(2000);

            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            if (newSkill.Text == "Specflow")
            {
                IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
                updateButton.Click();

                IWebElement updateSkill = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
                updateSkill.Clear();
                updateSkill.SendKeys("Java");

                IWebElement updateSkillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));

                SelectElement updateSkillLevel = new SelectElement(updateSkillLevelDropdown);
                updateSkillLevel.SelectByValue("Expert");

                IWebElement updateNewButton = driver.FindElement(By.XPath("//input[@value='Update']"));
                updateNewButton.Click();

                if (updateSkill.Text == "Java")
                {
                    Console.WriteLine("Skill to be updated has been found");
                }
            }
            else
            {
                Console.WriteLine("Skill to be updated hasn't been found");
            }
        }
        public void Delete_Skills()
        {
            Thread.Sleep(4000);

            IWebElement updatedSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            if(updatedSkill.Text =="Java")
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]"));
                deleteButton.Click();
            }
            else
            {
                Console.WriteLine("Skill to be deleted hasn't been found");
            }
        }
    }
}
