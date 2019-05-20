using Domain.Enumerations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Domain
{
    public static class DriverFactory
    {
        public static IWebDriver GetDriver(Browser browser)
        {
            var driverPath = Constants.GetSolutionPath();

            switch (browser)
            {
                case Browser.Chrome:
                    return new ChromeDriver(driverPath);

                case Browser.Firefox:
                    throw new NotImplementedException("Firefox is not yet implemented! Please select another browser");

                case Browser.Edge:
                    throw new NotImplementedException("Edge is not yet implemented! Please select another browser!");

                case Browser.Ie:
                    throw new NotImplementedException("Internet Explorer is not yet implemented! Please select another browser!");

                default:
                    throw new IOException("Incorrect browser input! Check available browsers in Enumerations/Browser.cs");
            }
        }
    }
}
