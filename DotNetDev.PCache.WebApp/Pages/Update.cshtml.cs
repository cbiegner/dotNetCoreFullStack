using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace DotNetDev.PCache.WebApp.Pages
{
	using Client;
	using Model;

	public class UpdateModel : PageModel
    {
		private readonly AppSettings _appSettings;

		public string Message { get; set; }

		public UpdateModel(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
		}

		public void OnGet()
		{
			var v = new Values(_appSettings.ValuesServiceBaseURI);

			Person p = new Person()
			{
				Id = 2,
				Name = "John",
				Surname = "Doe",
				Address = new Address() { Type = AddressType.Private, Street = "Exile Street", City = "Los Angeles", ZIP = "97531" },
				Communication = new Communication() { Type = CommunicationType.Other, Value = "http://www.foo.com" }
			};

			v.Update(p);

			Message = "The item was updated. Please Check.";
		}
	}
}