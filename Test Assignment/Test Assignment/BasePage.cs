using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Test_Assignment
{
    public class BasePage
    {
        public IWebDriver NavigatetoApp(string url)
        {
            IWebDriver myChrome;
            myChrome = new OpenQA.Selenium.Chrome.ChromeDriver();
            myChrome.Navigate().GoToUrl(url);
            myChrome.Manage().Window.Maximize();
            return myChrome;
        }
        public IWebElement IElements(IWebDriver driver,string ID=null, string className=null, string cssSelector=null, string Name=null)
        {
            
            IWebElement element=null;
            try
            {
               if(ID!=null)
                {
                    element = driver.FindElement(By.Id(ID));
                }
               else if(className!=null)
                {
                    element = driver.FindElement(By.ClassName(className));
                }
               else if(cssSelector!=null)
                {
                    element = driver.FindElement(By.CssSelector(cssSelector));
                }
                else if (Name != null)
                {
                    element = driver.FindElement(By.Name(Name));
                }

                return element;
            }

            catch(NoSuchElementException)
            {
                return null;
            }

            
        }
    }
}
