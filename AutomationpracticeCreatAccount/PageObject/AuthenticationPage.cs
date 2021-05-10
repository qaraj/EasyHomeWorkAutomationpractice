/*
* Class Description: AuthenticationPage Class, is the page object, providce all the functionality methods to test the features
* Author : Rajesh Vaghani
* Date of Creation : May 09, 2021
*/
using AutomationpracticeCreatAccount.Utils;
using OpenQA.Selenium;
using System;


namespace AutomationpracticeCreatAccount.PageObject
{
    class AuthenticationPage : Utils.Engine
    {
        public void ClickOnSignInBtn()
        {
            WaitToBeClickable(By.XPath(LocatorRepo.SigInHome), 30).Click();
        }

        public void setCreateAccountEmailBox(String email)
        {
            EnterValue(LocatorRepo.EmailCreatAcount, email);
        }
     
        public void ClickOnCreateAccountBtn()
        {
            WaitToBeClickable(By.XPath(LocatorRepo.CreateAccountButton), 30).Click();
        }

        #region  Login to the account
        public void setSignInEmailBox(String email)
        {
            EnterValue(LocatorRepo.EmailLogIn, email);
        }

        public void setSignInPasswordBox(String password)
        {
            EnterValue(LocatorRepo.PassWdLogIn, password);
        }

        public void ClickLogInBtn()
        {
            WaitToBeClickable(By.Id(LocatorRepo.LogInButton), 30).Click();
        }

        #endregion Login

        public string getValueOfTitle()
        {
            return Driver.FindElement(By.XPath(LocatorRepo.ViewAccountName)).GetAttribute("textContent");
        }

        //  Error message validation
        public string getEmailErrorMessage()
        {   
            return GetTextValueOfElement(LocatorRepo.EmailCreatAcountErrMessage);
        }
    
        public string getEmailFieldBorderColor()
        {
            Wait(200);
            return GetCSSValueOfElement(LocatorRepo.EmailCreatAcount, "border");
        }

        public string getEmailBoxImageLink()
        {
            return GetCSSValueOfElement(LocatorRepo.EmailCreatAcount, "background");
        }

    }
}
