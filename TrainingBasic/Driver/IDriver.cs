using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Helpers.Driver
{
    public interface IDriver
    {
        public IWebDriver GetDriver();
        public void GoToUrl();
        public void MaximiseDriver();
        public void MinimiseDriver();
        public void RefreshDriver();
        public void GoBackDriver();
        public void GoForwardDriver();
        public void ImplicitWait(int timeInSec);
        public void CloseDriver();
        public void QuitDriver();

    }
}
