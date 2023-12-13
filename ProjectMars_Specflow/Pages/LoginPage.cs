using OpenQA.Selenium;
using ProjectMars_Specflow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_Specflow.Pages
{
    public class LoginPage : CommonDriver
    {
        public void LoginActions()
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://localhost:5000/Home");

            IWebElement signInButton = driver.FindElement(By.XPath("//div[@id='home']/div/div/div/div/a"));
            signInButton.Click();

            Thread.Sleep(4000);

            IWebElement usernameTextbox = driver.FindElement(By.XPath("//input[@name='email']"));
            usernameTextbox.SendKeys("sasi.ei34@gmail.com");

            IWebElement passwordTextbox = driver.FindElement(By.XPath("//input[@name='password']"));
            passwordTextbox.SendKeys("Selenium@2");

            IWebElement loginButton = driver.FindElement(By.XPath("//button[text()='Login']"));
            loginButton.Click();

        }
    }
}
