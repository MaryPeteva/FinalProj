using Microsoft.AspNetCore.Mvc;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models.Tips;
using OnlyTools.Core.Services;
using OnlyTools.Infrastructure.Data.Models;

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
        public async Task<IActionResult> All(int page = 1, int pageSize = 5, int? categoryId = null)
        {
            ViewData["CategoryId"] = categoryId;
            var tips = await _services.GetAllTipsAsync();
            if (categoryId != null && categoryId > 0)
            {
                tips = tips.Where(t => t.CategoryId == categoryId);
            }

            var (paginatedTips, totalPages, hasPreviousPage, hasNextPage) = await Paginate(tips, page, pageSize);

            ViewBag.PageIndex = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = hasPreviousPage;
            ViewBag.HasNextPage = hasNextPage;
            ViewBag.Categories = await _categoryServices.GetTipCategoriesAsync();
            
            return View(paginatedTips);
        }


        [HttpGet]
        public async Task<IActionResult> AddTip()
        {
            var tip = new TipUploadModel();
            tip.Categories = await _categoryServices.GetTipCategoriesAsync();
            return View(tip);
        }

        [HttpPost]
        public async Task<IActionResult> AddTip(TipUploadModel tip)
        {
            Guid userId = GetUserId();
            tip.AuthorId = userId;
            await _services.AddNewTipAsync(tip, userId);
            return RedirectToAction("Details", "Tip", new { id = tip.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            TipsDetailedModel tipDetails = await _services.GetSpecificTipByIdAsync(id);
            tipDetails.Categories = await _categoryServices.GetTipCategoriesAsync();
            if (tipDetails == null)
            {
                return NotFound();
            }
            return View(tipDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var tip = await _services.GetSpecificTipByIdAsync(id);
            if (tip == null)
            {
                return NotFound();
            }
           tip.Categories = await _categoryServices.GetTipCategoriesAsync();
            return View(tip);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TipUploadModel tip)
        {
            await _services.UpdateTipAsync(id, tip);
            return RedirectToAction("Details", "Tip", new { id = tip.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteTipAsync(id);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> MyTips(int page = 1, int pageSize = 5, int? categoryId = null)
        {

            Guid myId = GetUserId();
            var tips = await _services.GetMyTipsAsync(myId);
            if (categoryId != null && categoryId > 0)
            {
                tips = tips.Where(t => t.CategoryId == categoryId);
            }
            var (paginatedTips, totalPages, hasPreviousPage, hasNextPage) = await Paginate(tips, page, pageSize);

            ViewBag.PageIndex = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = hasPreviousPage;
            ViewBag.HasNextPage = hasNextPage;
            ViewBag.Categories = await _categoryServices.GetTipCategoriesAsync();
            return View(paginatedTips);
        }

    }
}
