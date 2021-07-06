using alvamaidsbackend.Common;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alvamaidsbackend
{
    public class CustomComponentBase : ComponentBase
    {
        
        
        public bool IsBusy { get; set; }
        public Helper.ComponentState ComponentState { get; set; } = Helper.ComponentState.Empty;
        [Parameter]
        public int Quantity { get; set; } = 10;
        [Parameter]
        public int QuantityOfPages { get; set; } = 1;

        [Parameter]
        public int Page { get; set; } = 0;
        [Inject]
        public NavigationManager NavigationManager { get; set; }


    }
}
