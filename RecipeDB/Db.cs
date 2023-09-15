using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDB
{
    public class Db
    {
        private IMongoDatabase GetDb()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MyRDB");
            return db;
        }
        public async Task SaveRecipe(Recipe recipe)
        {
            await GetDb().GetCollection<Recipe>("Recipes")
             .InsertOneAsync(recipe);
        }
        public async Task<List<Recipe>> GetRecipes()
        {
            var recipes = await GetDb().GetCollection<Recipe>("Recipes")
                .Find(r => true)
                .ToListAsync();  
            return recipes;
        }

        public async Task<Recipe> GetRecipeById(string id)
        {
            ObjectId _id = new ObjectId(id);
            var recipe = await GetDb().GetCollection<Recipe>("Recipes")
                .Find(r => r.Id == _id)
                 .SingleOrDefaultAsync();
            return recipe;
        }

       
    }
}
