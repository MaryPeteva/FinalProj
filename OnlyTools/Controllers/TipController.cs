using Microsoft.AspNetCore.Mvc;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models.Tips;

namespace OnlyTools.Controllers
{
    public class TipController : BaseController
    {
        private readonly ITipServices _services;
        private readonly ICategoriesServices _categoryServices;
        public TipController(ITipServices services, ICategoriesServices categoryServices)
        {
            _services = services;
            _categoryServices = categoryServices;
        }
        public async Task<IActionResult> All()
        {
            var tips = await _services.GetAllTipsAsync();
            return View(tips);
        }

        [HttpGet]
        public async Task<IActionResult> AddTip()
        {
            var tip = new TipPostModel();
            tip.Categories = await _categoryServices.GetTipCategoriesAsync();
            return View(tip);
        }

        [HttpPost]
        public async Task<IActionResult> AddTip(TipPostModel tip)
        {
            Guid userId = GetUserId();
            tip.AuthorId = userId;
            await _services.AddNewTipAsync(tip);
            return RedirectToAction(nameof(All));
        }
    }
}
