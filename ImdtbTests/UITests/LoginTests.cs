using Domain;
using System;
using Xunit;
using Xunit.Abstractions;

namespace ImdtbTests.UITests
{
    [Collection("UI tests: Login")]
    [Trait("Web tests", "Login tests")]
    public class LoginTests : IClassFixture<UITestFixture>, IDisposable
    {
        private UITestFixture _fixture;
        private ITestOutputHelper _output;

        public LoginTests(UITestFixture testFixture, ITestOutputHelper output)
        { 
            _fixture = testFixture;
            _output = output;
        }

        public void Dispose()
        {
            _fixture.Driver.Manage().Cookies.DeleteAllCookies();
            _fixture.Driver.Close();
            _fixture.Driver.Quit();
            _fixture = null;
            _output = null;
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        [Fact]
        public void UserLogsIn()
        {
        }
    }
}
