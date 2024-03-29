﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading;
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
                var state = new AuthenticationState(user);
                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return state;
            }
            return new AuthenticationState(new ClaimsPrincipal());
        }

        public async Task LogoutAsync()
        {
            await _localStorageService.RemoveItemAsync("User");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }

        public async Task<bool> AuthenticationForLoginSession(HttpClient client)
        {
            var user = await _localStorageService.GetItemAsync<LocalAuthUser>("User");
            if(user is not null) 
            {
                var token = user.AuthToken;
                var response = await client.PostAsJsonAsync("https://localhost:44397/api/User/Authenticate", token);
                if (response.IsSuccessStatusCode)
                {
                    return false;
                }
                else
                {
                    await LogoutAsync();
                    return true;
                }
            }
            return false;           
        }      
    }
}
