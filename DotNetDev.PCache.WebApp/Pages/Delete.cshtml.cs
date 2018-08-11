using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace DotNetDev.PCache.WebApp.Pages
{
	using Client;

	public class DeleteModel : PageModel
	{
		private readonly AppSettings _appSettings;

		public string Message { get; set; }

		public DeleteModel(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
		}

		public void OnGet()
		{
			var v = new Values(_appSettings.ValuesServiceBaseURI);

			v.Delete(2);

			Message = "Item got deleted. Please check.";
		}
	}
}