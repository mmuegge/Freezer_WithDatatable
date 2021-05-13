using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Freezer_MVC.Models;

namespace Freezer_MVC.Controllers
{
    public class FoodSuppliersController : Controller
    {
        private readonly DataContext _context;

        [BindProperty]
        public FoodSupplier FoodSupplier { get; set; }

        public FoodSuppliersController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            FoodSupplier = new FoodSupplier();

            if (id == null)
            {
                //create
                return View(FoodSupplier);
            }
            //update
            FoodSupplier = _context.FoodSuppliers.FirstOrDefault(u => u.Id == id);
            if (FoodSupplier == null)
            {
                return NotFound();
            }

            return View(FoodSupplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (FoodSupplier.Id == 0)
                {
                    //create
                    _context.FoodSuppliers.Add(FoodSupplier);
                }
                else
                {
                    _context.FoodSuppliers.Update(FoodSupplier);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(FoodSupplier);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _context.FoodSuppliers.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var foodSupplierFromDb = await _context.FoodSuppliers.FirstOrDefaultAsync(u => u.Id == id);

            if (foodSupplierFromDb == null)
            {
                return Json(new { success = false, message = "Fehler während Löschen!" });
            }
            _context.FoodSuppliers.Remove(foodSupplierFromDb);

            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Löschen erfolgreich" });
        }
        #endregion

    }
}
