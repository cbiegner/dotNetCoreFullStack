using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace DotNetDev.PCache.WebApp.Pages
{
	using Model;
	using Client;

	public class ListModel : PageModel
    {
		private readonly AppSettings _appSettings;

		public string Message { get; set; }

		public ListModel(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
		}

		public void OnGet()
		{
			var baseURI = _appSettings.ValuesServiceBaseURI;
			var v = new Values(baseURI);

			var result = v.Read();

			Message = $"{result.Count} Item(s) found.";
			foreach (var item in result)
			{
				Message = $"{Message}<br />{item.Surname}, {item.Name}";
			}
		}
	}
}