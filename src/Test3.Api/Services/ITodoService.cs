using Test3.Api.Models;

namespace Test3.Api.Services;

/// <summary>Provides TODO item management operations.</summary>
public interface ITodoService
{
    /// <summary>Creates a new TODO item with the given text.</summary>
    /// <exception cref="ArgumentException">Thrown when <paramref name="text"/> is null, empty, or whitespace.</exception>
    TodoItem Create(string text);

    /// <summary>Updates the text of an existing TODO item.</summary>
    /// <exception cref="ArgumentException">Thrown when <paramref name="text"/> is null, empty, or whitespace.</exception>
    /// <exception cref="KeyNotFoundException">Thrown when no item with <paramref name="id"/> exists.</exception>
    TodoItem Update(Guid id, string text);
}
