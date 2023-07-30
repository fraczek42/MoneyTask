using MoneyTask.ViewModels;
using System;
using Xamarin.Forms;

namespace MoneyTask.Views
{
    public partial class ExpensePage : ContentPage
    {
        private ExpensesViewModel _viewModel;

        public ExpensePage()
        {
            InitializeComponent();
            _viewModel = new ExpensesViewModel();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                _viewModel.LoadExpensesCommand.Execute(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd w OnAppearing: " + ex);
            }
        }
    }
}