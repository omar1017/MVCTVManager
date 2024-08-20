using Microsoft.AspNetCore.Mvc;
using MVCTVManagerProject.Models;
using System.Diagnostics;
using TVManager_Domain;
using TVManager_Infrastructre.Interfaces;

namespace MVCTVManagerProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IRepository<TVShow> repository;

        public HomeController(ILogger<HomeController> logger,IRepository<TVShow> repository)
        {
            this.repository = repository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var TvShows = await repository.GetAllAsync();
            return View(TvShows);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
