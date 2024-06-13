using leilaoSolution.API.Contracts;
using leilaoSolution.API.Entities;

namespace leilaoSolution.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _repository;

    public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;

    public Auction? Execute()
    {
        return _repository.GetCurrent();

        /*
        return new Auction
        {
            Id = 1,
            Starts = DateTime.Now,
            Ends = DateTime.Now,
            Name = "test",
        };
        */
    }
}
