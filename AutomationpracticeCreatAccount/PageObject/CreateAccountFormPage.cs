using OpenQA.Selenium;
using System;
using AutomationpracticeCreatAccount.Utils;
using System.Threading;

namespace AutomationpracticeCreatAccount.PageObject
{
    class CreateAccountFormPage : Utils.Engine
    {
        #region happy path methods
        public void WaitForCreateAccountPageLoad()
        {
            WaitUntilElementFound(LocatorRepo.PersonalInfopageLoad);
        }

        public void setCustomerFirstNameField(String firstName)
        {
            EnterValue(LocatorRepo.PI_CustomerFirstName, firstName);
        }

        public void setCustomerLastNameField(String lastName)
        {
            EnterValue(LocatorRepo.PI_CustomerLastName, lastName);
        }

        public void setCustomerPasswordField(String password)
        {
            EnterValue(LocatorRepo.PI_Password, password);
        }

        public void setAddressField(String address)
        {
            EnterValue(LocatorRepo.PI_Address, address);
        }

        public void setCityField(String city)
        {
            EnterValue(LocatorRepo.PI_City, city);
        }

        public void selectState(String state)
        {
            SelectDropDownByText(LocatorRepo.PI_State, state);
        }

        public void setPostalCodeField(String zip)
        {
            EnterValue(LocatorRepo.PI_ZipCode, zip);
        }

        public void setMobilePhoneField(String phone)
        {
            EnterValue(LocatorRepo.PI_MobilePhone, phone);
        }

        public void setAddressAliasField(String alias)
        {
            EnterValue(LocatorRepo.PI_AddAlias, alias);
        }

        public void  ClickOnRegisterBtn()
        {
            WaitToBeClickable(By.Id(LocatorRepo.PI_submitAccountButton), 30).Click();
        }

        public IWebElement successfullyCreatedAccount()
        {
            return WaitForElementPresence(By.XPath(LocatorRepo.WelComemessage), 30);
        }
        #endregion

        #region Negative secinario
        public IWebElement getErrorPanel()
        {
            return WaitForElementPresence(LocatorRepo.Register_Error_PI, 30);
        }

        public IWebElement getHomePhoneInvalidError()
        {
            return WaitForElementPresence(LocatorRepo.Phone_Error_PI, 30);
        }

        public IWebElement getMobilePhoneInvalidError()
        {
            return WaitForElementPresence(LocatorRepo.Mobile_Error_PI, 30);
        }
        #endregion

        #region BORDER COLOR

        public string getFirstNameBorderColor()
        {
            Wait(100);
            return GetCSSValueOfElement(LocatorRepo.Firstname_OK_PI, "border");
        }

        public string getFirstNameBorderErrorColor()
        {
            Wait(100);
            return GetCSSValueOfElement(LocatorRepo.PI_CustomerFirstName, "border");
        }

        public string getFirstNameErrorImageLink()
        {
            Wait(100);
            return GetCSSValueOfElement(LocatorRepo.PI_CustomerFirstName, "background");
        }
        #endregion
    }
}
