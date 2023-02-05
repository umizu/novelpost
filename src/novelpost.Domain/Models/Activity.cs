namespace novelpost.Domain.Models;

public class Activity
{
    public Guid Id { get; set; }
    public string Verb { get; set; } = default!;
    public DateTime Date { get; set; }
    public string Unit { get; set; } = default!;
    public int? Start { get; set; }
    public int End { get; set; }
    public Guid BookId { get; set; }
}
