using Microsoft.AspNetCore.Mvc;
using Test3.Api.Models;
using Test3.Api.Services;

namespace Test3.Api.Controllers;

/// <summary>TODO item endpoints.</summary>
[ApiController]
[Route("api/todos")]
[Produces("application/json")]
public class TodoController(ITodoService todoService) : ControllerBase
{
    /// <summary>Creates a new TODO item.</summary>
    /// <param name="request">The TODO item to create.</param>
    /// <returns>The newly created TODO item.</returns>
    /// <response code="201">TODO item created successfully.</response>
    /// <response code="400">Request body is invalid or text is empty.</response>
    [HttpPost]
    [ProducesResponseType<TodoItem>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<TodoItem> Create([FromBody] CreateTodoRequest request)
    {
        var item = todoService.Create(request.Text);
        return CreatedAtAction(nameof(Create), new { id = item.Id }, item);
    }
}
