using Bookstore.data;
using Bookstore.Models;
using Bookstore.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService cService;
        public CategoryController(ICategoryService _cService)
        {
            cService = _cService;

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            VmCategory vm = new VmCategory();
            vm.LiCategories = cService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Category", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Save(VmCategory Vm)
        {
            cService.Insert(Vm.category);
            VmCategory vm = new VmCategory();
            vm.LiCategories = cService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Category", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult EditCategory(int CategoryID)
        {
            Categories category = new Categories();
            category = cService.LoadCategoryByID(CategoryID);
            return Json(category);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(VmCategory Vm)
        {
            cService.Update(Vm.category);
            VmCategory vm = new VmCategory();
            vm.LiCategories = cService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Category", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(int CategoryID)
        {
            cService.DeleteItem(CategoryID);
            VmCategory vm = new VmCategory();
            vm.LiCategories = cService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Category", vm);
        }
    }
}
