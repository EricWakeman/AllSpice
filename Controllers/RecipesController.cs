using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
      [ApiController]
      [Route("api/[Controller]")]
    public class RecipesController : ControllerBase
    {
      private readonly RecipesService _rs;
      private readonly IngredientsService _iServ;


    public RecipesController(RecipesService rs, IngredientsService iServ)
    {
      _rs = rs;
      _iServ = iServ;

    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetAllRecipes()
    {
      try
      {
          var recipes = _rs.GetAllRecipes();
          return Ok(recipes);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<List<Recipe>> GetRecipeById(int id)
    {
      try
      {
          var recipe = _rs.GetRecipeById(id);
          return Ok(recipe);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/ingredients")]
    public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeId)
    {
      try
      {
          return Ok(_iServ.GetIngredientsByRecipeId(recipeId));
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Recipe> CreateRecipe([FromBody] Recipe recipeData)
    {
      try
      {
          var recipe = _rs.CreateRecipe(recipeData);
          return Created($"api/recipes/{recipe.Id}", recipe);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Recipe> UpdateRecipe(int id, [FromBody] Recipe recipe)
    {
      try
      {
          return Ok(_rs.UpdateRecipe(id,recipe));
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Recipe> DeleteRecipe(int id)
    {
      try
      {
          return Ok(_rs.DeleteRecipe(id));
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
  }
}