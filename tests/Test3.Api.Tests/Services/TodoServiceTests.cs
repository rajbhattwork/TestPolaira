using Test3.Api.Services;

namespace Test3.Api.Tests.Services;

public class TodoServiceTests
{
    private readonly TodoService _sut = new();

    [Fact]
    public void Create_WithValidText_ReturnsItemWithMatchingText()
    {
        var result = _sut.Create("Buy groceries");

        Assert.Equal("Buy groceries", result.Text);
    }

    [Fact]
    public void Create_WithValidText_AssignsNonEmptyId()
    {
        var result = _sut.Create("Buy groceries");

        Assert.NotEqual(Guid.Empty, result.Id);
    }

    [Fact]
    public void Create_WithValidText_SetsCreatedAtToUtcNow()
    {
        var before = DateTime.UtcNow;
        var result = _sut.Create("Buy groceries");
        var after = DateTime.UtcNow;

        Assert.InRange(result.CreatedAt, before, after);
    }

    [Fact]
    public void Create_CalledTwice_AssignsUniqueIds()
    {
        var first = _sut.Create("Task one");
        var second = _sut.Create("Task two");

        Assert.NotEqual(first.Id, second.Id);
    }

    [Fact]
    public void Create_WithEmptyText_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _sut.Create(""));
    }

    [Fact]
    public void Create_WithWhitespaceText_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _sut.Create("   "));
    }

    [Theory]
    [InlineData("  padded  ")]
    [InlineData("\ttabbed\t")]
    public void Create_TrimsWhitespaceFromValidText(string text)
    {
        var result = _sut.Create(text);

        Assert.Equal(text.Trim(), result.Text);
    }

    [Fact]
    public void Update_WithValidText_ReturnsItemWithNewText()
    {
        var created = _sut.Create("Original");

        var result = _sut.Update(created.Id, "Updated");

        Assert.Equal("Updated", result.Text);
    }

    [Fact]
    public void Update_PreservesIdAndCreatedAt()
    {
        var created = _sut.Create("Original");

        var result = _sut.Update(created.Id, "Updated");

        Assert.Equal(created.Id, result.Id);
        Assert.Equal(created.CreatedAt, result.CreatedAt);
    }

    [Fact]
    public void Update_WithEmptyText_ThrowsArgumentException()
    {
        var created = _sut.Create("Original");

        Assert.Throws<ArgumentException>(() => _sut.Update(created.Id, ""));
    }

    [Fact]
    public void Update_WithWhitespaceText_ThrowsArgumentException()
    {
        var created = _sut.Create("Original");

        Assert.Throws<ArgumentException>(() => _sut.Update(created.Id, "   "));
    }

    [Fact]
    public void Update_WithUnknownId_ThrowsKeyNotFoundException()
    {
        Assert.Throws<KeyNotFoundException>(() => _sut.Update(Guid.NewGuid(), "Updated"));
    }

    [Theory]
    [InlineData("  padded  ")]
    [InlineData("\ttabbed\t")]
    public void Update_TrimsWhitespaceFromValidText(string text)
    {
        var created = _sut.Create("Original");

        var result = _sut.Update(created.Id, text);

        Assert.Equal(text.Trim(), result.Text);
    }
}
