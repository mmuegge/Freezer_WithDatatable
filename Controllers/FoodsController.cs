using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Freezer_MVC.Models;
using Freezer.Models;

namespace Freezer_MVC.Controllers
{
    public class FoodsController : Controller
    {
        private readonly DataContext _context;

        [BindProperty]
        public Food Food { get; set; }

        public FoodsController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Food = new Food();

            ViewData["FoodGroupId"] = new SelectList(_context.FoodGroups, "Id", "Name");
            ViewData["FoodSupplierId"] = new SelectList(_context.FoodSuppliers, "Id", "Name");

            if (id == null)
            {
                //create
                return View(Food);
            }
            //update
            Food = _context.Foods.FirstOrDefault(u => u.Id == id);
            if (Food == null)
            {
                return NotFound();
            }
           
            return View(Food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
           if (ModelState.IsValid)
            {
                if (Food.Id == 0)
                {
                    //create
                    _context.Foods.Add(Food);
                }
                else
                {
                    _context.Foods.Update(Food);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Food);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var daten = await _context.Foods.ToListAsync();
            var daten = await _context.Foods.Include(f => f.FoodGroup).Include(f => f.FoodSupplier).ToListAsync();

            //return Json(new { data = await _context.Foods.ToListAsync() });
            return Json(new { data = daten });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var foodFromDb = await _context.Foods.FirstOrDefaultAsync(u => u.Id == id);

            if (foodFromDb == null)
            {
                return Json(new { success = false, message = "Fehler während Löschen!" });
            }
            _context.Foods.Remove(foodFromDb);

            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Löschen erfolgreich" });
        }
        #endregion
    }
}
