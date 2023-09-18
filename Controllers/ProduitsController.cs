using efCoreApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace efCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProduitsController(AppDbContext context)
        {
            _context = context;
        }

        // Obtenir tous les produits
        [HttpGet]
        public ActionResult<IEnumerable<Produit>> Get()
        {
            if (_context.Produits == null)
            {
                return NotFound(); // Or return an appropriate error response
            }
            var produits = _context.Produits.ToList();
            return Ok(produits);
        }

        // Obtenir un produit par son ID
        [HttpGet("{id}")]
        public ActionResult<Produit> GetById(int id)
        {
            var produit = _context.Produits?.FirstOrDefault(p => p.Id == id);            

            if (produit == null)
            {
                return NotFound();
            }

            return Ok(produit);
        }

        // Create a new product
        [HttpPost]
        public ActionResult<Produit> Create(Produit produit)
        {
            if (_context.Produits != null)
            {
                // Add the new product to the database
                _context.Produits.Add(produit);
                _context.SaveChanges();

                // Return the newly created product
                return CreatedAtAction(nameof(GetById), new { id = produit.Id }, produit);
            }
            else
            {
                return NotFound(); // Or return an appropriate error response
            }
        }

        // Update an existing product by ID
        [HttpPut("{id}")]
        public IActionResult Update(int id, Produit updatedProduit)
        {
            if (updatedProduit == null || id != updatedProduit.Id)
            {
                return BadRequest();
            }

            var existingProduit = _context.Produits?.FirstOrDefault(p => p.Id == id);

            if (existingProduit == null)
            {
                return NotFound();
            }

            // Update the existing product properties
            existingProduit.Nom = updatedProduit.Nom;
            existingProduit.Prix = updatedProduit.Prix;

            _context.SaveChanges();

            return NoContent();
        }

        // Delete a product by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produit = _context.Produits?.FirstOrDefault(p => p.Id == id);

            if (produit == null)
            {
                return NotFound();
            }

            // Remove the product from the database
            _context.Produits?.Remove(produit);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
