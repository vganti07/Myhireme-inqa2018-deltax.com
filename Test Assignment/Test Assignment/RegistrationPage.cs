using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Test_Assignment
{
    public class RegistrationPage : BasePage
    {
        public void elements(IWebDriver Browser,out IWebElement firstName, out IWebElement lastName, out IWebElement userName, out IWebElement passWord, out IWebElement confirmPwd, out IWebElement eMail, out IWebElement contact, out SelectElement Department, out IWebElement Submit)
        {
            firstName = IElements(Browser, Name: "first_name");
            lastName = IElements(Browser, Name: "last_name");
            Department =new SelectElement( Browser.FindElement(By.Name("department")));
            userName = IElements(Browser, cssSelector: "input[name='user_name']");
            passWord = IElements(Browser, Name: "user_password");
            confirmPwd = IElements(Browser, Name: "confirm_password");
            eMail = IElements(Browser, Name: "email");
            contact = IElements(Browser, Name:"contact_no");
            Submit = IElements(Browser, className: "btn-warning");
            
        }
    }
}

