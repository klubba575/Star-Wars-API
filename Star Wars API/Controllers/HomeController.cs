using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Star_Wars_API.Models;

namespace Star_Wars_API.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public async Task<IActionResult> GetPersonById(int Id)
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri("https://swapi.co/api/");

			var response = await client.GetAsync($"people/?search={Id}/");
			var person = await response.Content.ReadAsAsync<StarWarsPeople>();

			return View(person);
		}
		public async Task<IActionResult> GetPlanetById(int Id)
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri("https://swapi.co/api/");

			var response = await client.GetAsync($"planets/?search={Id}/");
			var planet = await response.Content.ReadAsAsync<StarWarsPlanets>();
			return View(planet);
		}
		public IActionResult Results(StarWarsPeople person, StarWarsPlanets planet)
		{
			return View();
		}

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
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
