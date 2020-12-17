using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TRMDesktopUI.EventModels;
using TRMDesktopUI.Library.Api;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        private IApiHelper _apiHelper;
        private string _errorMessage;
        private IEventAggregator _eventAggregator;

        public LoginViewModel(IApiHelper apiHelper, IEventAggregator eventAggregator)
        {
            _apiHelper = apiHelper;
            _eventAggregator = eventAggregator;
        }

        public string UserName
        {
            get { return _userName; }

            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyCanLogIn();
            }
        }

        public string Password
        {
            get { return _password; }

            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyCanLogIn();
            }
        }

        public void OnPasswordChanged(PasswordBox source)
        {
            Password = source.Password;
        }

        public bool IsErrorVisible { get { return ErrorMessage?.Length >0 ; } }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        public bool CanLogIn { get { return UserName?.Length > 0 && Password?.Length > 0; } }

        public async Task LogIn()
        {
            try
            {
                ErrorMessage = null;
                var result = await _apiHelper.Authenticate(UserName, Password);
                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

                _eventAggregator.PublishOnUIThread(new LogOnEventModel());
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        private void NotifyCanLogIn()
        {
            NotifyOfPropertyChange(() => CanLogIn);
        }
    }
}
