using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Components.Pages
{
    public partial class AddCustomer :ComponentBase
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int calories { get; set; }
        public int duration { get; set; }
        public int maxBench { get; set; }
        public int maxDeadlift { get; set; }





    }
}
