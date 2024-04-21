using Microsoft.AspNetCore.Mvc;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models.Tips;
using OnlyTools.Core.Models.Tool;
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
        public async Task<IActionResult> All(int page = 1, int pageSize = 5)
        {
            var tips = await _services.GetAllTipsAsync();
            int skip = (page - 1) * pageSize;
            int totalItems = tips.Count();
            tips = tips
                .Skip(skip)
                .Take(pageSize)
                .ToList();


            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            bool hasPreviousPage = page > 1;
            bool hasNextPage = page < totalPages;

            ViewBag.PageIndex = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = hasPreviousPage;
            ViewBag.HasNextPage = hasNextPage;

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
        public async Task<IActionResult> Edit(int id, TipPostModel tip)
        {
            await _services.UpdateTipAsync(id, tip);
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteTipAsync(id);
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Like(int id) 
        {
            await Console.Out.WriteLineAsync("IN LIKE!");
            Guid myId = GetUserId();
            await Console.Out.WriteLineAsync("TOOK USER ID");
            await _services.LikeTipAsync(myId, id);
            await Console.Out.WriteLineAsync("LIKE RETURNED");
            return View();
        }

    }
}
