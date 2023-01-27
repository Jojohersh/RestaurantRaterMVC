
using System.ComponentModel.DataAnnotations;

public class RatingListItem
{
    [Display(Name = "Restaurant")]
    public string RestaurantName { get; set; }
    [Display(Name = "Food Rating")]
    public double FoodScore { get; set; }
    [Display(Name = "Cleanliness Rating")]
    public double CleanlinessScore { get; set; }
    [Display(Name = "Atmosphere Rating")]
    public double AtmosphereScore { get; set; }
}
