using FinanceApp.Data;
using FinanceApp.Data.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinanceApp.Controllers
{
    public class ExpensesController(IExpensesService expensesService) : Controller
    {
        private readonly IExpensesService _expensesService = expensesService;
        public async Task<IActionResult> Index()
        {
            var expenses = await _expensesService.GetAllExpenses();
            return View(expenses);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if(ModelState.IsValid)
            {
                await _expensesService.CreateExpenseAsync(expense);

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Expense/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var expense = await _expensesService.GetExpenseByIdAsync(id);

            if (expense is null)
                return NotFound();

            return View(expense);
        }

        // POST: Expense/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Expense expense)
        {
            if (id != expense.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _expensesService.UpdateExpenseAsync(expense);
                    if (result)
                    {
                        TempData["SuccessMessage"] = "Expense updated successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Expense not found or could not be updated.";
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while updating the expense.");
                }
            }

            return View(expense);
        }

        // GET: Expenses/Delete/5 - Show confirmation page
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var expense = await _expensesService.GetExpenseByIdAsync(id.Value);
            if (expense is null)
                return NotFound();

            return View(expense);
        }

        // POST: Expenses/Delete/5 - Actual deletion
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _expensesService.DeleteExpenseAsync(id);

                if (result)
                {
                    TempData["SuccessMessage"] = "Expense deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Expense not found or could not be deleted.";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the expense.";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult GetChart()
        {
            // Query data from database
            var data = _expensesService.GetChartData();
            return Json(data);
        }
    }
}
