using System;
using System.Collections.Generic;
using AllSpice.Data;
using AllSpice.Models;

namespace AllSpice.Services
{
    public class IngredientsService
    {
      private readonly IngredientsRepository _ir;
      private readonly RecipesService _rs;

    public IngredientsService(IngredientsRepository ir, RecipesService rs)
    {
      _ir = ir;
      _rs = rs;
    }
    public Ingredient CreateIngredient(Ingredient ingredient)
    {
      int id = _ir.CreateIngredient(ingredient);
      ingredient.Id = id;
      return ingredient;
    }
    public List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
      return _ir.GetIngredients(recipeId);
    }
    public Ingredient GetOne(int id)
    {
      return _ir.GetOne(id);
    }
    public Ingredient UpdateIngredient(int id, Ingredient ingredient)
    {
      Ingredient original = GetOne(id);
      ingredient.Id = id;
      ingredient.RecipeId = original.RecipeId;
      ingredient.Body = ingredient.Body != null ? ingredient.Body : original.Body;
      int updated = _ir.UpdateIngredient(ingredient);
      if(updated > 0){
        return ingredient;
      }
      else
      {
        throw new Exception("Could Not Update."); 
      }
    }
    internal string DeleteIngredient(int id)
    {
      int updated = _ir.DeleteIngredient(id);
      if(updated > 0)
      {
        return "Successfully Deleted.";
      }
      else
      {
        throw new Exception("Could Not Delete.");
      }
    }
  }
}