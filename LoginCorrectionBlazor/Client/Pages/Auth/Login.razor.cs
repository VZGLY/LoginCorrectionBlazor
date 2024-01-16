using LoginCorrectionBlazor.Client.Services;
using LoginCorrectionBlazor.Shared.DTO;
using LoginCorrectionBlazor.Shared.Forms;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace LoginCorrectionBlazor.Client.Pages.Auth
{
    public partial class Login
    {

        [Inject]
        private NavigationManager _nvm { get;set; }

        [Inject]
        private HttpClient _http { get; set; }

        [Inject]
        private LocalStorageService _storageService { get; set; }

        public LoginForm Form { get; set; } = new LoginForm();

        private bool failLogin { get; set; }

        public async void Submit()
        {
            failLogin = false;

            var response = await _http.PostAsJsonAsync("api/auth/login", Form);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("login fail");
                failLogin = true;
                StateHasChanged();
                return;
            }

            

            TokenDTO? token = await response.Content.ReadFromJsonAsync<TokenDTO>();

            Console.WriteLine(token.Token);

            await _storageService.SetItem("token", token.Token);

            StateHasChanged();

            _nvm.NavigateTo("", true);
        }

    }
}
