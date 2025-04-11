using Microsoft.AspNetCore.Mvc;
using SEW4_10_01_MVC_example_gr1.Models;

namespace SEW4_10_01_MVC_example_gr1.Controllers
{
    public class ProductAjaxController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductAjaxController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }
        [HttpPost]
        public JsonResult Create([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Json(new { success = true, message = "Produkt wurde erstellt", product = product });
            }
            return Json(new { success = false, message = "Validierungsfehler", errors = ModelState.Values });
        }
    }
}
