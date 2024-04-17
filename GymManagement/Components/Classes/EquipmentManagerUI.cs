using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using GymManagement.Components.Classes;

namespace GymManagement.Components.Classes
{
	public class EquipmentManagerUI
	{
		public EquipmentManagerUI() { }

		public void CreateEquipmentList()
		{
			MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
			{
				Server = "localhost",
				UserID = "root",
				Password = "password",
				Database = "demo211",
			};
			MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
			connection.Open();

			string drop = "drop table Equipment";
			string create = "create table if not exists Equipment(ID int, Name varchar(20) not null, Type varchar(20) not null, CheckedOut bool not null)";

			string insert1 = "insert into Equipment values(1001, 'Chrome Dumbbell', 'Weights', 0)";
			string insert2 = "insert into Equipment values(1005, 'Vinyl Dumbbell', 'Weights', 0)";
			string insert3 = "insert into Equipment values(2007, 'Rowing Machine', 'Cardio', 0)";
			string insert4 = "insert into Equipment values(2009, 'Treadmill', 'Cardio', 0)";
			string insert5 = "insert into Equipment values(3003, 'Lat Pulldown', 'Machine', 0)";
			string insert6 = "insert into Equipment values(3005, 'Leg Press', 'Machine', 0)";

			MySqlCommand dropCmd = new MySqlCommand(drop, connection);
			MySqlCommand createCmd = new MySqlCommand(create, connection);
			MySqlCommand insert1Cmd = new MySqlCommand(insert1, connection);
			MySqlCommand insert2Cmd = new MySqlCommand(insert2, connection);
			MySqlCommand insert3Cmd = new MySqlCommand(insert3, connection);
			MySqlCommand insert4Cmd = new MySqlCommand(insert4, connection);
			MySqlCommand insert5Cmd = new MySqlCommand(insert5, connection);
			MySqlCommand insert6Cmd = new MySqlCommand(insert6, connection);

			dropCmd.ExecuteNonQuery();
			createCmd.ExecuteNonQuery();
			insert1Cmd.ExecuteNonQuery();
			insert2Cmd.ExecuteNonQuery();
			insert3Cmd.ExecuteNonQuery();
			insert4Cmd.ExecuteNonQuery();
			insert5Cmd.ExecuteNonQuery();
			insert6Cmd.ExecuteNonQuery();

			connection.Close();
		}

		public List<Equipment> ReadEquipment()
		{
			MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
			{
				Server = "localhost",
				UserID = "root",
				Password = "password",
				Database = "demo211",
			};
			MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
			connection.Open();

			string readEquipment = "select * from Equipment";

			MySqlCommand readEquipmentCmd = new MySqlCommand(readEquipment, connection);
			MySqlDataReader reader = readEquipmentCmd.ExecuteReader();

			List<Equipment> equipmentList = new List<Equipment>();

			while (reader.Read())
			{
				Equipment equipment = new Equipment(reader.GetInt16(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3));
				equipmentList.Add(equipment);
			}
			connection.Close();

			return equipmentList;
		}
	}
}
