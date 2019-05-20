using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Pages
{
    public class Page
    {
        protected IWebDriver Driver;

        public Page (IWebDriver driver) { Driver = driver; }
    }
}
