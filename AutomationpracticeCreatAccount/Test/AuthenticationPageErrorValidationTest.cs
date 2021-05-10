/*
* Class Description: This Testclasssuit validate the Error messages of Authentication page.
* Author : Rajesh Vaghani
* Date of Creation : May 09, 2021
*/

using NUnit.Framework;


namespace AutomationpracticeCreatAccount.Test
{
    [TestFixture]
    class AuthenticationPageErrorValidationTest : BaseTest
    {
        [Test, Property("Description", "Verify Invalid Email adress error message")]
        [Category("GUI")]
        public void VerifyInvalidEmailErrorMessage()
        {
            PrintMessage("2. Click the Sign In button");
            authPageObject.ClickOnSignInBtn();

            PrintMessage("3. Click on 'Creat an Account' without email address");
            authPageObject.ClickOnCreateAccountBtn();

            string expectedErrorMessage = "Invalid email address.";
            PrintMessage("4. Reading the Actual error message  ");
            string actulErrorMessage = authPageObject.getEmailErrorMessage();
            PrintMessage("Actual Error message : " + actulErrorMessage);

            PrintMessage("5. Assert the actual error message with : " + expectedErrorMessage);
            Assert.AreEqual(expectedErrorMessage, actulErrorMessage);

            PrintMessage("6. Enter an invalid email address in the Create an Account section");
            authPageObject.setCreateAccountEmailBox("abc12@");

            PrintMessage("7. Reading the Actual error message  ");
            actulErrorMessage = authPageObject.getEmailErrorMessage();
            PrintMessage("Actual Error message : " + actulErrorMessage);

            PrintMessage("8. Assert the actual error message with : " + expectedErrorMessage);
            Assert.AreEqual(expectedErrorMessage, actulErrorMessage);
        
        }


        [Test, Property("Description", "Verify already registered Email adress error message")]
        [Category("GUI")]
        public void VerifyAlreadyRegisteredEmailErrorMessage()
        {
            PrintMessage("2. Click the Sign In button");
            authPageObject.ClickOnSignInBtn();

            PrintMessage("3. Enter an email address in the Create an Account section");
            authPageObject.setCreateAccountEmailBox("abc12@yahoo.com");
            
            PrintMessage("4. Click the Create an account button");
            authPageObject.ClickOnCreateAccountBtn();

            string expectedErrorMessage = "An account using this email address has already been registered. Please enter a valid password or request a new one. ";
            PrintMessage("5. Reading the Actual error message  ");
            string actulErrorMessage = authPageObject.getEmailErrorMessage();
            PrintMessage("Actual Error message : " + actulErrorMessage);

            PrintMessage("6. Assert the error message : " + expectedErrorMessage);
            Assert.AreEqual(expectedErrorMessage, actulErrorMessage);
 
        }

        [Test, Property("Description", "Verify already registered Email adress error message")]
        [Category("GUI")]
        public void VerifyredBoarderWhenEmailError()
        {
            PrintMessage("2. Click the Sign In button");
            authPageObject.ClickOnSignInBtn();

            PrintMessage("3. Enter an email address in the Create an Account section");
            authPageObject.setCreateAccountEmailBox("abc12");

            PrintMessage("4. Click the Create an account button");
            authPageObject.ClickOnCreateAccountBtn();

            string expectedBorderColor = "1px solid rgb(241, 51, 64)";   //red border
            PrintMessage("5. Assert the Border color : " + expectedBorderColor);
            string actulBorderColor = authPageObject.getEmailFieldBorderColor();
            PrintMessage("Actual Border Color : " + actulBorderColor);

            PrintMessage("5. Assert the Border color");
            Assert.AreEqual(expectedBorderColor, actulBorderColor);

            //rgb(255, 241, 242) url("http://automationpractice.com/themes/default-bootstrap/img/icon/form-error.png") no-repeat scroll 98% 5px / auto padding-box border-box

            string expectedBoxImageLink = "themes/default-bootstrap/img/icon/form-error.png";
            PrintMessage("6. Assert the Box Image link : " + expectedBoxImageLink);
            string actulBoxImageLink = authPageObject.getEmailBoxImageLink();
            PrintMessage("Actual Image link : " + actulBoxImageLink);

            PrintMessage("7. Assert the Error Image");
            Assert.IsTrue(actulBoxImageLink.Contains(expectedBoxImageLink));

        }

    }
}
