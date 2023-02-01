
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public class RatingCreate
{
    [Required]
    [Display(Name = "Restaurant")]
    public int RestaurantId {get; set;}
    [Required]
    [Range(1,10)]
    public double FoodScore {get; set;}
    [Required]
    [Range(1,10)]
    public double CleanlinessScore {get; set;}
    [Required]
    [Range(1,10)]
    public double AtmosphereScore {get; set;}
    public IEnumerable<SelectListItem>? RestaurantOptions {get; set;}
}
