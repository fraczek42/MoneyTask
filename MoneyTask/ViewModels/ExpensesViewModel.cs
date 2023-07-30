using MoneyTask.Models;
using MoneyTask.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoneyTask.ViewModels
{
    public class ExpensesViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> Expenses { get; }
        public Command LoadExpensesCommand { get; private set; }
        private ApiService _apiService = new ApiService();
        public Command YourButtonCommand { get; private set; }

        public ExpensesViewModel()
        {
            try
            {
                Title = "Wydatki";
                Expenses = new ObservableCollection<Expense>();
                LoadExpensesCommand = new Command(async () => await ExecuteLoadExpensesCommand());
                YourButtonCommand = new Command(OnButtonClicked);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd podczas ExpensesViewModel:" + ex);
            }

        }

        private Task ExecuteLoadExpensesCommand()
        {
            IsBusy = true;

            try
            {
                Expenses.Clear();
                List<Expense> expenses = null;

                try
                {
                    expenses = Test(expenses);
                    //expenses = await _apiService.GetAsync<List<Expense>>("expenses/getExpenses");

                    //if (expenses == null)
                    //    expenses.Add(new Expense { Id = 0, Amount = 0, Description = "Brak wydatków", ExpenseDate = new DateTime(2023, 01, 01) });
                }
                catch (Exception apiEx)
                {
                    Console.WriteLine("Błąd podczas wywoływania API: " + apiEx);
                }

                foreach (var expense in expenses)
                {
                    Expenses.Add(expense);
                };

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Błąd - ExecuteLoadExpensesCommand: " + ex);
            }
            finally
            {
                IsBusy = false;
            }

            return Task.CompletedTask;
        }

        private void OnButtonClicked(object obj)
        {
            Console.WriteLine("Przycisk został kliknięty!");
        }


        private List<Expense> Test(List<Expense> expenses)
        {
            expenses = new List<Expense>
            {
                new Expense { Id = 1, Description = "Jedzenie", Amount = 100.00m, ExpenseDate = DateTime.Now.AddDays(-10) },
                new Expense { Id = 2, Description = "Transport", Amount = 50.00m, ExpenseDate = DateTime.Now.AddDays(-9) },
                new Expense { Id = 3, Description = "Rachunki", Amount = 200.00m, ExpenseDate = DateTime.Now.AddDays(-8) },
                new Expense { Id = 4, Description = "Rozrywka", Amount = 150.00m, ExpenseDate = DateTime.Now.AddDays(-7) },
                new Expense { Id = 5, Description = "Zakupy", Amount = 500.00m, ExpenseDate = DateTime.Now.AddDays(-6) },
                new Expense { Id = 6, Description = "Edukacja", Amount = 250.00m, ExpenseDate = DateTime.Now.AddDays(-5) },
                new Expense { Id = 7, Description = "Ubrania", Amount = 300.00m, ExpenseDate = DateTime.Now.AddDays(-4) },
                new Expense { Id = 8, Description = "Zdrowie", Amount = 350.00m, ExpenseDate = DateTime.Now.AddDays(-3) },
                new Expense { Id = 9, Description = "Podróże", Amount = 400.00m, ExpenseDate = DateTime.Now.AddDays(-2) },
                new Expense { Id = 10, Description = "Inne", Amount = 450.00m, ExpenseDate = DateTime.Now.AddDays(-1) }
            };
            return expenses;
        }
    }
}


