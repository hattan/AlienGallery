using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using aliengallery.Models;

namespace aliengallery.Services
{
    public class AppState
    {
        public List<Post> Posts{get;set;}
        public event Action OnChange;
        private readonly HttpClient http;

        public AppState(HttpClient httpInstance)
        {
            http = httpInstance;
        }


        private void NotifyStateChanged() => OnChange?.Invoke();
    }

  
}