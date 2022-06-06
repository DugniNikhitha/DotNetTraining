using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Training.Sample.Utilities;

namespace Training.Sample.PageObjects
{
    public class EPAMSearchPage
    {
        private IWebDriver driver;
        public EPAMSearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public BaseElement SearchBox()
        {
            return new BaseElement(driver, By.Id("new_form_search"));
        }
        public BaseElement AcceptCookies()
        {
            return new BaseElement(driver, By.XPath("//button[text()='Accept All']"));
        }

        public BaseElement ResultCount()
        {
            return new BaseElement(driver, By.ClassName("search-results__counter"));
        }
    }
}
