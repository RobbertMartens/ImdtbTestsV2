using Domain.Controllers;
using Domain.Helpers;
using Domain.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace ImdtbTests
{
    public class ApiTestFixture : IDisposable
    {
        public User User { get; private set; }
        protected Token Token { get; private set; }

        private bool _disposed = false;
        private ConfigFileReader _configFile;
        private SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        public ApiTestFixture()
        {
            _configFile = new ConfigFileReader();
            User = _configFile.GetCredentials();
            Token = new TokenController().GetToken(User);
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
                Token = null;
                _configFile = null;
                User = null;
            }
            _disposed = true;
        }
    }
}
