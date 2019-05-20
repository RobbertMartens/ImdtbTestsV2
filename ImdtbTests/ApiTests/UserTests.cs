using Domain.Controllers;
using Domain.Models;
using System;
using Xunit;
using Xunit.Abstractions;

namespace ImdtbTests.ApiTests
{
    [Collection("Api tests: User")]
    [Trait("Api tests", "User tests")]
    public class UserTests : IClassFixture<ApiTestFixture>, IDisposable
    {
        private Token _token;
        private TokenController _tokenController;
        private ApiTestFixture _fixture;
        private ITestOutputHelper _output;

        public UserTests(ApiTestFixture fixture, ITestOutputHelper output)
        {
            _fixture = fixture;
            _output = output;
            _tokenController = new TokenController();
        }

        public void Dispose()
        {
            _fixture = null;
            _output = null;
            _tokenController = null;
            _token = null;
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        [Fact]
        public void GetTokenTest()
        {
            _token = _tokenController.GetToken(_fixture.User);

            Assert.NotNull(_token.access_token);
            Assert.InRange(_token.access_token.Length, 2, 500);

            _output.WriteLine(_token.access_token);
        }

        [Fact]
        public void GetTokenAgain()
        {
            _token =  _tokenController.GetToken(_fixture.User);

            Assert.NotNull(_token.access_token);
            Assert.InRange(_token.access_token.Length, 2, 500);

            _output.WriteLine(_token.access_token);
        }
    }
}
