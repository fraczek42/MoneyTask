using MoneyTask.Models;
using MoneyTask.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoneyTask.ViewModels
{
    public class ExpensesViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> Expenses { get; }
        public Command LoadExpensesCommand { get; }
        private ApiService _apiService = new ApiService();

        public ExpensesViewModel()
        {
            Title = "Wydatki";
            Expenses = new ObservableCollection<Expense>();
            LoadExpensesCommand = new Command(async () => await ExecuteLoadExpensesCommand());
            Console.WriteLine("TESTvM");
        }

        private async Task ExecuteLoadExpensesCommand()
        {
            IsBusy = true;

            try
            {
                Console.WriteLine("TEST ŁADOWANA DANYCH !!!!!! $$$$$");
                Expenses.Clear();
                var expenses = await _apiService.GetAsync<List<Expense>>("expenses/getExpenses");
                Console.WriteLine("JSON 1 : " + expenses);
                expenses.Add(new Expense { Id = 1, Amount = 5, Description = "test", ExpenseDate = new DateTime(2023 - 01 - 01) });
                foreach (var expense in expenses)
                {
                    Expenses.Add(expense);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Błąd 1 :" + ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}


