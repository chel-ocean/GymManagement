using GymManagement.Components.Classes;
using GymManagement.Services;
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
        [Parameter]
        public string type { get; set; }
        
        public bool saved=false;

        [Inject] NavigationManager NavigationManager { get; set; }
        public static HashSet<BasicCustomer> basicList = new HashSet<BasicCustomer>();
        public static HashSet<epicCustomer> epicList = new HashSet<epicCustomer>();
        public static HashSet<FriendCustomer> friendList = new HashSet<FriendCustomer>();
        private CustomerDb customerdb = new CustomerDb();
        public BasicCustomer foundbasic;
        public epicCustomer foundEpic;
        public FriendCustomer foundFriend;
        /// <summary>
        /// displays and find the clicked customer from thier list
        /// </summary>
        protected override void OnInitialized()
        {
            
            customerdb.InitializeDatabase();
            basicList = customerdb.getBasicCustomers();
            epicList = customerdb.getEpicCustomers();
            friendList = customerdb.GetFriendCustomers();
            if (type.ToLower() == "basic")
            {
                foreach (BasicCustomer customer in basicList)
                {
                    if(customer.customerId == id)
                    {

                        foundbasic = customer;

                    }
                }
            }
            else if(type.ToLower() == "epic")
            {
                foreach (epicCustomer customer in epicList)
                {
                    if (customer.customerId == id)
                    {

                        foundEpic = customer;

                    }
                }

            }

            else if (type.ToLower() == "friend")
            {
                foreach (FriendCustomer customer in friendList)
                {
                    if (customer.customerId == id)
                    {
                        foundFriend = customer;

                    }
                }

            }

            // if list is empty popluate db Guid g = Guid.NewGuid(); 



        }
        /// <summary>
        /// saves the customer to the right databese
        /// </summary>
        /// <returns></returns>
        public async Task Save()
        {
            
            saved = true;
            if (type.ToLower() == "basic") 
            { customerdb.editBasicCusotmer(foundbasic); }
            else if (type.ToLower() == "epic") 
            { customerdb.editEpicCustomer(foundEpic); }
            else if (type.ToLower() == "friend")
            {
                customerdb.editFriendCustomer(foundFriend);
            }
            
            await Task.Delay(1000);
            NavigationManager.NavigateTo("/");

        }
    }
}
