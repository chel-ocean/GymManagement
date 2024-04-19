using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Components.Classes
{
    public static  class AllCustomers
    {
        public static List<BasicCustomer> basicCustomersList = new List<BasicCustomer>();
        public static List<epicCustomer> epicCustomersList = new List<epicCustomer>();
        public static List<FriendCustomer> friendCustomersList = new List<FriendCustomer>();
    }
}
