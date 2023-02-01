
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class RatingController : Controller
{
    private readonly IRatingService _RatingService;
    private readonly IRestaurantService _RestaurantService;
        public RatingController(IRatingService ratingService, IRestaurantService restaurantService)
    {
        _RatingService = ratingService;
        _RestaurantService = restaurantService;
    }
    
    public async Task<IActionResult> Create()
    {
        IEnumerable<SelectListItem> restaurantOptions = await _RatingService.GetAllAvailableRestaurants();
        RatingCreate model = new RatingCreate();
        model.RestaurantOptions = restaurantOptions;
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Create(RatingCreate model)
    {
        model.RestaurantOptions = await _RatingService.GetAllAvailableRestaurants();
        if (!ModelState.IsValid)
            return View(model);
        var creationSuccess = await _RatingService.CreateRating(model);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Index()
    {
        var ratings = await _RatingService.GetAllRatings();
        return View(ratings);
    }

    public async Task<IActionResult> Restaurant(int id)
    {
        var ratings = await _RatingService.GetAllRatingsByRestaurantId(id);
        var restaurant = await _RestaurantService.GetRestaurantById(id);
        ViewBag.RestaurantName = restaurant.Name;
        return View(ratings);
    }
}
