using leilaoSolution.API.Comunication.Requests;
using leilaoSolution.API.Filters;
using leilaoSolution.API.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace leilaoSolution.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : leilaoSolutionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
        [FromRoute] int itemId, 
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemId, request);
        
        return Created(string.Empty, id);
    }
}
