using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ODataExample.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly MyContext _context;

		public ProductsController(MyContext context)
		{
			_context = context;
		}

		[HttpGet]
		[EnableQuery]
		public IQueryable<ProductDTO> Get()
		{
			return _context.Products
				.Select(p => new ProductDTO()
				{
					DisplayName = p.Name,
					DisplayLevel = p.Level
				});
		}
	}
}