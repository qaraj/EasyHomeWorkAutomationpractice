/*
* Class Description: BaseTest Class, is the setup test class
* Author : Rajesh Vaghani
* Date of Creation : May 09, 2021
*/

using NUnit.Framework;
using AutomationpracticeCreatAccount.PageObject;


namespace AutomationpracticeCreatAccount.Test
{
    class BaseTest : Utils.Engine
    {
        public CreateAccountFormPage createAccountFormPageObject;
        public AuthenticationPage authPageObject;
        

        [SetUp]
        public void SetUpTest()
        {
            PrintMessage("Openning Chrome browser...");
            OpenChromeBrowser();
            PrintMessage("1. Browser Launch");
            createAccountFormPageObject = new CreateAccountFormPage();
            authPageObject = new AuthenticationPage();
            
        }

        [TearDown]
        public void Teardown()
        {
            PrintMessage("*** " + TestContext.CurrentContext.Test.Name + " --- Test Result :  "+ TestContext.CurrentContext.Result.Outcome.Status.ToString() + " ***");
            if (TestContext.CurrentContext.Result.Outcome.Label == "Error")
            {
                TakeScreenShot(TestContext.CurrentContext.Test.Name);
            }

            Driver.Quit();
            PrintMessage("Driver Quit successfully");
        }


    }
}
