using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace $safeprojectname$
{
    public class Bootstrapper : BootstrapperBase
    {
        #region Private Variables
        private readonly SimpleContainer _Container = new SimpleContainer();
        #endregion
        #region Constructor
        public Bootstrapper()
        {
            Initialize();
        }
        #endregion

        #region Overrides
        protected override void Configure()
        {
            _Container.Singleton<IWindowManager, WindowManager>();
            _Container.Singleton<IEventAggregator, EventAggregator>();

            // Register your ShellViewModel's Contract here
            // _Container.PerRequest<IShell, ShellViewModel>();

        }
        protected override object GetInstance(Type service, string key)
        {
            var instance = _Container.GetInstance(service, key);
            if (instance != null)
                return instance;
            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _Container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _Container.BuildUp(instance);
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // Invoke your ShellViewModel via its Contract
            // DisplayRootViewFor<IShell>();
        } 
        #endregion

    }
}
