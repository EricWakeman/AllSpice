using System;
using System.ComponentModel.DataAnnotations;

namespace AllSpice.Models
{
    public class Recipe
    {
      public int Id { get; set; }
      [Required]
      public string Title { get; set; }
      public string Body { get; set; }
      public string ImgUrl { get; set; }
      public DateTime CreatedAt {get;set;}
      public DateTime UpdatedAt {get;set;}
    }
}