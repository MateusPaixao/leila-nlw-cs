using leilaoSolution.API.Contracts;
using leilaoSolution.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace leilaoSolution.API.Repositories.DataAccess;

public class AuctionRepository: IAuctionRepository
{
    private readonly leilaoSolutionDbContext _dbContext;
    public AuctionRepository(leilaoSolutionDbContext dbContext) => _dbContext = dbContext;
    
    public Auction? GetCurrent()
    {
        var today = DateTime.Now;
        return _dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}
