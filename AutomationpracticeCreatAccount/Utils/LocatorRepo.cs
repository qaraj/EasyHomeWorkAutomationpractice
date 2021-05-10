using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationpracticeCreatAccount.Utils
{
    public class LocatorRepo
    {
        internal static string SigInHome = "//a[contains(text(), 'Sign in')]";
        internal static string EmailCreatAcount = "//input[@id='email_create']";
        internal static string CreateAccountButton = "//button[@id='SubmitCreate']";
        internal static string EmailCreatAcountErrMessage = "//div[@id='create_account_error']/ol/li";
        internal static string ViewAccountName = "//a[@title='View my customer account']/span";

        #region Authentication SignIn Section
        internal static string EmailLogIn = "//input[@id='email']";
        internal static string PassWdLogIn = "//input[@id='passwd']";
        internal static string LogInButton = "SubmitLogin";
        #endregion Authentication SignIn Section


        #region Personal Information page
        internal static string PersonalInfopageLoad = "//h3[contains(text(),'Your personal information')]";
        internal static string PI_CustomerFirstName = "//input[@id='customer_firstname']";
        internal static string PI_CustomerLastName = "//input[@id='customer_lastname']";
        internal static string PI_Password = "//input[@id='passwd']";
        internal static string PI_Address = "//input[@id='address1']";
        internal static string PI_City = "//input[@id='city']";
        internal static string PI_State = "//select[@id='id_state']";
        internal static string PI_ZipCode = "//input[@id='postcode']";
        internal static string PI_MobilePhone = "//input[@id='phone_mobile']";
        internal static string PI_AddAlias = "//input[@id='alias']";
        internal static string PI_submitAccountButton = "submitAccount";
        internal static string WelComemessage = "//p[contains(text(), 'Welcome to your account.')]";
        #endregion Personal Information page

        #region Personal Information page Error element locators
            internal static string Register_Error_PI = "//li[contains(text(), \"You must register\")]/../..";
            internal static string  Phone_Error_PI   = "//li[contains(text(), \" is invalid.\")]/b[contains(text(), \"phone\")]";
            internal static string Mobile_Error_PI   = "//li[contains(text(), \" is invalid.\")]/b[contains(text(), \"phone_mobile\")]";
            internal static string Firstname_OK_PI   = "//div[@class=\"required form-group form-ok\"]//input[@id=\"customer_firstname\"]";
            internal static string Firstname_Error_PI="//div[@class=\"required form-group form-error\"]//input[@id=\"customer_firstname\"]";
        #endregion Personal Information page Error element locators
    }
}
