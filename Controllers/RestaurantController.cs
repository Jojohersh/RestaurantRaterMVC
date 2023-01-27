
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
    
    [ActionName("Details")]
    public async Task<IActionResult> Restaurant(int id)
    {
        RestaurantDetail restaurant = await _restaurantService.GetRestaurantById(id);
        if (restaurant is null)
            return RedirectToAction(nameof(Index));
        return View(restaurant);
    }

    public async Task<IActionResult> Edit(int id)
    {
        if (!ModelState.IsValid)
            return View(ModelState);
        var restaurant = await _restaurantService.GetRestaurantById(id);
        if (restaurant is null)
            return RedirectToAction(nameof(Index));
        
        RestaurantEdit restaurantEdit = new RestaurantEdit {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Location = restaurant.Location
        };
        return View(restaurantEdit);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(RestaurantEdit model)
    {
        if (!ModelState.IsValid)
            return View(ModelState);
        
        var restaurant = await _restaurantService.GetRestaurantById(model.Id);
        if (restaurant is null)
            return RedirectToAction(nameof(Index));
        
        var updatedSuccess = await _restaurantService.UpdateRestaurant(model);
        if (!updatedSuccess)
            return RedirectToAction(nameof(Index));
        
        return RedirectToAction("Details", new { id = restaurant.Id});
    }

    public async Task<IActionResult> Delete(int id)
    {
        var restaurant = await _restaurantService.GetRestaurantById(id);
        if (restaurant == null)
            return RedirectToAction(nameof(Index));
        
        return View(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(RestaurantDetail model)
    {
        var restaurant = await _restaurantService.GetRestaurantById(model.Id);
        if (restaurant is null)
            return RedirectToAction(nameof(Index));
        
        var deleteSuccessful = await _restaurantService.DeleteRestaurant(model.Id);
        
        return RedirectToAction(nameof(Index));
    }
}
