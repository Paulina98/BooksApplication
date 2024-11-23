using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BooksApplication.Domain.Entities;
using BooksApplication.Models.Commands;
using BooksApplication.Models.Queries;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var query = new GetBooksQuery();
        var books = await _mediator.Send(query);
        return Ok(books);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
