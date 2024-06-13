using leilaoSolution.API.Contracts;
using leilaoSolution.API.Entities;

namespace leilaoSolution.API.Repositories.DataAccess;

public class UserRepository: IUserRepository
{
    private readonly leilaoSolutionDbContext _dbContext;
    public UserRepository(leilaoSolutionDbContext dbContext) => _dbContext = dbContext;
    
    public bool ExistUserEmail(string email)
    {
       return _dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User GetUserByEmail(string email)
    {
        return _dbContext.Users.First(user => user.Email.Equals(email));
    }
}
