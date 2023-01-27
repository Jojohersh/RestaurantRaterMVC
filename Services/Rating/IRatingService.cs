    public interface IRatingService
    {
        Task<bool> CreateRating(RatingCreate model);
        Task<List<RatingListItem>> GetAllRatings();
        Task<List<RatingListItem>> GetAllRatingsByRestaurantId(int id);
    }
