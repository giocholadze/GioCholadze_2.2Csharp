namespace SportsWebsite.Models
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Excerpt { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public int ViewCount { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsArchived { get; set; } = false;
    }

    public class MatchFixture
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; } = string.Empty;
        public string AwayTeam { get; set; } = string.Empty;
        public DateTime MatchDate { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string MatchType { get; set; } = string.Empty;
        public string Status { get; set; } = "Upcoming";
    }

    public class ViewCountRequest
    {
        public int Id { get; set; }
        public int CurrentCount { get; set; }
    }
}