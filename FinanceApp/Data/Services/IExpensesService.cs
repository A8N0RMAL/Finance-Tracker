using FinanceApp.Models;

namespace FinanceApp.Data.Services
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAllExpenses();
        Task<Expense> GetExpenseByIdAsync(int id);
        Task<bool> CreateExpenseAsync(Expense expense);
        Task<bool> DeleteExpenseAsync(int id);
        Task<bool> UpdateExpenseAsync(Expense expense);
        IQueryable GetChartData();
    }
}
