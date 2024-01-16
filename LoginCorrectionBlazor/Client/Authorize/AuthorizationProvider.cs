using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace LoginCorrectionBlazor.Client.Authorize
{
    public class AuthorizationProvider : AuthenticationStateProvider
    {

        private readonly IJSRuntime _js;

        public AuthorizationProvider(IJSRuntime js)
        {
            _js = js;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            

            string id = await _js.InvokeAsync<string>("localStorage.getItem", "token");

            ClaimsIdentity IClaim;

            if (!string.IsNullOrEmpty(id))
            {
                Claim claim = new Claim(ClaimTypes.NameIdentifier, id);
                Claim RoleClaim = new Claim(ClaimTypes.Role, "user");

                IClaim = new ClaimsIdentity(new List<Claim>() { claim, RoleClaim }, "Auth");
            }
            else
            {
                IClaim = new ClaimsIdentity();
            }


            var PClaim = new ClaimsPrincipal(IClaim);


            var state = new AuthenticationState(PClaim);

            return state;

            
        }
    }
}
