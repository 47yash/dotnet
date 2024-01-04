using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using first.Models;
using BOL;
using BLL;
using System.Collections.Generic;

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

  public IActionResult AllArticle()
    {
        Console.WriteLine("ArticleController");
        ArticleManager am=new ArticleManager();
        List<Article> alist = am.GetAllArticles();
        ViewData["Articles"] = alist;
        return View();
    }

    // [HttpPost]
    // public IActionResult Articles()
    // {
        

    //     return View();
    // }

    


    [HttpGet]
  public IActionResult Articles()
    {
        
        return View();
    }
    
    [HttpPost]
    public IActionResult Articles(int id,string nm,string author)
    {
        // Console.WriteLine(id+nm+author);
        ArticleManager am=new ArticleManager();
        
        bool flag=am.InsertArticles(id,nm,author);

        return View();
        
    }
    [HttpGet]

     public IActionResult UpdateArticle()
    {
        
        return View();
    }
    
    [HttpPost]
    public IActionResult UpdateArticle(int id,string nm,string author)
    {
        // Console.WriteLine(id+nm+author);
        ArticleManager am=new ArticleManager();
        
        bool flag=am.UpdateArticle(id,nm,author);

        return View();
        
    }


    [HttpGet]
     public IActionResult Delete()
    {
        
        return View();
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        // Console.WriteLine(id+nm+author);
        ArticleManager am=new ArticleManager();
        
        bool flag=am.DeleteArticle(id);

        return View();
        
    }

}