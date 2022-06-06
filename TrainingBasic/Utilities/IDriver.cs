using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Training.Sample.Utilities
{
    public interface IDriver
    {
        public IWebDriver GetDriver();
        public void GoToUrl(string url);
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
