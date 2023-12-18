using OpenQA.Selenium.Chrome;
using ProjectMars_Specflow.Utilities;
using TechTalk.SpecFlow;

namespace ProjectMars_Specflow.Hooks
{
    [Binding]
    public sealed class Hooks : CommonDriver
    {       

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
           
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://localhost:5000/Home");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}