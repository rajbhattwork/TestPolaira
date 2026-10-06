using System.Collections.Concurrent;
using Test3.Api.Models;

namespace Test3.Api.Services;

/// <inheritdoc />
public sealed class TodoService : ITodoService
{
    private readonly ConcurrentDictionary<Guid, TodoItem> _items = new();

    /// <inheritdoc />
    public TodoItem Create(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Todo text must not be empty or whitespace.", nameof(text));

        var item = new TodoItem(Guid.NewGuid(), text.Trim(), DateTime.UtcNow);
        _items[item.Id] = item;
        return item;
    }
}
