using System.ComponentModel.DataAnnotations;

namespace Test3.Api.Models;

/// <summary>Request body for updating a TODO item.</summary>
public record UpdateTodoRequest
{
    /// <summary>The new text content for the TODO item.</summary>
    [Required]
    [MinLength(1)]
    public required string Text { get; init; }
}
