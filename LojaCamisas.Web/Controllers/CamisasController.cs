using LojaCamisas.Application.Interfaces;
using LojaCamisas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace LojaCamisas.Web.Controllers
{
    public class CamisasController : Controller
    {
        private readonly ICamisaAppService _camisaAppService;
        private readonly IMarcaAppService _marcaAppService;

        public CamisasController(ICamisaAppService camisaAppService, IMarcaAppService marcaAppService)
        {
            _camisaAppService = camisaAppService;
            _marcaAppService = marcaAppService;
        }

        // LISTAGEM
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var camisas = await _camisaAppService.GetAllAsync();
            return View(camisas);
        }

        // BUSCAR (AJAX)
        public async Task<IActionResult> Buscar(string termo)
        {
            var camisas = await _camisaAppService.GetAllAsync();

            if (!string.IsNullOrEmpty(termo))
                camisas = camisas
                    .Where(c => c.Nome.Contains(termo) || c.Descricao.Contains(termo))
                    .ToList();

            return PartialView("_ListaCamisasPartial", camisas);
        }

        // CREATE GET
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = await _camisaAppService.GetViewModelForCreation();
            await PreencherMarcas(vm);
            return View(vm);
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CamisaCreateEditViewModel camisaViewModel)
        {
            if (ModelState.IsValid)
            {
                await _camisaAppService.CreateAsync(camisaViewModel);
                return RedirectToAction(nameof(Index));
            }

            await PreencherMarcas(camisaViewModel);
            return View(camisaViewModel);
        }

        // EDIT GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _camisaAppService.GetViewModelForUpdate(id);
            if (vm == null) return NotFound();

            await PreencherMarcas(vm);
            return View(vm);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CamisaCreateEditViewModel camisaViewModel)
        {
            if (id != camisaViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _camisaAppService.UpdateAsync(camisaViewModel);
                return RedirectToAction(nameof(Index));
            }

            await PreencherMarcas(camisaViewModel);
            return View(camisaViewModel);
        }

        // DETAILS (USA CamisaViewModel)
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var camisas = await _camisaAppService.GetAllAsync();
            var item = camisas.FirstOrDefault(c => c.Id == id);

            if (item == null) return NotFound();

            return View(item);
        }

        // DELETE GET (USA CamisaViewModel)
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var camisas = await _camisaAppService.GetAllAsync();
            var item = camisas.FirstOrDefault(c => c.Id == id);

            if (item == null) return NotFound();

            return View(item);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _camisaAppService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // Preenche dropdown de Marcas
        private async Task PreencherMarcas(CamisaCreateEditViewModel vm)
        {
            var marcas = await _marcaAppService.GetAllAsync();

            vm.Marcas = marcas
                .Select(m => new SelectListItem
                {
                    Text = m.Nome,
                    Value = m.Id.ToString(),
                    Selected = m.Id == vm.MarcaId
                })
                .ToList();
        }
    }
}
