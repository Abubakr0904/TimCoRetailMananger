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

        public ShellViewModel(
            IEventAggregator eventAggregator
            )
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void Handle(LogOnEventModel message)
        {
            ActivateItem(IoC.Get<SalesViewModel>());
        }
    }
}
