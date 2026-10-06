namespace Test3.Api.Models;

/// <summary>A single TODO item.</summary>
public record TodoItem(Guid Id, string Text, DateTime CreatedAt);
