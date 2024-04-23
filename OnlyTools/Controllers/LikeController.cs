using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlyTools.Core.Contracts;

namespace OnlyTools.Controllers
{
    public class LikeController : BaseController
    {
        private readonly ILikeServices _likeService;

        public LikeController(ILikeServices likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<IActionResult> LikeTip(int tipId)
        {
            Guid userId = GetUserId();
            await _likeService.LikeTipAsync(userId, tipId);
            return RedirectToAction("Details", "Tip", new { id = tipId });
        }
    }
}
