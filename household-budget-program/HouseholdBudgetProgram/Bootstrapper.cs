using System.Windows;
using Caliburn.Micro;
using HouseholdBudgetProgram.ViewModels;

namespace HouseholdBudgetProgram
{
    public class Bootstrapper : BootstrapperBase
    {
        #region Constructor
        public Bootstrapper()
        {
            Initialize();
        }
        #endregion

        #region Methods
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<CategoryViewModel>();
        }
        #endregion
    }
}
