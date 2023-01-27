
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

    public async Task<RestaurantDetail> GetRestaurantById(int id)
    {
        var restaurant = await _context.Restaurants
            .Include(r => r.Ratings)
            .FirstOrDefaultAsync(r => r.Id == id);
        
        if (restaurant is null)
            return null;
            
        return new RestaurantDetail {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Location = restaurant.Location,
            Score = restaurant.Score
        };
    }

    public async Task<bool> UpdateRestaurant(RestaurantEdit model)
    {
        var restaurant = await _context.Restaurants.FindAsync(model.Id);
        if (restaurant is null)
            return false;
        
        restaurant.Name = model.Name;
        restaurant.Location = model.Location;
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> DeleteRestaurant(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);

        if (restaurant is null)
            return false;
        
        _context.Restaurants.Remove(restaurant);
        return await _context.SaveChangesAsync() > 0;
    }
}
