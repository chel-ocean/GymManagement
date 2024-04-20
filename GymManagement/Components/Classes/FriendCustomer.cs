using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Components.Classes
{
    public class FriendCustomer :CustomerModel
    {
        public int workDuration { get; set; }
        public int maxBench { get; set; }
        public int maxDeadlift { get; set; }
        public string CustomerType = "friend";

        public FriendCustomer(string ID, string firstName, string lastName, string phone, string Email, int Calories, int duration, int bench, int deadlift) : base(ID, firstName, lastName, phone, Email, Calories)
        {
            workDuration = duration;
            maxBench = bench;
            maxDeadlift = deadlift; 
        }

        public override string BeniftInfo()
        {
            return $"Your total work out time in minutes is {workDuration} and max bench and max deadlift is {maxBench}kg and {maxDeadlift}kg ";
        }

    }
}
