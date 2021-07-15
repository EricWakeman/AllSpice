using System;
using System.ComponentModel.DataAnnotations;

namespace AllSpice.Models
{
    public class Ingredient
    {
      public int Id { get; set; }
      [Required]
      public int RecipeId { get; set; }
      [Required]
      public string Body { get; set; }
      public DateTime CreatedAt {get;set;}
      public DateTime UpdatedAt {get;set;}
    }
}