using Bogus;
using FluentAssertions;
using leilaoSolution.API.Contracts;
using leilaoSolution.API.Entities;
using leilaoSolution.API.Enums;
using leilaoSolution.API.UseCases.Auctions.GetCurrent;
using Moq;
using Xunit;



namespace UseCases.Test.Auctions.GetCurrent;

public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Success()
    {
        // Arrange -> What I need to run the test/implementation

        var entity = new Faker<Auction>()
               .RuleFor(auction => auction.Id, f => f.Random.Number(1, 100))
               .RuleFor(auction => auction.Name, f => f.Lorem.Word())
               .RuleFor(auction => auction.Starts, f => f.Date.Past())
               .RuleFor(auction => auction.Ends, f => f.Date.Future())
               .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
               {
                   new Item
                   {
                       Id = f.Random.Number(1, 100),
                       Name = f.Commerce.ProductName(),
                       Brand = f.Commerce.Department(),
                       BasePrice = f.Random.Decimal(50, 1000),
                       Condition = f.PickRandom<Condition>(),
                       AuctionId = auction.Id,
                   }
               }).Generate();

        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(entity);


        var useCase = new GetCurrentAuctionUseCase(mock.Object);

        //  Act -> The action that I should test
        var auction= useCase.Execute();

        // Assert -> What I expect to run/receive on this test
        
        // Assert.NotNull(auction); native assertation

        auction.Should().NotBeNull(); // from the package fluent assertation
        auction.Id.Should().Be(entity.Id);
        auction.Name.Should().Be(entity.Name);
    }
}
