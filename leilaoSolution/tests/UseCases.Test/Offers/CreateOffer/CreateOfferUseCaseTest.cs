using Bogus;
using FluentAssertions;
using leilaoSolution.API.Comunication.Requests;
using leilaoSolution.API.Contracts;
using leilaoSolution.API.Entities;
using leilaoSolution.API.Services;
using leilaoSolution.API.UseCases.Offers.CreateOffer;
using Moq;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        // Arrange -> What I need to run the test/implementation

        var request = new Faker<RequestCreateOfferJson>()
               .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700)).Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        //  Act -> The action that I should test
        var act = () => useCase.Execute(itemId, request);

        // Assert -> What I expect to run/receive on this test
        act.Should().NotThrow();
    }
}
