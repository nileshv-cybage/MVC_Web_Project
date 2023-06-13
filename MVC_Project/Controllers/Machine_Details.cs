using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MVC_Project.Controllers
{
    public class Machine_Details : Controller
    {
        private readonly HttpClient _httpClient;

        public Machine_Details(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7227/api/Machine");
                var resultString = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(resultString);
                return View(result);
            }
            catch (Exception ex)
            {
                // Handle the exception here
                // You can log the exception details, display a user-friendly error message, or take appropriate action
                Console.WriteLine($"An exception occurred: {ex.Message}");
                // Optionally, you can return an error view or redirect to an error page
                return View("Error");
            }
        }
        








    }
}
