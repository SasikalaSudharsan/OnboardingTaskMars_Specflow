using OpenQA.Selenium;
using ProjectMars_Specflow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_Specflow.Pages
{
    public class HomePage : CommonDriver
    {
        public void GoToSkillsPage()
        {
            Thread.Sleep(4000);

            IWebElement skillsTab = driver.FindElement(By.XPath("//a[text()='Skills']"));
            skillsTab.Click();
        }
    }
}
