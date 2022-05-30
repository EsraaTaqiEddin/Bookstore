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
    public class CountryController : Controller
    {
        ICountryService cService;
        public CountryController(ICountryService _cService)
        {
            cService = _cService;

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            VmCountry vm = new VmCountry();
            vm.LiCountries = cService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Country", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Save(VmCountry Vm)
        {
            cService.Insert(Vm.country);
            VmCountry vm = new VmCountry();
            vm.LiCountries = cService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Country", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult EditCountry(int CountryID)
        {
            Countries country = new Countries();
            country = cService.LoadCountryByID(CountryID);
            return Json(country);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(VmCountry Vm)
        {
            cService.Update(Vm.country);
            VmCountry vm = new VmCountry();
            vm.LiCountries = cService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Country", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCountry(int CountryID)
        {
            cService.DeleteItem(CountryID);
            VmCountry vm = new VmCountry();
            vm.LiCountries = cService.LoadAll();
            ViewData["isEditing"] = false;
            return View("Country", vm);
        }
    }
}
