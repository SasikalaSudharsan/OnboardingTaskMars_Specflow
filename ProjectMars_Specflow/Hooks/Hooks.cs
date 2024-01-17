using OpenQA.Selenium.Chrome;
using ProjectMars_Specflow.Utilities;
using TechTalk.SpecFlow;

namespace ProjectMars_Specflow.Hooks
{
    [Binding]
    public sealed class Hooks : CommonDriver
    {       

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            Initialize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Close();
        }
    }
}