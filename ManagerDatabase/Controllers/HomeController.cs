using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ManagerDatabase.Models;

using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ManagerDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment _appEnvironment;
        ApplicationContext _context;
      
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment appEnvironment, ApplicationContext context)
        {
            _logger = logger;
            _appEnvironment = appEnvironment;
            _context = context;
          
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult GetAll()
        {
            return View(_context.Managers.ToList());
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

        [HttpPost]
        public IActionResult Index(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                try
                {
                    string fileExtension = Path.GetExtension(uploadedFile.FileName);

                    //Validate uploaded file and return error.
                    if (fileExtension != ".csv")
                    {
                        ViewBag.Message = "Please select the csv file with .csv extension";
                        return View();
                    }


                    var employees = new List<Manager>();
                    using (var sreader = new StreamReader(uploadedFile.OpenReadStream()))
                    {
                        //First line is header. If header is not passed in csv then we can neglect the below line.
                        string[] headers = sreader.ReadLine().Split(',');
                        //Loop through the records
                        while (!sreader.EndOfStream)
                        {
                            string[] rows = sreader.ReadLine().Split(',');

                            employees.Add(new Manager
                            {
                               
                                Name = rows[0].ToString(),
                                DateOfBirth = DateTime.Parse(rows[1]),
                                Married = bool.Parse(rows[2]),
                                Phone = rows[3].ToString(),
                                Salary = decimal.Parse(rows[4].ToString())
                            });
                        }
                    }
                    _context.Managers.AddRange(employees);
                    _context.SaveChanges();


                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }
            }
            else
            {
                ViewBag.Message = "Please select the file first to upload.";
            }
            return RedirectToAction("GetAll");
        }

        public IActionResult Edite(int? id)
        {
            if (id != null)
            {
                Manager user =  _context.Managers.FirstOrDefault(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edite(Manager user)
        {
            _context.Managers.Update(user);
            _context.SaveChanges();
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Manager user = _context.Managers.FirstOrDefault(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Manager user = _context.Managers.FirstOrDefault(p => p.Id == id);
                if (user != null)
                {
                    _context.Managers.Remove(user);
                    _context.SaveChanges();
                    return RedirectToAction("GetAll");
                }
            }
            return NotFound();
        }
    }
}

    