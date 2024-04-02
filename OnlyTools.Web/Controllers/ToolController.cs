using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models.Tool;
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
            var myId = GetUserId();
            var tools = await _services.GetMyToolsAsync(myId);
            return View(tools);
        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
