using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Created by David Ashieze
 * Date: April 19, 2024
 * This base absract customer model.
 * 
*/

namespace GymManagement.Components.Classes
{
    public abstract class CustomerModel
    {
        public string customerId { get; set; }
        public string customerFName { get; set; }
        public string customerLName { get; set; }
        public string customerPhone { get; set; }
        public string email { get; set; }
        public int calories { get; set; }
        
        public CustomerModel(string ID, string firstName, string lastName, string phone, string Email, int Calories) 
        {
            customerId = ID;
            customerFName = firstName;
            customerLName = lastName;
            customerPhone = phone;
            email = Email;
            calories = Calories;

        }
        public abstract string BeniftInfo();
    }
}
