using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Test_Assignment
{
    
 
    public class TestCases
    {
        public IWebDriver Browser;
        private RegistrationPage _regPage;
        public string baseURL = "http://adjiva.com/qa-test/";
        public RegistrationPage regPage
        {
            get { return _regPage ?? (_regPage = new RegistrationPage()); }
        }

        [SetUp]
        public void Initial()
        {
            Browser = regPage.NavigatetoApp(baseURL);
        }
        
        [Test]
        [Category ("UI")]
        public void TestRegPageWithValidValues()
        {
            string firstName = "John";
            string lastName = "Kerry";
            string department = "Engineering";
            string userName = "JohnKerry_123";
            string password = "IKnowSelenium1*";
            string eMail = "john@xyz.com";
            string contact = "9867564789";
            IWebElement FName, LName, UName, Pwd, confirmPwd, Email, Phone, Submit;
            SelectElement Department;
            regPage.elements(Browser,out FName, out LName, out UName, out Pwd, out confirmPwd, out Email, out Phone, out Department, out Submit);
            FName.SendKeys(firstName);
            //var isValidIcon = FName.FindElement(By.ClassName("glyphicon-ok"));
            Assert.IsTrue((isValidDataIcon(FName)), "valid data icon is not displayed on entering the correct data on First Name"+FName.Text);
            LName.SendKeys(lastName);
            Assert.IsTrue((isValidDataIcon(LName)), "valid data icon is not displayed on entering the correct data on Last Name"+LName.Text);
            Department.SelectByText(department);
            UName.SendKeys(userName);
            Assert.IsTrue((isValidDataIcon(UName)), "valid data icon is not displayed on entering the correct data on Last Name" + UName.Text);
            Pwd.SendKeys(password);
            Assert.IsTrue((isValidDataIcon(Pwd)), "valid data icon is not displayed on entering the correct data on Last Name" + Pwd.Text);
            confirmPwd.SendKeys(password);
            Assert.IsTrue((isValidDataIcon(confirmPwd)), "valid data icon is not displayed on entering the correct data on Last Name" + confirmPwd.Text);
            Phone.SendKeys(contact);
            Assert.IsTrue((isValidDataIcon(Phone)), "valid data icon is not displayed on entering the correct data on Last Name" + Phone.Text);
            Email.SendKeys(eMail);
            Assert.IsTrue((isValidDataIcon(Email)), "valid data icon is not displayed on entering the correct data on Last Name" + Email.Text);
            Submit.Click();
            var success = Browser.FindElement(By.Id("contact_form"));
            Assert.True((success.Text == "Thanks"), "Registration was unsuccessful");
        }


        public bool isValidDataIcon(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser;
            IWebElement Parent = jse.ExecuteScript("return arguments[0].parentNode;", element) as IWebElement;
            var validIcon = Parent.FindElement(By.ClassName("glyphicon-ok"));
            if (validIcon.Displayed && validIcon.Enabled)
            {
                return true;
            }
            else
                return false;
        }
        [Test]
        [Category("UI")]
        public void TestRegPagewithInvalidValues()
        {
            string firstName = "J";
            string lastName = "K";
            string department = "Engineering";
            string userName = "JK_123";
            string password = "passwor";
            string eMail = "johncom";
            string contact = "98675647a";
            IWebElement FName, LName, UName, Pwd, confirmPwd, Email, Phone, Submit;
            SelectElement Department;
            regPage.elements(Browser, out FName, out LName, out UName, out Pwd, out confirmPwd, out Email, out Phone, out Department, out Submit);
            FName.SendKeys(firstName);
            //var isValidIcon = FName.FindElement(By.ClassName("glyphicon-ok"));
            Assert.IsTrue((isInvalidDataIcon(FName)), "Invalid data icon is not displayed on entering the incorrect data on First Name"+FName.Text);
            LName.SendKeys(lastName);
            Assert.IsTrue((isInvalidDataIcon(LName)), "Invalid data icon is not displayed on entering the incorrect data on Last Name" + LName.Text);
            Department.SelectByText(department);
            UName.SendKeys(userName);
            Assert.IsTrue((isInvalidDataIcon(UName)), "Invalid data icon is not displayed on entering the incorrect data on Last Name" + UName.Text);
            Pwd.SendKeys(password);
            Assert.IsTrue((isInvalidDataIcon(Pwd)), "Invalid data icon is not displayed on entering the incorrect data on Last Name" + Pwd.Text);
            confirmPwd.SendKeys(password);
            Assert.IsTrue((isInvalidDataIcon(confirmPwd)), "Invalid data icon is not displayed on entering the incorrect data on Last Name" + confirmPwd.Text);
            Phone.SendKeys(contact);
            Assert.IsTrue((isInvalidDataIcon(Phone)), "Invalid data icon is not displayed on entering the incorrect data on Last Name" + Phone.Text);
            Email.SendKeys(eMail);
            Assert.IsTrue((isInvalidDataIcon(Email)), "Invalid data icon is not displayed on entering the incorrect data on Last Name" + Email.Text);
            if (Submit.Enabled && Submit.Displayed)
            {
                Submit.Click();
            }
            else
                Assert.Fail("The form has incorrect data and submission was unsuccessful");
        }

        [Test]
        [Category("UI")]
        public void TestRegPagewithBlankFieldsonCompulsaryDataFields()
        {
            string firstName = "";
            string lastName = "";
            string department = "Engineering";
            string userName = "";
            string password = "";
            string eMail = "";
            string contact = "9867564790";
            IWebElement FName, LName, UName, Pwd, confirmPwd, Email, Phone, Submit;
            SelectElement Department;
            regPage.elements(Browser, out FName, out LName, out UName, out Pwd, out confirmPwd, out Email, out Phone, out Department, out Submit);
            FName.SendKeys(firstName);
            LName.SendKeys(lastName);
            Department.SelectByText(department);
            UName.SendKeys(userName);
            Pwd.SendKeys(password);
            confirmPwd.SendKeys(password);
            Phone.SendKeys(contact);
            Email.SendKeys(eMail);
            if (Submit.Displayed && Submit.Enabled)
                Submit.Click();
            Assert.IsTrue((isInvalidDataIcon(FName)), "Invalid data icon is not displayed on entering the incorrect data on First Name" + FName.Text);
            Assert.IsTrue((isInvalidDataIcon(LName)), "Invalid data icon is not displayed on entering the incorrect data on Last Name" + LName.Text);
            Assert.IsTrue((isInvalidDataIcon(UName)), "Invalid data icon is not displayed on entering the incorrect data on Last Name" + UName.Text);
            Assert.IsTrue((isInvalidDataIcon(Pwd)), "Invalid data icon is not displayed on entering the incorrect data on Last Name" + Pwd.Text);
            Assert.IsTrue((isInvalidDataIcon(confirmPwd)), "Invalid data icon is not displayed on entering the incorrect data on Last Name" + confirmPwd.Text);
            Assert.IsTrue((isInvalidDataIcon(Email)), "Invalid data icon is not displayed on entering the incorrect data on Last Name" + Email.Text);
            if (Submit.Enabled && Submit.Displayed)
            {
                Submit.Click();
            }
            else
                Assert.Fail("The form has incorrect data and submission was unsuccessful");
   

        }

        public bool isInvalidDataIcon(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser;
            IWebElement Parent = jse.ExecuteScript("return arguments[0].parentNode;", element) as IWebElement;        
            var validIcon = Parent.FindElement(By.ClassName("glyphicon-remove"));
            if (validIcon.Displayed && validIcon.Enabled)
            {
                return true;
            }
            else
                return false;
        }

        [TearDown]
        public void Final()
        {
            Browser.Quit();
        }
    }
}
