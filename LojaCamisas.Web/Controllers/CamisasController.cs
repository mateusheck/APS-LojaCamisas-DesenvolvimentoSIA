using LojaCamisas.Application.Interfaces;
using LojaCamisas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LojaCamisas.Web.Controllers
{
    public class CamisasController : Controller
    {
        private readonly ICamisaAppService _camisaAppService;

        public CamisasController(ICamisaAppService camisaAppService)
        {
            _camisaAppService = camisaAppService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<CamisaViewModel> model = await _camisaAppService.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            CamisaViewModel? camisa = await _camisaAppService.GetByIdAsync(id);
            if (camisa == null)
            {
                return NotFound();
            }
            return View(camisa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CamisaViewModel camisaViewModel)
        {
            if (ModelState.IsValid)
            {
                await _camisaAppService.AddAsync(camisaViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(camisaViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            CamisaViewModel? camisa = await _camisaAppService.GetByIdAsync(id);
            if (camisa == null)
            {
                return NotFound();
            }
            return View(camisa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CamisaViewModel camisaViewModel)
        {
            if (id != camisaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _camisaAppService.UpdateAsync(camisaViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(camisaViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            CamisaViewModel? camisa = await _camisaAppService.GetByIdAsync(id);
            if (camisa == null)
            {
                return NotFound();
            }
            return View(camisa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _camisaAppService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}