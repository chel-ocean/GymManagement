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
        protected override void OnInitialized()
        {
            CustomerId = Guid.NewGuid().ToString();


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
                AllCustomers.basicCustomersList.Add(customer);
                customerdb.addBasic(CustomerId, CustomerName, CustomerLastName, phone, email, calories);
            }
            else if(type.ToLower() == "epic")
            {
                epicCustomer customer = new epicCustomer(CustomerId, CustomerName, CustomerLastName, phone, email, calories,duration);
                AllCustomers.epicCustomersList.Add(customer);
                customerdb.addEpic(CustomerId, CustomerName, CustomerLastName, phone, email, calories, duration);

            }
            else if (type.ToLower()== "friend")
            {
                FriendCustomer customer = new FriendCustomer(CustomerId, CustomerName, CustomerLastName, phone, email, calories,duration,maxBench, maxDeadLift);
                AllCustomers.friendCustomersList.Add(customer);
                customerdb.addFriend(CustomerId, CustomerName, CustomerLastName, phone, email, calories,duration,maxBench,maxDeadLift);

            }
            added = true;
            await Task.Delay(1000);
            NavigationManager.NavigateTo("/");

        }




    }
}
