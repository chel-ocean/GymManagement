/*
 * Created by Chelsea Yang
 * Date: April 18, 2024
 * The Account class includes the username, password, name, and email.
 * A full constructor and an empty one can be instantiated.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Components.Classes
{
	public class Account
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		
		public Account(string username, string password, string name, string email) { }

		public Account() { }
	}
}
