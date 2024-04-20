using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
