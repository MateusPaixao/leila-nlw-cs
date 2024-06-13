using leilaoSolution.API.Contracts;
using leilaoSolution.API.Entities;

namespace leilaoSolution.API.Repositories.DataAccess;

public class OfferRepository: IOfferRepository
{
    private readonly leilaoSolutionDbContext _dbContext;
    public OfferRepository(leilaoSolutionDbContext dbContext) => _dbContext = dbContext;


    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);
        _dbContext.SaveChanges();
    }
}
