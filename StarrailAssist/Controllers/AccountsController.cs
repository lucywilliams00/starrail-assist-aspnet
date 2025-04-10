using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarrailAssist.Data;
using StarrailAssist.Models.Entities;
using StarrailAssist.Models;

namespace StarrailAssist.Controllers
{
    public class AccountsController : Controller
    {
        public const string errorMessage = "An error has occurred:";
        public const string accountErrorMessage = "\naccount(s) could not be found/doesn't exist";
        public const string validationErrorMessage = "\nthe following is required:";
        private readonly ApplicationDbContext dbContext;

        public AccountsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var accounts = await dbContext.Accounts.ToListAsync();

            return View(accounts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAccountViewModel viewModel)
        {
            if (viewModel.Name is null || viewModel.Email is null || viewModel.Zone is null)
            {
                string newErrorMessage = errorMessage + validationErrorMessage;
                if (viewModel.Name is null)
                {
                    newErrorMessage += "\nName";
                }
                if (viewModel.Email is null)
                {
                    newErrorMessage += "\nEmail";
                }
                if (viewModel.Zone is null)
                {
                    newErrorMessage += "\nZone";
                }
                Console.WriteLine(newErrorMessage);
                return View();
            }
            else
            {
                var account = new Account
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Zone = viewModel.Zone
                };

                await dbContext.Accounts.AddAsync(account);
                await dbContext.SaveChangesAsync();

                return RedirectToAction("List", "Accounts");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var account = await dbContext.Accounts.FindAsync(id);

            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Account editedAccount)
        {
            var account = await dbContext.Accounts.FindAsync(editedAccount.Id);

            if (account is null)
            {
                Console.WriteLine(errorMessage + accountErrorMessage);
                return View();
            }
            else if (editedAccount.Name is null || editedAccount.Email is null || editedAccount.Zone is null)
            {
                string newErrorMessage = errorMessage + validationErrorMessage;
                if (editedAccount.Name is null)
                {
                    newErrorMessage += "\nName";
                }
                if (editedAccount.Email is null)
                {
                    newErrorMessage += "\nEmail";
                }
                if (editedAccount.Zone is null)
                {
                    newErrorMessage += "\nZone";
                }
                Console.WriteLine(newErrorMessage);
                return View();
            }
            else
            {
                account.Name = editedAccount.Name;
                account.Email = editedAccount.Email;
                account.Zone = editedAccount.Zone;

                await dbContext.SaveChangesAsync();

                return RedirectToAction("List", "Accounts");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Account editedAccount)
        {
            var account = await dbContext.Accounts.AsNoTracking().FirstOrDefaultAsync(u => u.Id == editedAccount.Id);

            if (account is null)
            {
                Console.WriteLine(errorMessage + accountErrorMessage);
                return View();
            }
            else
            {
                dbContext.Accounts.Remove(editedAccount);
                await dbContext.SaveChangesAsync();

                return RedirectToAction("List", "Accounts");
            }
        }
    }
}
