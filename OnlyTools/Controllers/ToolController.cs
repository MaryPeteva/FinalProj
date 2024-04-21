using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlyTools.Controllers;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models.Tool;
using OnlyTools.Models;

namespace OnlyTools.Web.Controllers
{
    [Authorize]
    public class ToolController : BaseController
    {
        private readonly IToolServices _services;
        private readonly ICategoriesServices _categoryServices;
        public ToolController(IToolServices services, ICategoriesServices categoryServices)
        {
            _services = services;
            _categoryServices = categoryServices;
        }
        public async Task<IActionResult> All(int page = 1, int pageSize = 5)
        {
            var tools = await _services.GetAllToolsAsync();
            int skip = (page - 1) * pageSize;
            int totalItems = tools.Count();
            tools = tools
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

            return View(tools);
        }


        [HttpGet]
        public async Task<IActionResult> AddTool()
        {
            var tool = new ToolUploadModel();
            tool.Categories = await _categoryServices.GetToolCategoriesAsync();
            return View(tool);
        }

        [HttpPost]
        public async Task<IActionResult> AddTool(ToolUploadModel tool)
        {
            Guid userId = GetUserId();
            tool.OwnerID = userId;
            await _services.AddNewToolAsync(tool);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ToolDetailsModel toolDetails = await _services.GetSpecificToolByIdAsync(id);
            if (toolDetails == null)
            {
                return NotFound();
            }
            return View(toolDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var tool = await _services.GetSpecificToolByIdAsync(id);
            if (tool == null)
            {
                return NotFound();
            }
            var toolM = new ToolUploadModel
            {
                Name = tool.Name,
                Description = tool.Description,
                RentPrice = tool.RentPrice,
            };
            toolM.Categories = await _categoryServices.GetToolCategoriesAsync();
            return View(toolM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ToolUploadModel tool)
        {
            await _services.UpdateToolAsync(id, tool);
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteToolAsync(id);
            return RedirectToAction(nameof(All));
        }


        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            var tool = await _services.GetSpecificToolByIdAsync(id);
            var userId = GetUserId();
            if (tool.IsRented)
            {
                return BadRequest();
            }
            await _services.RentToolAsync(tool.Id, userId);
            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> MyTools()
        {
            Guid myId = GetUserId();
            var tools = await _services.GetMyToolsAsync(myId);
            return View(tools);
        }

        [HttpGet]
        public async Task<IActionResult> MyRentedTools()
        {
            Guid myId = GetUserId();
            var tools = await _services.GetMyRentedToolsAsync(myId);
            return View(tools);
        }

        [HttpPost]
        public async Task<IActionResult> Return(int id)
        {
            await _services.ReturnToolAsync(id);
            return RedirectToAction(nameof(MyRentedTools));
        }

    }
}