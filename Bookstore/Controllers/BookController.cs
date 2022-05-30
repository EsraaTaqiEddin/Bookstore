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
    public class BookController : Controller
    {
        ICategoryService cService;
        IBookService bService;
        IAuthorService aService;
        public BookController(IBookService _bService, IAuthorService _aService, ICategoryService _cService)
        {
            cService = _cService;
            bService = _bService;
            aService = _aService;

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            VmBooks vm = new VmBooks();
            vm.LiAuthors = aService.LoadAll();
            vm.LiCategories = cService.LoadAll();
            vm.LiBooks = bService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Books", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Save(VmBooks Vm)
        {
            if (Vm.book.Image == null) { }
            else
            {
                string name = Guid.NewGuid().ToString() + "." + Vm.book.Image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
                Vm.book.Image.CopyTo(new FileStream(path, FileMode.Create));
                Vm.book.ImagePath = "http://localhost/Bookstore/StaticPath/" + name;
            }
           
                bService.Insert(Vm.book);
           
            VmBooks vm = new VmBooks();
            vm.LiAuthors = aService.LoadAll();
            vm.LiCategories = cService.LoadAll();
            vm.LiBooks = bService.LoadAll();
            ViewData["isEditing"] = false;

            
            return View("Books", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult EditBook(int BookID)
        {
            Books book = new Books();
            book = bService.LoadBookByID(BookID);
            return Json(book);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(VmBooks Vm)
        {
            if (Vm.book.Image == null) { }
            else
            {
                string name = Guid.NewGuid().ToString() + "." + Vm.book.Image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
                Vm.book.Image.CopyTo(new FileStream(path, FileMode.Create));
                Vm.book.ImagePath = "http://localhost/Bookstore/StaticPath/" + name;
            }

            
                bService.Update(Vm.book);
            
           
            VmBooks vm = new VmBooks();
            vm.LiAuthors = aService.LoadAll();
            vm.LiCategories = cService.LoadAll();
            vm.LiBooks = bService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Books", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBook(int BookID)
        {
            bService.DeleteItem(BookID);
            VmBooks vm = new VmBooks();
            vm.LiAuthors = aService.LoadAll();
            vm.LiCategories = cService.LoadAll();
            vm.LiBooks = bService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Books", vm);
        }
        
    }
}
