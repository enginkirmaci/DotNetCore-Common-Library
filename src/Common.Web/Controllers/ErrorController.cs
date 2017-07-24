using Common.Entities;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Common.Web.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult Index()
		{
			var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();

			if (feature != null)
			{
				var exception = feature.Error;
				return View(exception);
			}

			return View(new BaseError("1", "Generic Error", null));
		}
	}
}