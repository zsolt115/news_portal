using news_portal.Models;
using news_portal.Services;
using Microsoft.AspNetCore.Mvc;

namespace news_portal.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase {
    public ArticleController() {}

    [HttpGet]
    public ActionResult<List<Article>> GetAll() => ArticleService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Article> Get(int id) {
        var article = ArticleService.Get(id);
        if (article == null) {
            return NotFound();
        }

        return article;
    }

    [HttpPost]
    public IActionResult Create(Article article) {
        ArticleService.Add(article);

        return CreatedAtAction(nameof(Create), new { id = article.Id }, article);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Article article) {
        if (id != article.Id) {
            return BadRequest();
        }

        var findArticle = ArticleService.Get(id);
        if (findArticle is null) {
            return NotFound();
        }

        ArticleService.Update(article);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        var article = ArticleService.Get(id);
        if (article is null) {
            return NotFound();
        }

        ArticleService.Delete(id);

        return NoContent();
    }
}