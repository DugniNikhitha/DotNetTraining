using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Sample.Utilities;

namespace Training.Sample.PageObjects
{
    public class EPAMHomePage : BasePage
    {
        private IWebDriver driver;
        public EPAMHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            //PageFactory.InitElements(driver, this);
            //this - current class object - to get driver access
        }

        //[FindsBy(How = How.XPath, Using = "//button[text()='Accept All']")]
        //private IWebElement acceptButton;

        public BaseElement SearchButton()
        {
            return new BaseElement(driver, By.XPath("//button[contains(@class, 'header-search__button')]"));
        }
        public BaseElement AcceptCookies()
        {
            return new BaseElement(driver, By.XPath("//button[text()='Accept All']"));
        }

    }
   
}
