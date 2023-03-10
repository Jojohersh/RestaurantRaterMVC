
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class RatingService : IRatingService
{
    private readonly RestaurantDbContext _context;
    public RatingService(RestaurantDbContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateRating(RatingCreate model)
    {
        var newRating = new Rating
        {
            RestaurantId = model.RestaurantId,
            FoodScore = model.FoodScore,
            CleanlinessScore = model.CleanlinessScore,
            AtmosphereScore = model.AtmosphereScore
        };
        _context.Ratings.Add(newRating);
        return await _context.SaveChangesAsync() == 1;
    }
    public async Task<List<RatingListItem>> GetAllRatings()
    {
        var ratings = await _context.Ratings
            .Select(r => new RatingListItem
            {
                RestaurantName = r.Restaurant.Name,
                FoodScore = r.FoodScore,
                CleanlinessScore = r.CleanlinessScore,
                AtmosphereScore = r.AtmosphereScore
            }).ToListAsync();
        return ratings;
    }

    public async Task<IEnumerable<SelectListItem>> GetAllAvailableRestaurants()
    {
        IEnumerable<SelectListItem> availableRestaurants = await _context.Restaurants.Select(r => new SelectListItem() {
            Text = r.Name,
            Value = r.Id.ToString()
        }).ToListAsync();
        return availableRestaurants;
    }
    public async Task<List<RatingListItem>> GetAllRatingsByRestaurantId(int restaurantId)
    {
        var ratings = await _context.Ratings
            .Where(r => r.RestaurantId == restaurantId)
            .Include(r => r.Restaurant)
            .Select(r => new RatingListItem
            {
                RestaurantName = r.Restaurant.Name,
                FoodScore = r.FoodScore,
                CleanlinessScore = r.CleanlinessScore,
                AtmosphereScore = r.AtmosphereScore
            })
            .ToListAsync();
        return ratings;
    }
}
