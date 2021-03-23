using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_EFCore_Codefirst.Controllers
{
    public class CustomersController : Controller
    {

        private readonly Services.IShopDbServices<Models.Customer> shopDbService;

        public CustomersController(Services.IShopDbServices<Models.Customer> _shopDbService)
        {
            shopDbService = _shopDbService;
        }

        // GET: CustomersController
        public async Task<ActionResult> Index()
        {
            var customer = await shopDbService.GetAllAsync();
            return View(customer);
        }

        // GET: CustomersController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var customer = await shopDbService.GetByIdAsync(id);
            return View(customer);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Id = Guid.NewGuid();
                await shopDbService.CreateAsync(customer);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: CustomersController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var customer = await shopDbService.GetByIdAsync(id);
            return View(customer);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                await shopDbService.UpdateAsync(customer);
                return RedirectToAction(nameof(Details), new { id = customer.Id });

            }

            return View();
        }

        // GET: CustomersController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var customer = await shopDbService.GetByIdAsync(id);
            return View(customer);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                await shopDbService.DeleteAsync(customer);
                return RedirectToAction(nameof(Index));

            }

            return View();
        }
    }
}
