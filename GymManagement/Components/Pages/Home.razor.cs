﻿using GymManagement.Components.Classes;
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
        public static List<BasicCustomer> basicList = AllCustomers.basicCustomersList;
        public static List<epicCustomer> epicList = AllCustomers.epicCustomersList;
        public static List<FriendCustomer> firendList = AllCustomers.friendCustomersList;
        private CustomerDb customerdb = new CustomerDb();
        protected override void OnInitialized()
        {
            
            customerdb.InitializeDatabase();
            customerdb.getAllCustomers();
            // if list is empty popluate db Guid g = Guid.NewGuid(); 

            //AllCustomers list = new AllCustomers();
            // List<BasicCustomer> basicList = list.basicCustomersList;


        }
        private void Add()
        {
            NavigationManager.NavigateTo($"/AddCustomer/");
        }


    }
}