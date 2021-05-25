using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MLP_Blazor.Models
{
    public class LocalStateAuthProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        public LocalStateAuthProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if(await _localStorageService.ContainKeyAsync("User"))
            {
                var userInfo = await _localStorageService.GetItemAsync<LocalAuthUser>("User");

                var claims = new[]
                {
                    new Claim("Token", userInfo.AuthToken),
                    new Claim(ClaimTypes.NameIdentifier, userInfo.Id.ToString()),
                    new Claim(ClaimTypes.Role, userInfo.Role.ToString())
                };

                var identity = new ClaimsIdentity(claims, "BearerToken");
                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);
            }
            return new AuthenticationState(new ClaimsPrincipal());
        }
    }
}
