using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Data
{
    public class IngredientsRepository
    {
      private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<Ingredient> GetIngredients(int recipeId)
    {
      var sql = "SELECT * FROM ingredients WHERE recipeId = @recipeId;";
      return _db.Query<Ingredient>(sql, new{recipeId}).ToList();
    }
    internal int CreateIngredient(Ingredient ingredient)
    {
      var sql = "INSERT INTO ingredients (body) VALUES (@Body); SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, ingredient);
    }

    internal Ingredient GetOne(int id)
    {
      throw new System.NotImplementedException();
    }

    internal int UpdateIngredient(Ingredient ingredient)
    {
      var sql = "UPDATE ingredients SET body = @Body WHERE id = @Id;";
      return _db.Execute(sql, ingredient);
    }
    internal int DeleteIngredient(int id)
    {
      var sql = "DELETE FROM ingredients WHERE id = @Id;";
      return _db.Execute(sql, new {id});
    }
  }

}