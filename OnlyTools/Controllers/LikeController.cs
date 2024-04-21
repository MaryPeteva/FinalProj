//using Microsoft.AspNetCore.Mvc;
//using OnlyTools.Core.Contracts;

//namespace OnlyTools.Controllers
//{
//    public class LikeController : BaseController
//    {
//        private readonly ILikeService likeService;
//        public LikeController(ILikeService _likeService)
//        {
//            likeService = _likeService;
//        }

//        [HttpPost]
//        async void LikeTip(int tipId) 
//        {
//            Guid userId = GetUserId();
//            await likeService.LikeTipAsync(userId, tipId);
//        }
//    }
//}
