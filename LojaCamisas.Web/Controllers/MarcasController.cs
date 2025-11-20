using LojaCamisas.Application.Interfaces;
using LojaCamisas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LojaCamisas.Web.Controllers
{
    public class MarcasController : Controller
    {
        private readonly IMarcaAppService _marcaAppService;

        public MarcasController(IMarcaAppService marcaAppService)
        {
            _marcaAppService = marcaAppService;
        }

        public async Task<IActionResult> Index()
        {
            var marcas = await _marcaAppService.GetAllAsync();
            return View(marcas);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            MarcaViewModel model;

            if (id == null || id == 0)
            {
                model = new MarcaViewModel();
            }
            else
            {
                var existing = await _marcaAppService.GetByIdAsync(id.Value);
                if (existing == null) return NotFound();
                model = existing;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(MarcaViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    await _marcaAppService.CreateAsync(model);
                    TempData["success"] = "Marca criada com sucesso!";
                }
                else
                {
                    await _marcaAppService.UpdateAsync(model);
                    TempData["success"] = "Marca atualizada com sucesso!";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _marcaAppService.GetByIdAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _marcaAppService.DeleteAsync(id);
            TempData["success"] = "Marca excluída com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}