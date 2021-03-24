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
        private readonly Services.IShopDbServices<Models.Customer> shopDbServiceCustomer;
        private ViewModels.CommandsViewModel CommandsViewModel;


        public CommandsController(Services.IShopDbServices<Models.Command> _shopDbService, Services.IShopDbServices<Models.Customer> _shopDbServiceCustomer)
        {
            shopDbService = _shopDbService;
            shopDbServiceCustomer = _shopDbServiceCustomer;
            CommandsViewModel = new ViewModels.CommandsViewModel();
        }

        // GET: CommandsController
        public async Task<ActionResult> Index()
        {
            //var command = await shopDbService.GetAllAsync();
            //return View(command);

            CommandsViewModel.Customers = await shopDbServiceCustomer.GetAllAsync();          // Avec un viewmodel
            CommandsViewModel.Commands = await shopDbService.GetAllAsync();
            return View(CommandsViewModel);

        }

        // GET: CommandsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            //var command = await shopDbService.GetByIdAsync(id);
            //return View(command);

            CommandsViewModel.SingleCommand = await shopDbService.GetByIdAsync(id);           // Avec un viewmodel
            CommandsViewModel.SingleCustomer = await shopDbServiceCustomer.GetByIdAsync(CommandsViewModel.SingleCommand.CustomerId);

            return View(CommandsViewModel);
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
            //var command = await shopDbService.GetByIdAsync(id);
            //return View(command);

            CommandsViewModel.SingleCommand = await shopDbService.GetByIdAsync(id);           // Avec un viewmodel
            //CommandsViewModel.SingleCustomer = await shopDbServiceCustomer.GetByIdAsync(CommandsViewModel.SingleCommand.CustomerId);
            CommandsViewModel.Customers = await shopDbServiceCustomer.GetAllAsync();

            return View(CommandsViewModel);
        }

        // POST: CommandsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ViewModels.CommandsViewModel commandsViewModel)
        {
            if (ModelState.IsValid)
            {
                await shopDbService.UpdateAsync(commandsViewModel.SingleCommand);
                return RedirectToAction(nameof(Details), new { id = commandsViewModel.SingleCommand.Id });

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
