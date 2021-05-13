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
    public class FoodGroupsController : Controller
    {
        private readonly DataContext _context;

        [BindProperty]
        public FoodGroup FoodGroup { get; set; }

        public FoodGroupsController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            FoodGroup = new FoodGroup();

            if (id == null)
            {
                //create
                return View(FoodGroup);
            }
            //update
            FoodGroup = _context.FoodGroups.FirstOrDefault(u => u.Id == id);
            if (FoodGroup == null)
            {
                return NotFound();
            }

            return View(FoodGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (FoodGroup.Id == 0)
                {
                    //create
                    _context.FoodGroups.Add(FoodGroup);
                }
                else
                {
                    _context.FoodGroups.Update(FoodGroup);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(FoodGroup);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var daten = await _context.FoodGroups.ToListAsync();

            return Json(new { data = await _context.FoodGroups.ToListAsync() });
            //return Json(new { data = daten });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var foodGroupFromDb = await _context.FoodGroups.FirstOrDefaultAsync(u => u.Id == id);

            if (foodGroupFromDb == null)
            {
                return Json(new { success = false, message = "Fehler während Löschen!" });
            }
            _context.FoodGroups.Remove(foodGroupFromDb);

            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Löschen erfolgreich" });
        }
        #endregion

    }
        
}
