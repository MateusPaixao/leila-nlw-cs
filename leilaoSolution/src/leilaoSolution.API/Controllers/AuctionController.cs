using leilaoSolution.API.Entities;
using leilaoSolution.API.UseCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc; // its like the import on JS

namespace leilaoSolution.API.Controllers; // its like the export on JS

public class AuctionController : leilaoSolutionBaseController
{
    [HttpGet] // http codes
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentActionResult([FromServices] GetCurrentAuctionUseCase useCase) // IActionResult 
    {
        var result = useCase.Execute();

        if (result is null)
            return NoContent();

        return Ok(result); // Ok, Created, NotFound, Unauthorized...
    }
}