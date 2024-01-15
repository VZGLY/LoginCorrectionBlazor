using LoginCorrectionBlazor.Shared.Forms;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LoginCorrectionBlazor.Client.Pages.Auth
{
    public partial class Register
    {

        [Inject]
        private HttpClient _http { get; set; }

        [Inject]
        private NavigationManager _nvm { get;set; }

        public RegisterForm Form { get; set; } = new RegisterForm();

        private async void Submit()
        {
            var response = await _http.PostAsJsonAsync("api/auth/register", Form);

            if (response.IsSuccessStatusCode)
            {
                _nvm.NavigateTo("");
            }
            else
            {
                Console.WriteLine("Erreur interne");
            }
            
        }

    }
}
