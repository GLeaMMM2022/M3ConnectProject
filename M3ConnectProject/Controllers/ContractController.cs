using Microsoft.AspNetCore.Mvc;
using M3ConnectProject.Models;
using M3ConnectProject.Repositories;
using System.Linq;

namespace M3ConnectProject.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractRepository _repository;

        public ContractController(IContractRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var contracts = _repository.GetAll();
            return View(contracts);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new Contract());
            }
            var contract = _repository.GetById(id.Value);
            if (contract == null)
            {
                return NotFound();
            }
            return View(contract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contract contract)
        {
            if (ModelState.IsValid)
            {
                if (contract.Id == 0)
                {
                    _repository.Add(contract);
                }
                else
                {
                    _repository.Update(contract);
                }
                return RedirectToAction(nameof(Index)); // Перенаправляем на страницу Index
            }
            return View(contract);
        }

        [HttpPost]
        public IActionResult ToggleStatus(int id)
        {
            var contract = _repository.GetById(id);
            if (contract != null)
            {
                contract.IsActive = !contract.IsActive;
                _repository.Update(contract);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
