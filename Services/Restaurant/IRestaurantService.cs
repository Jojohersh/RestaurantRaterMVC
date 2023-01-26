
public interface IRestaurantService
{
    Task<bool> CreateRestaurant(RestaurantCreate model);
    Task<List<RestaurantListItem>> GetAllRestaurants();
    Task<RestaurantDetail> GetRestaurantById(int Id);
    // Task<bool> UpdateRestaurant(RestaurantEdit model);
    // Task<bool> DeleteRestaurant(int Id);
}
