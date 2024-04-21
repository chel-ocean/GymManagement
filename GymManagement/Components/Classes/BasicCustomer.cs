using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Created by David Ashieze
 * Date: April 19, 2024
 * This is the baic customer model ihnanced for the CustomerModelClass.
 * 
*/


namespace GymManagement.Components.Classes
{
    public class BasicCustomer:CustomerModel
    {
        public string CustomerType = "basic";
        public BasicCustomer(string ID, string firstName, string lastName, string phone, string Email, int Calories) : base(ID, firstName, lastName, phone, Email, Calories)
        {
        }
        public override  string BeniftInfo()
        {
            return $"Your  life time burned calories is{calories} ";
        }
    }
}
