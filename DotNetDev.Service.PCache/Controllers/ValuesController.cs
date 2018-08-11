using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DotNetDev.Service.PCache.Controllers
{
	using Model;

	[Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
		private readonly ValueContext _context;

		public ValuesController(ValueContext context)
		{
			_context = context;

			if (_context.Persons.Count() == 0)
			{
				_context.Persons.Add(new Person
				{
					Name = "Foo",
					Surname = "Dummy",
					Address = new Address() { City = "Las Vegas", Street = "Mainstreet", Type = AddressType.Business, ZIP = "98765" },
					Communication = new Communication() { Type = CommunicationType.Email, Value = "dummy@foo.com" }
				});
				_context.SaveChanges();
			}
		}

		[HttpGet]
		public ActionResult<List<Person>> GetAll()
		{
			return _context.Persons.ToList();
		}

		[HttpGet("{id}", Name = "GetPerson")]
		public ActionResult<Person> GetById(long id)
		{
			var item = _context.Persons.Find(id);
			if (item == null)
			{
				return NotFound();
			}
			return item;
		}

		[HttpPost]
		public IActionResult Create(Person item)
		{
			_context.Persons.Add(item);
			_context.SaveChanges();

			return CreatedAtRoute("GetPerson", new { id = item.Id }, item);
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, Person item)
		{
			var p = _context.Persons.Find(id);
			if (p == null)
			{
				return NotFound();
			}

			p.Name = item.Name;
			p.Surname = item.Surname;
			p.Address = item.Address;
			p.Communication = item.Communication;

			_context.Persons.Update(p);
			_context.SaveChanges();
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var p = _context.Persons.Find(id);
			if (p == null)
			{
				return NotFound();
			}

			_context.Persons.Remove(p);
			_context.SaveChanges();
			return NoContent();
		}
	}
}
