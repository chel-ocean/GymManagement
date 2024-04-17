using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Components.Classes
{
	public class Weights : Equipment
	{
		int Weight { get; set; }
		
		public Weights(int ID, string Name, string Type) : base(ID, Name, Type)
		{

		}
	}
}
