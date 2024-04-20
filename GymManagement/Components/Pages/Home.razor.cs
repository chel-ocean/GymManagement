using GymManagement.Components.Classes;
using GymManagement.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace GymManagement.Components.Pages
{
    public partial class Home : ComponentBase
    {
        public int Id { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public string Name { get; set; }
        //public AllCustomers list = new AllCustomers();
        //public static List<BasicCustomer> basicList = AllCustomers.basicCustomersList;
        //public static List<epicCustomer> epicList = AllCustomers.epicCustomersList;
        // public static List<FriendCustomer> firendList = AllCustomers.friendCustomersList;

        public static HashSet<BasicCustomer> basicList = new HashSet<BasicCustomer>();
        public static HashSet<epicCustomer> epicList = new HashSet<epicCustomer>();
        public static HashSet<FriendCustomer> friendList = new HashSet<FriendCustomer>();
        private CustomerDb customerdb = new CustomerDb();
        protected override void OnInitialized()
        {
            
            customerdb.InitializeDatabase();
            basicList = customerdb.getBasicCustomers();
            epicList = customerdb.getEpicCustomers();
            friendList = customerdb.GetFriendCustomers();

            // if list is empty popluate db Guid g = Guid.NewGuid(); 



        }
        private void Add()
        {
            NavigationManager.NavigateTo("/AddCustomer");
        }
        private void Edit(string id, string type) 
        {
            NavigationManager.NavigateTo($"/EditCustomer/{id}/{type}");
        }
        private void Remove(string id, string type) 
        {
            customerdb.removeCusotmer(id, type);
            NavigationManager.NavigateTo($"/", forceLoad: true);
        }
    }


    
}
