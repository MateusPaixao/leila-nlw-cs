using leilaoSolution.API.Entities;

namespace leilaoSolution.API.Contracts;

public interface IUserRepository
{
    bool ExistUserEmail(string email);
    User GetUserByEmail(string email);
}
