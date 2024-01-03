using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using first.Models;

namespace first.Controllers;

public class ArticleController : Controller
{
    private readonly ILogger<ArticleController> _logger;

    public ArticleController(ILogger<ArticleController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

  public IActionResult Articles()
    {
        Console.WriteLine("ArticleController");
        return View();
    }

    [HttpPost]
    public IActionResult Articles(int id, string name, string author)
    {
        return View();
    }



  public IActionResult AllArticles()
    {
        Console.WriteLine("ArticleController");
        return View();
    }

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}