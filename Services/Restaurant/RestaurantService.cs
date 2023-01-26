
using Microsoft.EntityFrameworkCore;

public class RestaurantService : IRestaurantService
{
    private readonly RestaurantDbContext _context;
    public RestaurantService(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateRestaurant(RestaurantCreate model)
    {
        Restaurant restaurant = new Restaurant {
            Name = model.Name,
            Location = model.Location
        };
        _context.Restaurants.Add(restaurant);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<List<RestaurantListItem>> GetAllRestaurants()
    {
        List<RestaurantListItem> restaurants = await _context.Restaurants
        .Include(restaurant => restaurant.Ratings)
        .Select(r => new RestaurantListItem
        {
            Id = r.Id,
            Name = r.Name,
            Score = r.Score
        }).ToListAsync();

        return restaurants;
    }
}
