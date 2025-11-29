using FinanceApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Services
{
    public class ExpensesService(FinanceAppContext context) : IExpensesService
    {
        private readonly FinanceAppContext _context = context;

        public async Task<bool> CreateExpenseAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteExpenseAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);

            if(expense is null)
                return false;

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Expense>> GetAllExpenses()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return expenses;
        }

        public IQueryable GetChartData()
        {
            // Filtering Expenses - Grouping them by Category - using annonymous obj. we specify 2 props one for category, the second will make sum of the amount of all the expenses that belongs to the same category, we will use them as label, data in chart.js in index.cshtml Expenses view
            var data = _context.Expenses
                .GroupBy(e => e.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(e => e.Amount)
                });
            return data;
        }

        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
            return await _context.Expenses.FindAsync(id);
        }

        public async Task<bool> UpdateExpenseAsync(Expense expense)
        {
            var existingExpense = await _context.Expenses.FindAsync(expense.Id);
            if (existingExpense is null)
                return false;

            existingExpense.Description = expense.Description;
            existingExpense.Amount = expense.Amount;
            existingExpense.Date = expense.Date;
            existingExpense.Category = expense.Category;

            _context.Expenses.Update(existingExpense);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
