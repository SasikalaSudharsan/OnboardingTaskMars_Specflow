using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using ProjectMars_Specflow.Pages;
using ProjectMars_Specflow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_Specflow.Tests
{
    [TestFixture]
    public class Skills_Tests : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        SkillsPage skillsPageObj = new SkillsPage();

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();

            loginPageObj.LoginActions();
            homePageObj.GoToSkillsPage();
        }
        [Test]
        public void AddSkill_Test()
        {
            skillsPageObj.Add_Skills();
        }
        [Test]
        public void UpdateSkill_Test()
        {
            skillsPageObj.Update_Skills();
        }
        [Test]
        public void DeleteLanguage_Test()
        {
            skillsPageObj.Delete_Skills();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();

        }
    }
}
