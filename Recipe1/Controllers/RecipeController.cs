using Microsoft.AspNetCore.Mvc;
using RecipeDB;

namespace Recipe1.Controllers
{
    public class RecipeController : Controller
    {
        public async Task<IActionResult> Index()
        {
           RecipeDB.Db db  = new RecipeDB.Db();
           List<Recipe> recipes = await db.GetRecipes();


            return View(recipes);
        }

        public async Task<IActionResult> Details(string id)
        {
          RecipeDB.Db db = new RecipeDB.Db();
            var recipe = await db.GetRecipeById(id);
            return View(recipe);
        }


    }
}
