using System.ComponentModel.DataAnnotations;

namespace Test3.Api.Models;

/// <summary>Request body for creating a TODO item.</summary>
public record CreateTodoRequest
{
    /// <summary>The text content of the TODO item.</summary>
    [Required]
    [MinLength(1)]
    public required string Text { get; init; }
}
