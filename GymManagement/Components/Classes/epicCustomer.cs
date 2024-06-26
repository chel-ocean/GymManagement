﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Created by David Ashieze
 * Date: April 19, 2024
 * This is the epic customer model ihnanced for the CustomerModelClass.
 * 
*/



namespace GymManagement.Components.Classes
{
    public class epicCustomer: CustomerModel

    {
        public int workDuration { get; set; }
        public string CustomerType = "epic";


        public epicCustomer(string ID, string firstName, string lastName, string phone, string Email, int Calories, int duration) : base( ID, firstName, lastName, phone, Email, Calories)
        { 
            workDuration = duration;
        }

        public override string BeniftInfo()
        {
            return $"Your All life time total work out time in minutes is {workDuration} and  life time burned calories is{calories} ";
        }
    }
}
