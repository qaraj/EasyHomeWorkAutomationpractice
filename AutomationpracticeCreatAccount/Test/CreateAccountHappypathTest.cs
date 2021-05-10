/*
* Class Description: This Testclass verify the happy path for Creat Account.
* Author : Rajesh Vaghani
* Date of Creation : May 09, 2021
*/

using NUnit.Framework;


namespace AutomationpracticeCreatAccount.Test
{
    [TestFixture]
    class CreateAccountHappypathTest : BaseTest
    {
        [Test, Property("Description", "Verify CreateAccountForm HappyPath")]
        [Category("GUI")]
        public void VerifyCreateAccountFormHappyPath()
        {
            PrintMessage("2. Click the Sign In button");
            authPageObject.ClickOnSignInBtn();

            PrintMessage("3. Enter an email address in the Create an Account section (this email doesn’t have to be real)");
            authPageObject.setCreateAccountEmailBox("abcz1234@yahoo.com");

            PrintMessage("4. Click the Create an account button");
            authPageObject.ClickOnCreateAccountBtn();

            PrintMessage("5. Enter the following information for Your Personal Information section:");
            createAccountFormPageObject.WaitForCreateAccountPageLoad();

            PrintMessage("5.a First name");
            createAccountFormPageObject.setCustomerFirstNameField("selenium");

            PrintMessage("5.b Last name");
            createAccountFormPageObject.setCustomerLastNameField("driver");

            PrintMessage("5.c Email(should be auto - populated from last screen)");

            PrintMessage("5.d Password(make this a dummy password)");
            createAccountFormPageObject.setCustomerPasswordField("selenium");

            PrintMessage("6. Enter the following information for Your Address section:");
            PrintMessage("6.a First name(should be auto - populated from the above section)");
            PrintMessage("6.b Last name(should be auto - populated from the above section)");
            
            PrintMessage("6.c Address");
            createAccountFormPageObject.setAddressField("napervile");
            
            PrintMessage("6.d City");
            createAccountFormPageObject.setCityField("napervile");
            
            PrintMessage("6.e State(select from dropdown)");
            createAccountFormPageObject.selectState("Ohio");

            PrintMessage("6.f Zip");
            createAccountFormPageObject.setPostalCodeField("60101");

            PrintMessage("6.g Country(should be United States by default)");
            
            PrintMessage("6.h Mobile phone");
            createAccountFormPageObject.setMobilePhoneField("6309090909");
            
            PrintMessage("6.i Address alias");
            createAccountFormPageObject.setAddressAliasField("happy");
            
            PrintMessage("7. Click Register");
            createAccountFormPageObject.ClickOnRegisterBtn();

            PrintMessage("8. Assert that the logged in user is the same first / last name that you entered");
            //Assert.IsTrue(createAccountFormPageObject.successfullyCreatedAccount().Displayed);

            string expectedTitle = "selenium driver";
            string actualTitle = authPageObject.getValueOfTitle();
            PrintMessage("Actual title : " + actualTitle);

            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [Test, Property("Description", "Verify Login HappyPath")]
        [Category("GUI")]
        public void VerifyLoginHappyPath()
        {
            PrintMessage("2. Click the Sign In button");
            authPageObject.ClickOnSignInBtn();

            PrintMessage("3. Enter an email address/password");
            authPageObject.setSignInEmailBox("abc12@yahoo.com");
            authPageObject.setSignInPasswordBox("selenium");

            PrintMessage("4. SignIn");
            authPageObject.ClickLogInBtn();

            string expectedTitle = "selenium selenium";
            PrintMessage("5. Assert the first / last name : " + expectedTitle);
            string actualTitle = authPageObject.getValueOfTitle();
            PrintMessage("Actual title : " + actualTitle);

            Assert.AreEqual(expectedTitle, actualTitle);

        }

    }
}
