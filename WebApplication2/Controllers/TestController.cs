using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication2.Data;
using WebApplication2.Model;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MyContext _context;

        public TestController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Test
        [HttpGet]
        public IEnumerable<ProductViewModel> Get()
        {
            var rs = _context.Product.Select(x => new ProductViewModel
            {
                Id = x.Id,
                NameProduct = x.NameProduct,
                Qty = x.Qty,
                Amount = x.Amount,
                Img = x.Img
            });
            return rs;
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get Test")]
        public ActionResult<ProductViewModel> GetItem(int id)
        {
            var res = _context.Product.FirstOrDefault(x => x.Id == id);
            if (res != null)
            {
                var rs = new ProductViewModel
                {
                    Id = res.Id,
                    NameProduct = res.NameProduct,
                    Qty = res.Qty,
                    Amount = res.Amount,
                    Img = res.Img
                };
                return rs;
            }
            else
            {
               return NotFound();
            }
        }

        // POST: api/Test
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Post(ProductViewModel model)
        {
            var item = new Product
            {
                Amount = model.Amount,
                NameProduct = model.NameProduct,
                Qty = model.Qty
            };
            await _context.Product.AddAsync(item);
            await _context.SaveChangesAsync();
            var rs = CreatedAtAction(nameof(GetItem), new { id = model.Id }, model);
            return rs;
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(int id, ProductViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var data = _context.Product.Find(id);
            if (data != null )
            {
                data.Amount = model.Amount;
                data.NameProduct = model.NameProduct;
                data.Qty = model.Qty;
            }
            else
            {
                throw new System.Exception("Khong ton tai du lieu");
            }

            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Product.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Product.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
