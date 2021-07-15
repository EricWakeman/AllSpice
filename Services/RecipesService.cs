using System;
using System.Collections.Generic;
using AllSpice.Data;
using AllSpice.Models;

namespace AllSpice.Services
{
    public class RecipesService
    {
      private readonly RecipesRepository _rs;

    public RecipesService(RecipesRepository rs)
    {
      _rs = rs;
    }
    public List<Recipe> GetAllRecipes()
    {
      var recipes = _rs.GetAllRecipes();
      return recipes;
    }
    public Recipe CreateRecipe(Recipe recipeData)
    {
      var recipe = _rs.CreateRecipe(recipeData);
      return recipe;
    }

    public Recipe GetOne(int id)
    {
      return _rs.GetOne(id);
    }
    internal Recipe UpdateRecipe(int id, Recipe recipe)
    {
      recipe.Id = id;
      Recipe original = GetOne(id);
      recipe.Title = recipe.Title != null ? recipe.Title : original.Title; 
      recipe.Body = recipe.Body != null ? recipe.Body : original.Body; 
      recipe.ImgUrl = recipe.ImgUrl != null ? recipe.ImgUrl : original.ImgUrl; 

      int updated = _rs.UpdateRecipe(recipe);
      if(updated > 0)
      {
        return recipe;
      }
      else
      {
        throw new Exception("Could Not Update.");
      }
    }

    public Recipe GetRecipeById(int id)
    {
      return _rs.GetOne(id);
    }

    internal string DeleteRecipe(int id)
    {
      int updated = _rs.DeleteRecipe(id);
      if(updated > 0)
      {
        return "Its Dead Jim!!!";
      }
      else
      {
        throw new Exception("Could Not Delete.");
      }
    }
  }
}