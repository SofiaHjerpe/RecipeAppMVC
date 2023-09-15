
using RecipeDB;

Console.WriteLine("Welcome to RecipeBuild");
Console.Write("Title: ");
string title = Console.ReadLine();

Console.Write("Summary: ");
string summary = Console.ReadLine();

Console.Write("Image: ");
string image = Console.ReadLine();

Console.Write("Minutes: ");
string input = Console.ReadLine();
int minutes = int.Parse(input);

Recipe recipe = new Recipe()
{
    Title = title,
    Summary = summary,
    Image = image,
    Minutes = minutes
} ; 
Db db = new Db();
await db.SaveRecipe(recipe);

var recipes = await db.GetRecipes();

foreach (var r in recipes)
{
    Console.WriteLine(r.Title);
}
