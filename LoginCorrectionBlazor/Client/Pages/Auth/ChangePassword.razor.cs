using LoginCorrectionBlazor.Client.Services;
using LoginCorrectionBlazor.Shared.Forms;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace LoginCorrectionBlazor.Client.Pages.Auth
{
    public partial class ChangePassword
    {
        [Inject]
        private LocalStorageService _storageService { get; set; }

        [Inject]
        private HttpClient _http { get; set; }

        [Inject]
        private NavigationManager _nvm { get; set; }

        public ChangePasswordForm Form { get; set; } = new ChangePasswordForm();

        private bool badRequest {  get; set; }

        private async void Submit()
        {
            if(await _storageService.GetItem("token") is null)
            {
                _nvm.NavigateTo("");
                return;
            }

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", (await _storageService.GetItem("token")).Split(" ")[1]);

            var content =  JsonContent.Create(Form);

            var request = await _http.PatchAsync("api/auth/password", content);

            if (request.IsSuccessStatusCode) 
            {
                _nvm.NavigateTo("");
                return;
            }
            else
            {
                if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    _nvm.NavigateTo("");
                    return;
                }

                if (request.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    badRequest = true;
                    StateHasChanged();
                    return;
                }
            }
        }

    }
}
