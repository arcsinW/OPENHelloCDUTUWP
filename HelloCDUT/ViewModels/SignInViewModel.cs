using HelloCDUT.Commands;
using HelloCDUT.Models;
using HelloCDUT.Models.Input;
using HelloCDUT.Facades;
using HelloCDUT.Services;
using HelloCDUT.Views;

namespace HelloCDUT.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        public SignInInput AccountAndPassword { get; set; }
        private readonly INavigationFacade _navigationFacade;
        private readonly IDialogService _dialogService;
        private readonly IHelloCDUTService _apiService;

        public RelayCommand SignInCommand { get; private set; }

        public SignInViewModel(INavigationFacade navigationFacade,IDialogService dialogService)
        {
            _navigationFacade = navigationFacade;
            _dialogService = dialogService;
            _apiService = new ApiService();

            SignInCommand = new RelayCommand(SignIn);
            AccountAndPassword = new SignInInput() { Account = "arcsinw", Password = "1234567" };
        }
         

        public async void SignIn()
        {
            await _apiService.SignInAsync(AccountAndPassword); 
        }

        /// <summary>
        /// Enables or disables the trigger to redirect
        /// to the main page after a successful sign-in.
        /// </summary>
        public bool RedirectToMainPage { get; set; } = true;
    }
}
