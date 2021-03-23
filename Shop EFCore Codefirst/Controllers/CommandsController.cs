using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_EFCore_Codefirst.Controllers
{
    public class CommandsController : Controller
    {

        private readonly Services.IShopDbServices<Models.Command> shopDbService;

        public CommandsController(Services.IShopDbServices<Models.Command> _shopDbService)
        {
            shopDbService = _shopDbService;
        }

        // GET: CommandsController
        public async Task<ActionResult> Index()
        {
            var command = await shopDbService.GetAllAsync();
            return View(command);
        }

        // GET: CommandsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var command = await shopDbService.GetByIdAsync(id);
            return View(command);
        }

        // GET: CommandsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommandsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.Command command)
        {
            if (ModelState.IsValid)
            {
                command.Id = Guid.NewGuid();
                await shopDbService.CreateAsync(command);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: CommandsController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var command = await shopDbService.GetByIdAsync(id);
            return View(command);
        }

        // POST: CommandsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Models.Command command)
        {
            if (ModelState.IsValid)
            {
                await shopDbService.UpdateAsync(command);
                return RedirectToAction(nameof(Details), new { id = command.Id });

            }

            return View();
        }

        // GET: CommandsController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = await shopDbService.GetByIdAsync(id);
            return View(command);
        }

        // POST: CommandsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Models.Command command)
        {
            if (ModelState.IsValid)
            {
                await shopDbService.DeleteAsync(command);
                return RedirectToAction(nameof(Index));

            }

            return View();
        }
    }
}
