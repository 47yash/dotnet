using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using students.Models;
using BLL;
using BOL;
using System.ComponentModel;
using System.Collections.Generic;


namespace students.Controllers;

public class StudentController : Controller
{
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    

    public IActionResult AllStudents()
    {
        StudentManager sm=new StudentManager();
        List<Student> slist=sm.GetStudent();
        ViewData["Students"]=slist;
        return View();
    }

    [HttpGet]
    public IActionResult InsertStudent()

    {
        return View();
    }
    [HttpPost]
    public IActionResult InsertStudent(int id,string nm,int roll)
    {
        StudentManager sm=new StudentManager();
        sm.InsertStudent(id,nm,roll);
        return View();
    }
    [HttpGet]
    public IActionResult UpdateStudent()
    {
        
        return View();
    }
    [HttpPost]
    public IActionResult UpdateStudent(int id,string name,int roll)
    {
        StudentManager sm=new StudentManager();
        sm.UpdateStudent(id,name,roll);
        
        return View();
    }


    [HttpGet]
    public IActionResult DeleteStudent()
    {
        return View();
    }
    [HttpPost]
    public IActionResult DeleteStudent(int nm)
    {
       StudentManager sm=new StudentManager();
       sm.DeleteStudent(nm);
        return View();
    }

    

    
}