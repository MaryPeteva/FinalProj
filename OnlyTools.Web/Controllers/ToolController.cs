using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models;
using System.Security.Claims;

namespace OnlyTools.Web.Controllers
{
    [Authorize]
    public class ToolController : Controller
    {
        private readonly IToolServices _services;
        public ToolController(IToolServices services)
        {
            _services = services;
        }
        public async Task<IActionResult> All()
        {
            var tools = await _services.GetAllToolsAsync();
            return View(tools);
        }

        [HttpGet]
        public IActionResult AddTool()
        {
            var tool = new ToolUploadModel();
            return View(tool);
        }

        [HttpPost]
        public async Task<IActionResult> AddTool(ToolUploadModel tool) 
        {
            string userId = GetUserId();
            tool.OwnerID = userId;
            //TODO remove user id from AddNewToolAsync
            await _services.AddNewToolAsync(tool);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ToolDetailsModel toolDetails = await _services.GetToolDetails(id);
            if (toolDetails == null)
            {
                return NotFound();
            }
            return View(toolDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var tool = await _services.GetToolDetails(id);
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
            //add the picture once it starts working
            return View(toolM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ToolUploadModel tool)
        {
            await _services.UpdateToolAsync(id, tool);
            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
