using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_EFCore_Codefirst.Controllers
{
    public class ProductsController : Controller
    {

        private readonly Services.IShopDbServices<Models.Product> shopDbService;

        public ProductsController(Services.IShopDbServices<Models.Product> _shopDbService)
        {
            shopDbService = _shopDbService;
        }

        // GET: ProductsController
        public async Task<ActionResult> Index()
        {
            var products = await shopDbService.GetAllAsync();
            return View(products);
        }

        // GET: ProductsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var product = await shopDbService.GetByIdAsync(id);
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(Models.Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = Guid.NewGuid();
                await shopDbService.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: ProductsController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var product = await shopDbService.GetByIdAsync(id);
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Models.Product product)
        {
            if (ModelState.IsValid)
            {
                await shopDbService.UpdateAsync(product);
                return RedirectToAction(nameof(Details), new { id = product.Id });

            }

            return View();
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var product = await shopDbService.GetByIdAsync(id);
            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Models.Product product)
        {
            if (ModelState.IsValid)
            {
                await shopDbService.DeleteAsync(product);
                return RedirectToAction(nameof(Index));

            }

            return View();
        }
    }
}
