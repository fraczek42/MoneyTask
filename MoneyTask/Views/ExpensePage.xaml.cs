using MoneyTask.ViewModels;
using Xamarin.Forms;

namespace MoneyTask.Views
{
    public partial class ExpensePage : ContentPage
    {
        ExpensesViewModel _expensesModel;
        public ExpensePage()
        {
            InitializeComponent();
            BindingContext = _expensesModel = new ExpensesViewModel();
        }
    }
}