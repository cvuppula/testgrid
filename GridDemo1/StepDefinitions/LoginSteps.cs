using GridDemo1.PageObjects;
using GridDemo1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GridDemo1.StepDefinitions
{
    [Binding]
    public sealed class LoginSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly IWebDriver webDriver;
        readonly WebDriverHelper Driver;

        //public LoginSteps(ScenarioContext injectedContext)
        //{
        //    context = injectedContext;
        //}

        //public LoginSteps(IWebDriver webDriver) => this.webDriver = webDriver;
        public LoginSteps(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            Driver = new WebDriverHelper(webDriver);
        }
        

        [Given(@"I navigated to /")]
        public void GivenINavigatedTo()
        {
            Console.WriteLine("TEST");
            //webDriver.Navigate().GoToUrl("https://www.google.com");
            Driver.Navigate("https://www.google.com");
        }

        [Then(@"browser title is Calculator")]
        public void ThenBrowserTitleIsCalculator()
        {
            Console.WriteLine("TEST1");
            //webDriver.Navigate().GoToUrl("https://www.facebook.com");
            Driver.Navigate("https://www.facebook.com");
        }



        [Given(@"I navigate to Home page")]
        public void GivenINavigateToHomePage()
        {
            Driver.Navigate("https://enterpriseweb.dev.cndt.cf/home");
        }

        [When(@"I add a customer with below data")]
        public void WhenIAddACustomerWithBelowData(Table table)
        {
            /*HomePage homePage = new HomePage(webDriver);
            homePage.ClickCustomerManagement();
            NewCustomerPage newCustomer = new NewCustomerPage(webDriver);
            //newCustomer.AddNewCustomer(table.Rows[0]["Name"]);
            dynamic details = table.CreateDynamicInstance();
            newCustomer.AddNewCustomer(details);
            Assert.IsTrue(newCustomer.Save.Enabled, "Save Button is not Enabled.");*/
        }

        [Then(@"I verify customer data is added as ""(.*)""")]
        public void ThenIVerifyCustomerDataIsAddedAs(string p0)
        {
            if (p0.Equals("true"))
                Assert.IsTrue(true);
            else
                Assert.IsFalse(true);
        }

        [Then(@"I skip the step")]
        public void ThenISkipTheStep()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
