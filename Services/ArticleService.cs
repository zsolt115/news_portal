using news_portal.Models;

namespace news_portal.Services;

public static class ArticleService {
    static List<Article> Articles { get; }

    static int nextId = 6;

    static ArticleService() {
        Articles = new List<Article> {
            new Article { Id = 1, Title = "Powerlifting", Description = "strength focus, 3 lift", CategoryId = 1, CreatedDateTime = "2022-05-17" },
            new Article { Id = 2, Title = "Bodybuilding", Description = "body and muscle size focus", CategoryId = 1, CreatedDateTime = "2022-05-17" },
            new Article { Id = 3, Title = "Strongman", Description = "strength focus, lifting barbells/dumbbells & lifting objects like Atlas stones, tires, and even trucks", CategoryId = 1, CreatedDateTime = "2022-05-17" },
            new Article { Id = 4, Title = "Weightlifting", Description = "strength focus, clean&jerk + snatch", CategoryId = 1, CreatedDateTime = "2022-05-17" },
            new Article { Id = 5, Title = "League of Legends", Description = "moba", CategoryId = 2, CreatedDateTime = "2022-05-17" }
        };
    }

    public static List<Article> GetAll() => Articles;

    public static Article? Get(int id) => Articles.FirstOrDefault(a => a.Id == id);

    public static void Add(Article article) {
        article.Id = nextId++;

        Articles.Add(article);
    }

    public static void Delete(int id) {
        var article = Get(id);

        if (article is null) {
            return;
        }

        Articles.Remove(article);
    }

    public static void Update(Article article) {
        var index = Articles.FindIndex(a => a.Id == article.Id);
        if (index == -1)
            return;
            
        Articles[index] = article;
    }
}