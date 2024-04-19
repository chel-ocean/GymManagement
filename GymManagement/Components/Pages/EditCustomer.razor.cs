using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Components.Pages
{
    public partial class EditCustomer : ComponentBase
    {
        [Parameter]
        public string id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int calories { get; set; }
        public int duration { get; set; }
        public int maxBench { get; set; }
        public int maxDeadLift { get; set; }
        
        public string type { get; set; }
        protected override void OnInitialized()
        {
            
            


        }
    }
}
