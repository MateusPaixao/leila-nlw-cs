using leilaoSolution.API.Comunication.Requests;
using leilaoSolution.API.Contracts;
using leilaoSolution.API.Entities;
using leilaoSolution.API.Services;

namespace leilaoSolution.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IOfferRepository _repository;
    public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository repository)
    {
        _loggedUser = loggedUser;
        _repository = repository;
    }
       
    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        // var respository = new leilaoSolutionDbContext();

        var user = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id
        };

        _repository.Add(offer);
        return offer.Id;
    }
}
