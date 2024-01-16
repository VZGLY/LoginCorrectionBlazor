using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LoginCorrectionBlazor.Client.Services
{
    public class LocalStorageService
    {
        private readonly IJSRuntime _js;

        public LocalStorageService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<bool> IsConnected()
        {
            return await GetItem("token") is not null;
        }

        public async Task SetItem(string key, string value)
        {
            await _js.InvokeVoidAsync("localStorage.setItem", key, value);
        }

        public async Task RemoveItem(string key)
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task<string> GetItem(string key)
        {
            return await _js.InvokeAsync<string>("localStorage.getItem", key);
        }
    }
}
