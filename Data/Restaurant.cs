
using System.ComponentModel.DataAnnotations;

public class Restaurant
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(100)]
    public string Location { get; set; }

    public virtual List<Rating> Ratings { get; set; }

    public double AverageFoodScore
    {
        get
        {
            return Ratings.Count > 0
            ?Ratings.Select(r => r.FoodScore).Sum() / Ratings.Count
            : 0;
        }
    }
    public double AverageCleanlinessScore
    {
        get
        {
            return Ratings.Count > 0 
            ? Ratings.Select(r => r.CleanlinessScore).Sum() / Ratings.Count
            : 0;
        }
    }
    public double AverageAtmosphereScore
    {
        get
        {
            return Ratings.Count > 0
            ?Ratings.Select(r=>r.CleanlinessScore).Sum() / Ratings.Count
            : 0;
        }
    }
    public double Score
    {
        get
        {
            return (AverageFoodScore + AverageCleanlinessScore + AverageAtmosphereScore) / 3;
        }
    }
}