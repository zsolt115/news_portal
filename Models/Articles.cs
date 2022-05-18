namespace news_portal.Models;

public class Article {
    public int Id { get; set; }
    public string? Title { get; set; }

    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public string? CreatedDateTime { get; set; }
}