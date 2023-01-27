
using Microsoft.AspNetCore.Mvc;

public class RatingController : Controller
{
    private readonly IRatingService _RatingService;
        public RatingController(IRatingService ratingService)
    {
        _RatingService = ratingService;
    }
    
    public async Task<IActionResult> Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(RatingCreate model)
    {
        if (!ModelState.IsValid)
            return View();
        
        var creationSuccess = await _RatingService.CreateRating(model);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Index()
    {
        var ratings = await _RatingService.GetAllRatings();
        return View(ratings);
    }
}
