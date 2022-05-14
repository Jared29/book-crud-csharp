namespace BookApi.Models;

public class Book {
    public int Id { get; set; }
    public string? Title {get; set; }
    public string? Author {get; set; }
    public string? Start {get; set; }
    public string? Finish {get; set; }
    public int? Chapters {get; set; }
}