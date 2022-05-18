using news_portal.Models;

namespace news_portal.Services;

public static class CategoryService {
    static List<Category> Categories { get; }
    static int nextId = 5;
    static CategoryService() {
        Categories = new List<Category> {
            new Category { Id = 1, Name = "Fitness", CreatedDateTime = "2022-05-17" },
            new Category { Id = 2, Name = "Gaming", CreatedDateTime = "2022-05-17" },
            new Category { Id = 3, Name = "Food", CreatedDateTime = "2022-05-17" },
            new Category { Id = 4, Name = "Creativity", CreatedDateTime = "2022-05-17" }
        };
    }

    public static List<Category> GetAll() => Categories;

    public static Category? Get(int id) => Categories.FirstOrDefault(cat => cat.Id == id);

    public static void Add(Category category) {
        category.Id = nextId++;

        Categories.Add(category);
    }

    public static void Delete(int id) {
        var category = Get(id);
        if (category is null) {
            return;
        }

        Categories.Remove(category);
    }

    public static void Update(Category category) {
        var index = Categories.FindIndex(cat => cat.Id == cat.Id);
        if (index == -1) {
            return;
        }

        Categories[index] = category;
    }
}