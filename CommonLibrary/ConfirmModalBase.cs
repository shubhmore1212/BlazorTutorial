using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class ConfirmModalBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        public void Hide()
        {
            ShowConfirmation = false;
        }

        protected async Task OnConfirmationChange(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }
    }
}
