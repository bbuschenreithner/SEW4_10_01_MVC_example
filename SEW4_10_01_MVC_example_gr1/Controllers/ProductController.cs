using Microsoft.AspNetCore.Mvc;
using SEW4_10_01_MVC_example_gr1.Models;

namespace SEW4_10_01_MVC_example_gr1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        public IActionResult Edit(int id)
        {
            Product? product = _context.Products.Find(id);
            if (product == null) { return NotFound(); }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        public IActionResult Delete(int id)
        {
            Product? product = _context.Products.Find(id);
            if (product == null) { return NotFound(); }
            _context.Products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
