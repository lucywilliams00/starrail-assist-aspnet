using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarrailAssist.Data;
using StarrailAssist.Models;
using StarrailAssist.Models.Entities;

namespace StarrailAssist.Controllers
{
    public class CharactersController : Controller
    {
        public const string errorMessage = "An error has occurred:";
        public const string characterErrorMessage = "\ncharacter(s) could not be found/doesn't exist";
        public const string lightConeErrorMessage = "\nlight cone(s) could not be found/doesn't exist";
        public const string validationErrorMessage = "\nthe following is required:";
        private readonly ApplicationDbContext dbContext;

        public CharactersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var characters = await dbContext.Characters.ToListAsync();

            return View(characters);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCharacterViewModel viewModel)
        {
            if (viewModel.Name is null || viewModel.Path is null || viewModel.Type is null)
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
                if (viewModel.Type is null)
                {
                    newErrorMessage += "\nType";
                }
                Console.WriteLine(newErrorMessage);
                return View();
            }
            else
            {
                var character = new Character
                {
                    Name = viewModel.Name,
                    Path = viewModel.Path,
                    Type = viewModel.Type,
                    LCOne = "",
                    LCTwo = "",
                    LCThree = "",
                    LCFour = "",
                    LCFive = "",
                    LCSix = "",
                    LCSeven = "",
                    LCEight = "",
                    LCNine = "",
                    LCTen = ""
                };

                await dbContext.Characters.AddAsync(character);
                await dbContext.SaveChangesAsync();

                return RedirectToAction("List", "Characters");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var character = await dbContext.Characters.FindAsync(id);
            IQueryable<LightCone>? lightCones = null;

            if (character is not null)
            {
                lightCones = dbContext.LightCones.Where(lightCone => lightCone.Path == character.Path);
            }

            return View(new CharacterLightConesViewModel() { Character = character, LightCones = lightCones });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Character editedCharacter)
        {
            var character = await dbContext.Characters.FindAsync(editedCharacter.Id);

            if (character is null) 
            {
                Console.WriteLine(errorMessage + characterErrorMessage);
                return View();
            } 
            else if (editedCharacter.Name is null || editedCharacter.Path is null || editedCharacter.Type is null)
            {
                string newErrorMessage = errorMessage + validationErrorMessage;
                if (editedCharacter.Name is null)
                {
                    newErrorMessage += "\nName";
                }
                if (editedCharacter.Path is null)
                {
                    newErrorMessage += "\nPath";
                }
                if (editedCharacter.Type is null)
                {
                    newErrorMessage += "\nType";
                }
                Console.WriteLine(newErrorMessage);
                return View();
            }
            else
            {
                character.Name = editedCharacter.Name;
                character.Path = editedCharacter.Path;
                character.Type = editedCharacter.Type;
                character.LCOne = editedCharacter.LCOne ?? "";
                character.LCTwo = editedCharacter.LCTwo ?? "";
                character.LCThree = editedCharacter.LCThree ?? "";
                character.LCFour = editedCharacter.LCFour ?? "";
                character.LCFive = editedCharacter.LCFive ?? "";
                character.LCSix = editedCharacter.LCSix ?? "";
                character.LCSeven = editedCharacter.LCSeven ?? "";
                character.LCEight = editedCharacter.LCEight ?? "";
                character.LCNine = editedCharacter.LCNine ?? "";
                character.LCTen = editedCharacter.LCTen ?? "";

                await dbContext.SaveChangesAsync();

                return RedirectToAction("List", "Characters");
            }
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var character = await dbContext.Characters.FindAsync(id);
            IQueryable<LightCone>? lightCones = null;

            if (character is not null)
            {
                lightCones = dbContext.LightCones.Where(lightCone => lightCone.Path == character.Path);
            }

            return View(new CharacterLightConesViewModel() { Character = character, LightCones = lightCones });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Character editedCharacter)
        {
            var character = await dbContext.Characters.AsNoTracking().FirstOrDefaultAsync(c => c.Id == editedCharacter.Id);

            if (character is null) 
            {
                Console.WriteLine(errorMessage + characterErrorMessage);
                return View();
            } 
            else
            {
                dbContext.Characters.Remove(editedCharacter);
                await dbContext.SaveChangesAsync();

                return RedirectToAction("List", "Characters");
            }
        }
    }
}
