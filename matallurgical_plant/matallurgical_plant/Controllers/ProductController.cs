﻿using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace matallurgical_plant.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productServices;
        private readonly AppDbContext _db;

        public ProductController(
            ILogger<HomeController> logger,
            IProductService productServices)
        {
            _productServices = productServices;

        }
        // GET: ProductController/Index
        public IActionResult Index()
        {
            var model = _productServices.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _productServices.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Product model)
        {
            _productServices.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _productServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var model = _productServices.GetById(id);

            return View("EditProduct", model);
        }

        [HttpPost]
        public IActionResult EditProduct(Product model)
        {
            _productServices.Edit(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DetailsProduct(int id)
        {
            var model = _productServices.GetById(id);

            return View("DetailsProduct", model);
        }
    }
}
