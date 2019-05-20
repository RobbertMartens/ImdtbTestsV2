using OpenQA.Selenium;

namespace Domain.Pages
{
    public class Header : Page
    {
        private IWebElement _signUpButton => Driver.FindElement(By.XPath("//* [@href='/signup']"));
        private IWebElement _profileButton => Driver.FindElement(By.XPath("//* [@href='/profile']"));
        private IWebElement _loginButton => Driver.FindElement(By.XPath("//* [@href='/login']"));
        private IWebElement _logoutButton => Driver.FindElement(By.XPath("//* [@href='/logout']"));

        public Header(IWebDriver driver) : base(driver) { }

        public void GoToLogin()
        {
            _loginButton.Click();
        }

        public void LogOut()
        {
            _logoutButton.Click();
        }

        public void GoToSignUp()
        {
            _signUpButton.Click();
        }

        public void GoToProfile()
        {
            _profileButton.Click();
        }
    }
}
