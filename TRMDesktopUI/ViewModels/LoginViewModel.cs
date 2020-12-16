using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;

        private string _password;

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

        private void NotifyCanLogIn() => NotifyOfPropertyChange(() => CanLogIn);

        public bool CanLogIn { get { return UserName?.Length > 0 && Password?.Length > 0; } }

        public void LogIn(string username, string password)
        {
            Console.WriteLine();
        }
    }
}
