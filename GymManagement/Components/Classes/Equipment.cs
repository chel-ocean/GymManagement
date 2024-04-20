/*
 * Created by Chelsea Yang
 * Date: April 18, 2024
 * The Equipment class includes the ID, name, type, and checked out status.
 * A full constructor and an empty one can be instantiated.
 * A constructor without the checked out status can be made when a new equipment is added,
 * because it's implied that it has not been checked out.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using GymManagement.Components.Classes;

namespace GymManagement.Components.Classes
{
	public class Equipment
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public bool IsCheckedOut { get; set; } = false;

		public Equipment(int Id, string name, string type, bool isCheckedOut)
		{
			this.ID = Id;
			this.Name = name;
			this.Type = type;
			this.IsCheckedOut = isCheckedOut;
		}

		public Equipment(int ID, string Name, string Type) // no bool
		{
			this.ID = ID;
			this.Name = Name;
			this.Type = Type;
		}

		public Equipment() { }
	}
}
