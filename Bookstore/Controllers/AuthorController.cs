using Bookstore.data;
using Bookstore.Models;
using Bookstore.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class AuthorController : Controller { 

        ICountryService cService;
        IAuthorService aService;
        public AuthorController(IAuthorService _aService, ICountryService _cService)
    {
        cService = _cService;
        aService = _aService;

    }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            VmAuthors vm = new VmAuthors();
            vm.LiAuthors = aService.LoadAll();
            vm.LiCountries = cService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Authors", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Save(VmAuthors Vm)
        {
            if (Vm.author.Image == null) { }
            else
            {
                string name = Guid.NewGuid().ToString() + "." + Vm.author.Image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
                Vm.author.Image.CopyTo(new FileStream(path, FileMode.Create));
                Vm.author.ImagePath = "http://localhost/Bookstore/StaticPath/" + name;
            }
      
                aService.Insert(Vm.author);
            
            
            VmAuthors vm = new VmAuthors();
            vm.LiAuthors = aService.LoadAll();
            vm.LiCountries = cService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Authors", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult EditAuthor(int AuthorID)
        {
            Authors author = new Authors();
            author = aService.LoadAuthorByID(AuthorID);
            return Json(author);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(VmAuthors Vm)
        {
            if (Vm.author.Image == null) { }
            else
            {
                string name = Guid.NewGuid().ToString() + "." + Vm.author.Image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
                Vm.author.Image.CopyTo(new FileStream(path, FileMode.Create));
                Vm.author.ImagePath = "http://localhost/Bookstore/StaticPath/" + name;
            }

                aService.Update(Vm.author);
            
            
            VmAuthors vm = new VmAuthors();
            vm.LiAuthors = aService.LoadAll();
            vm.LiCountries = cService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Authors", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAuthor(int AuthorID)
        {
            aService.DeleteItem(AuthorID);
            VmAuthors vm = new VmAuthors();
            vm.LiAuthors = aService.LoadAll();
            vm.LiCountries = cService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Authors", vm);
        }
    }
}
