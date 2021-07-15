using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]

    public class IngredientsController : ControllerBase
    {
      private readonly IngredientsService _iServ;

    public IngredientsController(IngredientsService iServ)
    {
      _iServ = iServ;
    }
    [HttpPost]
    public ActionResult<Ingredient> CreateIngredient([FromBody] Ingredient ingredient)
    {
      try
      {
          return Ok(_iServ.CreateIngredient(ingredient));
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    
    [HttpPut("{id}")]
    public ActionResult<Ingredient> UpdateIngredient(int id, Ingredient ingredient)
    {
      try
      {
        return Ok(_iServ.UpdateIngredient(id, ingredient));
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Ingredient> DeleteIngredient(int id)
    {
      try
      {
        return Ok(_iServ.DeleteIngredient(id));
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
  }
}