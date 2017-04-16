using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HawkWingForge.Data;
using HawkWingForge.Models;
using Microsoft.AspNetCore.Authorization;

namespace HawkWingForge.Controllers
{
    [Authorize]
    public class ProductTypesController : Controller
    {
        private readonly HawkWingForgeContext _context;

        public ProductTypesController(HawkWingForgeContext context)
        {
            _context = context;    
        }

        // GET: ProductTypes
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["TypeParam"] = string.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewData["SortOrderParam"] = sortOrder == "SortOrder" ? "sortorder_desc" : "SortOrder";
            var productTypes = from pt in _context.ProductTypes
                               select pt;
            switch (sortOrder)
            {
                case "type_desc":
                    productTypes = productTypes.OrderByDescending(pt => pt.Type);
                    break;
                case "SortOrder":
                    productTypes = productTypes.OrderBy(pt => pt.SortOrder);
                    break;
                case "sortorder_desc":
                    productTypes = productTypes.OrderByDescending(pt => pt.SortOrder);
                    break;
                default:
                    productTypes = productTypes.OrderBy(pt => pt.SortOrder);
                    break;
            }
            return View(await productTypes.AsNoTracking().ToListAsync());
        }

        // GET: ProductTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _context.ProductTypes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // GET: ProductTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SortOrder,Type")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productType);
        }

        // GET: ProductTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _context.ProductTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        // POST: ProductTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SortOrder,Type")] ProductType productType)
        {
            if (id != productType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTypeExists(productType.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(productType);
        }

        // GET: ProductTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _context.ProductTypes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // POST: ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productType = await _context.ProductTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.ProductTypes.Remove(productType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductTypeExists(int id)
        {
            return _context.ProductTypes.Any(e => e.ID == id);
        }
    }
}
