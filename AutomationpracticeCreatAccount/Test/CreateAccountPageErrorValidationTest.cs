/*
* Class Description: This Testclasssuit validate the Error messages of Creat Account Form page.
* Author : Rajesh Vaghani
* Date of Creation : May 09, 2021
*/

using NUnit.Framework;


namespace AutomationpracticeCreatAccount.Test
{
    [TestFixture]
    class CreateAccountPageErrorValidationTest : BaseTest
    {
        [Test, Property("Description", "Verify Invalid Firstname Red Boarder")]
        [Category("GUI")]
        public void VerifyInvalidFirstnameRedBoarder()
        {
            PrintMessage("2. Click the Sign In button");
            authPageObject.ClickOnSignInBtn();
            
            PrintMessage("3. Enter an email address in the Create an Account section");
            authPageObject.setCreateAccountEmailBox("abc123a49@yahoo.com");

            PrintMessage("4. Click the Create an account button");
            authPageObject.ClickOnCreateAccountBtn();

            PrintMessage("5. Wait for the Creat Account Form page laod");
            createAccountFormPageObject.WaitForCreateAccountPageLoad();

            PrintMessage("6. Enter valid First name");
            createAccountFormPageObject.setCustomerFirstNameField("selenium");

            createAccountFormPageObject.setCustomerLastNameField("");

             PrintMessage("7. Get the First name box border color");
            string actualBorderColor = createAccountFormPageObject.getFirstNameBorderColor();
            string expectedBorderColor = "1px solid rgb(70, 167, 78)";

            Assert.AreEqual(expectedBorderColor, actualBorderColor);
            PrintMessage("8. Assert Pass = the border color : " + expectedBorderColor + " = " + actualBorderColor);

            PrintMessage("9. Enter Invalid First name");
            createAccountFormPageObject.setCustomerFirstNameField("selen(#2%)");
            createAccountFormPageObject.setCustomerLastNameField("2");

            PrintMessage("10. Get the First name box border color");
            actualBorderColor = createAccountFormPageObject.getFirstNameBorderErrorColor();

            expectedBorderColor = "1px solid rgb(241, 51, 64)";
            Assert.AreEqual(expectedBorderColor, actualBorderColor);
            PrintMessage("11. Assert Pass = the border color : " + expectedBorderColor + " = " + actualBorderColor);

            PrintMessage("12. Get the First name box check Image Link");
            string actualImageLink = createAccountFormPageObject.getFirstNameErrorImageLink();

            string expectedImageLink = "http://automationpractice.com/themes/default-bootstrap/img/icon/form-error.png";
            Assert.IsTrue(actualImageLink.Contains(expectedImageLink));

            //rgb(255, 241, 242) url("http://automationpractice.com/themes/default-bootstrap/img/icon/form-error.png") no-repeat scroll 98% 5px / auto padding-box border-box

        }

    }
}
