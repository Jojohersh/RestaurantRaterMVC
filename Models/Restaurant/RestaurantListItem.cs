
using System.ComponentModel.DataAnnotations;

public class RestaurantListItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    [Display(Name = "Average Score")]
    public double Score { get; set; }
}
