
using Microsoft.AspNetCore.Mvc;

public class RestaurantController : Controller
{
    private IRestaurantService _restaurantService;
    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }
    
    public async Task<IActionResult> Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(RestaurantCreate model)
    {
        if (!ModelState.IsValid)
            return View(model);
        await _restaurantService.CreateRestaurant(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Index()
    {
        List<RestaurantListItem> restaurants = await _restaurantService.GetAllRestaurants();
        return View(restaurants);
    }
}
