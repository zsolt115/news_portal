using news_portal.Models;
using news_portal.Services;
using Microsoft.AspNetCore.Mvc;

namespace news_portal.Controllers;

//  this controller handles requests to https://localhost:{PORT}/Category

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase {
    public CategoryController() {}

    // a client can get all Categories from the API
    [HttpGet]
    public ActionResult<List<Category>> GetAll() => CategoryService.GetAll();
    
    [HttpGet("{id}")]
    public ActionResult<Category> Get(int id) {
        var category = CategoryService.Get(id);
        if (category == null) {
            return NotFound();
        }

        return category;
    }
}