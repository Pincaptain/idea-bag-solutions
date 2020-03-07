using System.Windows;
using Caliburn.Micro;
using HouseholdBudgetProgram.ViewModels;

namespace HouseholdBudgetProgram
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<BudgetViewModel>();
        }
    }
}
