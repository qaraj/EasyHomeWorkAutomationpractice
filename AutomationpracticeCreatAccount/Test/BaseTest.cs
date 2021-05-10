using NUnit.Framework;
using AutomationpracticeCreatAccount.PageObject;
using NUnit.Framework.Internal;

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
