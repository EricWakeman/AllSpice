using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Data
{
    public class RecipesRepository
    {
      private readonly IDbConnection _db;
    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<Recipe> GetAllRecipes()
    {
      var sql = @"SELECT * FROM recipes;";
      return _db.Query<Recipe>(sql).ToList();
    }
    public Recipe CreateRecipe(Recipe recipeData)
    {
      var sql = @"INSERT INTO recipes(title, body, imgUrl) VALUES (@Title, @Body, @ImgUrl);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, recipeData);
      recipeData.Id = id;
      return recipeData;
      
    }

    internal Recipe GetOne(int id)
    {
      string sql = "SELECT * FROM recipes WHERE id = @id;";
      return _db.QueryFirstOrDefault<Recipe>(sql, new{id});
    }

    internal int UpdateRecipe(Recipe recipe)
    {
      string sql = @"UPDATE recipes SET title = @Title, body = @Body, imgUrl = @ImgUrl WHERE id = @id;";
      return _db.Execute(sql, recipe);
    }
    internal int DeleteRecipe(int id)
    {
      string sql = @"DELETE FROM recipes WHERE id = @id;";
      return _db.Execute(sql, new {id});
    }
  }
}