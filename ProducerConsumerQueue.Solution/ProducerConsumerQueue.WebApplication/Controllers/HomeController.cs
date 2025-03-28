// ProducerConsumerQueue.WebApplication.Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;
using ProducerConsumerQueue.WebApplication.Services;
using System;

namespace ProducerConsumerQueue.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProducerConsumerService _producerConsumerService;

        public HomeController(IProducerConsumerService producerConsumerService)
        {
            _producerConsumerService = producerConsumerService;
        }

        public IActionResult Index()
        {
            _producerConsumerService.StartProducer();
            _producerConsumerService.StartConsumer();

            var results = (_producerConsumerService as ProducerConsumerService).Results;
            return View(results);
        }

        public IActionResult GetResults()
        {
            var results = (_producerConsumerService as ProducerConsumerService).Results;
            Console.WriteLine("Returning results: " + string.Join(", ", results)); // Debug: Log the results being returned
            return Json(results);
        }

    }
}
