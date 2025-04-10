using Microsoft.AspNetCore.Mvc;
using StarrailAssist.Data;
using StarrailAssist.Models.Entities;
using StarrailAssist.Models;
using Microsoft.EntityFrameworkCore;

namespace StarrailAssist.Controllers
{
    public class LightConesController : Controller
    {
        public const string errorMessage = "An error has occurred:";
        public const string lightConeErrorMessage = "\nlight cone(s) could not be found/doesn't exist";
        public const string validationErrorMessage = "\nthe following is required:";
        private readonly ApplicationDbContext dbContext;

        public LightConesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var lightCones = await dbContext.LightCones.ToListAsync();

            return View(lightCones);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddLightConeViewModel viewModel)
        {
            if (viewModel.Name is null || viewModel.Path is null)
            {
                string newErrorMessage = errorMessage + validationErrorMessage;
                if (viewModel.Name is null)
                {
                    newErrorMessage += "\nName";
                }
                if (viewModel.Path is null)
                {
                    newErrorMessage += "\nPath";
                }
                Console.WriteLine(newErrorMessage);
                return View();
            }
            else
            {
                var lightCone = new LightCone
                {
                    Name = viewModel.Name,
                    Path = viewModel.Path
                };

                await dbContext.LightCones.AddAsync(lightCone);
                await dbContext.SaveChangesAsync();

                return RedirectToAction("List", "LightCones");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var lightCone = await dbContext.LightCones.FindAsync(id);

            return View(lightCone);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LightCone editedLightCone)
        {
            var lightCone = await dbContext.LightCones.FindAsync(editedLightCone.Id);

            if (lightCone is null) 
            {
                Console.WriteLine(errorMessage + lightConeErrorMessage);
                return View();
            }
            else if (editedLightCone.Name is null || editedLightCone.Path is null)
            {
                string newErrorMessage = errorMessage + validationErrorMessage;
                if (editedLightCone.Name is null)
                {
                    newErrorMessage += "\nName";
                }
                if (editedLightCone.Path is null)
                {
                    newErrorMessage += "\nPath";
                }
                Console.WriteLine(newErrorMessage);
                return View();
            }
            else
            {
                lightCone.Name = editedLightCone.Name;
                lightCone.Path = editedLightCone.Path;

                await dbContext.SaveChangesAsync();

                return RedirectToAction("List", "LightCones");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(LightCone editedLightCone)
        {
            var lightCone = await dbContext.LightCones.AsNoTracking().FirstOrDefaultAsync(lc => lc.Id == editedLightCone.Id);

            if (lightCone is null) 
            {
                Console.WriteLine(errorMessage + lightConeErrorMessage);
                return View();
            } 
            else
            {
                dbContext.LightCones.Remove(editedLightCone);
                await dbContext.SaveChangesAsync();

                return RedirectToAction("List", "LightCones");
            }
        }
    }
}
