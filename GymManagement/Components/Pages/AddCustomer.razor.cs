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
    public partial class AddCustomer :ComponentBase
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int calories { get; set; }
        public int duration { get; set; }
        public int maxBench { get; set; }
        public int maxDeadLift { get; set; }
        public bool added = false;
        public string type { get; set;}
        [Inject] NavigationManager NavigationManager { get; set; }
        private CustomerDb customerdb = new CustomerDb();
        public static HashSet<BasicCustomer> basicList = new HashSet<BasicCustomer>();
        public static HashSet<epicCustomer> epicList = new HashSet<epicCustomer>();
        public static HashSet<FriendCustomer> friendList = new HashSet<FriendCustomer>();
        protected override void OnInitialized()
        {
            CustomerId = Guid.NewGuid().ToString();
            basicList = customerdb.getBasicCustomers();
            epicList = customerdb.getEpicCustomers();
            friendList = customerdb.GetFriendCustomers();


        }
        public async Task Add()
        {
            if(type == null) 
            { 
                await Application.Current.MainPage.DisplayAlert("Wrong Type", "Please select a membership Type.", "OK");
                return;
            }
            else if (type.ToLower() == "basic") 
            {
                BasicCustomer customer = new BasicCustomer(CustomerId,CustomerName,CustomerLastName,phone,email,calories);
                basicList.Add(customer);
                
                customerdb.addBasic(CustomerId, CustomerName, CustomerLastName, phone, email, calories);
            }
            else if(type.ToLower() == "epic")
            {
                epicCustomer customer = new epicCustomer(CustomerId, CustomerName, CustomerLastName, phone, email, calories,duration);
                epicList.Add(customer);
                customerdb.addEpic(CustomerId, CustomerName, CustomerLastName, phone, email, calories, duration);

            }
            else if (type.ToLower()== "friend")
            {
                FriendCustomer customer = new FriendCustomer(CustomerId, CustomerName, CustomerLastName, phone, email, calories,duration,maxBench, maxDeadLift);
                friendList.Add(customer);
                customerdb.addFriend(CustomerId, CustomerName, CustomerLastName, phone, email, calories,duration,maxBench,maxDeadLift);

            }
            added = true;
            await Task.Delay(1000);
            NavigationManager.NavigateTo("/");

        }




    }
}
