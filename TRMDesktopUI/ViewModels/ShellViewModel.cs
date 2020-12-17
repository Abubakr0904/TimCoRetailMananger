using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.EventModels;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>, IHandle<LogOnEventModel>
    {
        private IEventAggregator _eventAggregator;
        private SimpleContainer _container;

        public ShellViewModel(
            SimpleContainer container,
            IEventAggregator eventAggregator
            )
        {
            _container = container;

            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEventModel message)
        {
            ActivateItem(_container.GetInstance<SalesViewModel>());
        }
    }
}
