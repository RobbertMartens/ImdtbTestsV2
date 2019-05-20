using Domain;
using Domain.Enumerations;
using Domain.Helpers;
using Domain.Models;
using Microsoft.Win32.SafeHandles;
using OpenQA.Selenium;
using System;
using System.Runtime.InteropServices;

namespace ImdtbTests
{
    public class UITestFixture : IDisposable
    {
        public User User { get; private set; }
        public IWebDriver Driver { get; private set; }

        private bool _disposed = true;
        private Browser _browser;
        private ConfigFileReader _configFile;
        private SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        public UITestFixture()
        {
            _configFile = new ConfigFileReader();
            User = _configFile.GetCredentials();
            _browser = _configFile.GetBrowser();
            Driver = DriverFactory.GetDriver(_browser);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.Url = Constants.HomePage;
            Driver.Manage().Window.Maximize();
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _handle.Dispose();
                _configFile = null;
                User = null;
            }
            _disposed = true;
        }
    }
}
