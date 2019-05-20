using Domain.Enumerations;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IConfigFileReader
    {
        User GetCredentials();
        bool GetShouldLog();
        Browser GetBrowser();
    }
}
