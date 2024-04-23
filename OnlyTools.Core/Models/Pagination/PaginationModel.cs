using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace OnlyTools.Models
{
    public class PaginationModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlHelperFactory _urlHelperFactory;

        public PaginationModel(IHttpContextAccessor httpContextAccessor, IUrlHelperFactory urlHelperFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _urlHelperFactory = urlHelperFactory;
        }

        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public object RouteValues { get; set; }
        public IUrlHelper UrlHelper { get; set; }
        public string PreviousPageUrl => HasPreviousPage ? PageUrl(PageIndex - 1) : null;
        public string NextPageUrl => HasNextPage ? PageUrl(PageIndex + 1) : null;

        public string PageUrl(int pageIndex)
        {
            var actionContext = new ActionContext(_httpContextAccessor.HttpContext, new Microsoft.AspNetCore.Routing.RouteData(), new ControllerActionDescriptor());
            var urlHelper = _urlHelperFactory.GetUrlHelper(actionContext);
            return urlHelper.Action(Action, Controller, new { page = pageIndex });
        }
    }
}
