using LoginCorrectionBlazor.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LoginCorrectionBlazor.Client.Pages.Users
{
    public partial class Users
    {
        [Inject]
        public HttpClient _http { get; set; }

        public List<User> UserList { get; set; } = new List<User>();

        protected async override Task OnInitializedAsync()
        {
            UserList = await _http.GetFromJsonAsync<List<User>>("api/user");
        }

    }
}
