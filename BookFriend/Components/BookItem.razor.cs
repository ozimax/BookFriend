﻿using BookFriend.Models;
using Microsoft.AspNetCore.Components;
using System;

namespace BookFriend.Components
{
    public partial class BookItem
    {
        [Parameter]
        public Book Book { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ApplicationStateContainer StateContainer { get; set; }

        protected override void OnInitialized()
        {
            StateContainer.OnStateChange += StateHasChanged;
        }

        private void HandleBookLink()
        {
            StateContainer.SetValue(Book);
            NavigationManager.NavigateTo("/bookdetail");
        }
        public void Dispose()
        {
            StateContainer.OnStateChange -= StateHasChanged;
        }
    }
}
