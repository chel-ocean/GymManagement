using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagement.Components.Classes;

namespace GymManagement.Components.Classes
{
	public class AccountManagerUI: IAccount
	{
		public AccountManagerUI() { }

		public void CreateAccountList(string accountType) 
		{
			MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
			{
				Server = "localhost",
				UserID = "root",
				Password = "password",
				Database = "demo211",
				AllowUserVariables = true
			};
			MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
			connection.Open();

			// Create new table Equipment
			string create = $"create table if not exists {accountType}s (Username varchar(20) not null,Password varchar(20) not null, Name varchar(20) not null, Email varchar(30) not null)";
			MySqlCommand createCmd = new MySqlCommand(create, connection);
			createCmd.ExecuteNonQuery();

			// Counts number of rows in Equipment table, to check if it is empty
			string count = $"select count(*) from {accountType}s";
			MySqlCommand countCmd = new MySqlCommand(count, connection);
			countCmd.ExecuteScalar();
			int result = int.Parse(countCmd.ExecuteScalar().ToString());

			// If the table is empty, fill it with the following information
			if (result == 0)
			{
				string insert1 = $"insert into {accountType}s values('chelsyang', 'password', 'Chelsea Yang', 'chelsea.yang@edu.sait.ca')";
				string insert2 = $"insert into {accountType}s values('davashieze', '123456', 'David Ashieze', 'chigozie.ashieze@edu.sait.ca')";

				MySqlCommand insert1Cmd = new MySqlCommand(insert1, connection);
				MySqlCommand insert2Cmd = new MySqlCommand(insert2, connection);

				insert1Cmd.ExecuteNonQuery();
				insert2Cmd.ExecuteNonQuery();
			}
			connection.Close();
		}

		public List<Account> ReadAccounts(string accountType) {
			MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
			{
				Server = "localhost",
				UserID = "root",
				Password = "password",
				Database = "demo211",
				AllowUserVariables = true
			};
			MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
			connection.Open();

			string readManagers = $"select * from {accountType}s";

			MySqlCommand readManagersCmd = new MySqlCommand(readManagers, connection);
			MySqlDataReader reader = readManagersCmd.ExecuteReader();

			List<Account> managerList = new List<Account>();

			while (reader.Read())
			{
				Account manager = new Account(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
				managerList.Add(manager);
			}
			connection.Close();

			return managerList;
		}

		public void AddAccount(Account account, string accountType) {
			MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
			{
				Server = "localhost",
				UserID = "root",
				Password = "password",
				Database = "demo211",
				AllowUserVariables = true
			};
			MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
			connection.Open();

			string insertNewManager= $"insert into {accountType}s values('{account.Username}', '{account.Password}', '{account.Name}','{account.Email}')";
			MySqlCommand insertNewManagerCmd = new MySqlCommand(insertNewManager, connection);
			insertNewManagerCmd.ExecuteNonQuery();

			connection.Close();
		}
	}
}
