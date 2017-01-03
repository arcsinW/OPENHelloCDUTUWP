using HelloCDUT.Core.Exceptions; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Controls;

namespace HelloCDUT.Core.Service
{
    public class AuthEnforcementHandler : IAuthEnforcementHandler
    {
        private TaskCompletionSource<bool> _contentDialogClosedTaskCompletionSource;
        private readonly ResourceLoader _resourceLoader;
        //private TaskCompletionSource<SignInCompletionSource> _signInTaskCompletionSource;

        public AuthEnforcementHandler()
        {
            _resourceLoader = new ResourceLoader();
            AppEnvironment.Instance.CurrentUserChanged += Instance_CurrentUserChanged;
        }

        private void Instance_CurrentUserChanged(object sender, Core.Model.User e)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Requires a user to be signed in successfully.
        /// If not signed in already, the user will be prompted to do so.
        /// </summary>
        /// <exception cref="SignInRequiredException">When sign-in was not successful.</exception>
        public Task CheckUserAuthentication()
        {
            if(AppEnvironment.Instance.CurrentUser == null)
            {
                var contentDialog = new ContentDialog
                {
                    SecondaryButtonText = _resourceLoader.GetString("MessageDialog_Cancle"),
                    Title = _resourceLoader.GetString("SignInRequired_Title")
                };

                _contentDialogClosedTaskCompletionSource = new TaskCompletionSource<bool>();

                contentDialog.Closed += (s, e) => { _contentDialogClosedTaskCompletionSource.SetResult(true); };

                 
            


                throw new SignInRequiredException("Sign-in not successful");
            }
            throw new NotImplementedException();
        }
    }
}
