using Microsoft.AspNetCore.Mvc.Rendering;

public interface IRatingService
    {
        Task<bool> CreateRating(RatingCreate model);
        Task<List<RatingListItem>> GetAllRatings();
        Task<IEnumerable<SelectListItem>> GetAllAvailableRestaurants();
        Task<List<RatingListItem>> GetAllRatingsByRestaurantId(int id);
    }
