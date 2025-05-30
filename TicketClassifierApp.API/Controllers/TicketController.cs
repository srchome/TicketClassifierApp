using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using TicketClassifierApp.ML.MLModels;

namespace TicketClassifierApp.API.Controllers
{
    public class TicketController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Predict(string title, string description)
        {
            var modelPath = Path.Combine(AppContext.BaseDirectory, "MLModels", "TicketCategoryModel.zip");
            var predictor = new Predictor(modelPath);
            var predictedCategory = predictor.Predict(title, description);

            ViewBag.Title = title;
            ViewBag.Description = description;
            ViewBag.Category = predictedCategory;

            return View("Result");
        }
    }
}
