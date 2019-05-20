using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAuthorization
    {
        Token GetToken(User user);
    }
}
