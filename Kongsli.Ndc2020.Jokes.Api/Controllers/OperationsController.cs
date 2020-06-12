using Microsoft.AspNetCore.Mvc;
using System;
using Antiboilerplate.Functional;
using Microsoft.Extensions.Hosting;

namespace Kongsli.Ndc2020.Jokes.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class OperationsController : ControllerBase
    {
        private readonly IHostEnvironment _hostEnvironment;

        public OperationsController(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Get() => Ok(new
        { 
            Routes = new[]
            {
                new {Path = "/jokes", Method = "GET", Description = "Neutral jokes" },
                new {Path = "/sciencejokes", Method = "GET", Description = "Science jokes" },
                new {Path = "/chuckjokes", Method = "GET", Description = "Chuck Norris jokes" },
                new {Path = "/health", Method = "GET", Description = "App health" }
            },
            Version = _hostEnvironment.ContentRootPath.Map(p => System.IO.File.ReadAllText($"{p}/version.txt")),
            Environment = Environment.GetEnvironmentVariables()
        });
    }
}