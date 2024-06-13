using leilaoSolution.API.Entities;

namespace leilaoSolution.API.Contracts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}
