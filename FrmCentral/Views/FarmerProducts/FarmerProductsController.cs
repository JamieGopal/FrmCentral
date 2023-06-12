using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrmCentral.Models;

namespace FrmCentral.Views.FarmerProducts
{
    public class FarmerProductsController : Controller
    {
        private readonly FrmCentralContext _context;

        public FarmerProductsController(FrmCentralContext context)
        {
            _context = context;
        }

        // GET: FarmerProducts
        public async Task<IActionResult> Index()
        {
            var frmCentralContext = _context.FarmerProducts.Include(f => f.Farmer).Include(f => f.Product);
            return View(await frmCentralContext.ToListAsync());
        }

        // GET: FarmerProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FarmerProducts == null)
            {
                return NotFound();
            }

            var farmerProduct = await _context.FarmerProducts
                .Include(f => f.Farmer)
                .Include(f => f.Product)
                .FirstOrDefaultAsync(m => m.FmrProductId == id);
            if (farmerProduct == null)
            {
                return NotFound();
            }

            return View(farmerProduct);
        }

        // GET: FarmerProducts/Create
        public IActionResult Create()
        {
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FmrId", "FmrId");
            ViewData["ProductId"] = new SelectList(_context.Products, "PrdtId", "PrdtId");
            return View();
        }

        // POST: FarmerProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FmrProductId,FarmerId,ProductId,Quantity")] FarmerProduct farmerProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmerProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FmrId", "FmrId", farmerProduct.FarmerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "PrdtId", "PrdtId", farmerProduct.ProductId);
            return View(farmerProduct);
        }

        // GET: FarmerProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FarmerProducts == null)
            {
                return NotFound();
            }

            var farmerProduct = await _context.FarmerProducts.FindAsync(id);
            if (farmerProduct == null)
            {
                return NotFound();
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FmrId", "FmrId", farmerProduct.FarmerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "PrdtId", "PrdtId", farmerProduct.ProductId);
            return View(farmerProduct);
        }

        // POST: FarmerProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FmrProductId,FarmerId,ProductId,Quantity")] FarmerProduct farmerProduct)
        {
            if (id != farmerProduct.FmrProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmerProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerProductExists(farmerProduct.FmrProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FmrId", "FmrId", farmerProduct.FarmerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "PrdtId", "PrdtId", farmerProduct.ProductId);
            return View(farmerProduct);
        }

        // GET: FarmerProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FarmerProducts == null)
            {
                return NotFound();
            }

            var farmerProduct = await _context.FarmerProducts
                .Include(f => f.Farmer)
                .Include(f => f.Product)
                .FirstOrDefaultAsync(m => m.FmrProductId == id);
            if (farmerProduct == null)
            {
                return NotFound();
            }

            return View(farmerProduct);
        }

        // POST: FarmerProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FarmerProducts == null)
            {
                return Problem("Entity set 'FrmCentralContext.FarmerProducts'  is null.");
            }
            var farmerProduct = await _context.FarmerProducts.FindAsync(id);
            if (farmerProduct != null)
            {
                _context.FarmerProducts.Remove(farmerProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerProductExists(int id)
        {
          return (_context.FarmerProducts?.Any(e => e.FmrProductId == id)).GetValueOrDefault();
        }
    }
}
