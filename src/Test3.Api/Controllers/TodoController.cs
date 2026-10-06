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

    /// <summary>Updates the text of an existing TODO item.</summary>
    /// <param name="id">The ID of the TODO item to update.</param>
    /// <param name="request">The updated content.</param>
    /// <returns>The updated TODO item.</returns>
    /// <response code="200">TODO item updated successfully.</response>
    /// <response code="400">Request body is invalid or text is empty.</response>
    /// <response code="404">No TODO item found with the given ID.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType<TodoItem>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<TodoItem> Update(Guid id, [FromBody] UpdateTodoRequest request)
    {
        var item = todoService.Update(id, request.Text);
        return Ok(item);
    }
}
