using GymManagement.Components.Classes;
using MySqlConnector;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Services
{
    public class CustomerDb
    {
        protected MySqlConnection connection;


        public CustomerDb()
        {
            // get environemnt variable
            string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            string dbUser = Environment.GetEnvironmentVariable("DB_USER");
            string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

            var builder = new MySqlConnectionStringBuilder
            {
                Server = dbHost,
                UserID = dbUser,
                Password = dbPassword,
                Database = "gymmangementdb",
            };

            connection = new MySqlConnection(builder.ConnectionString);
        }

        /// <summary>
        /// Initialize the database and creates all the customer tables table
        /// </summary>
        public void InitializeDatabase()
        {
            connection.Open();

            var basicSql = @"CREATE TABLE IF NOT EXISTS BasicCustomer (
                customerId VARCHAR(36) PRIMARY KEY,
                FirstName VARCHAR(255) NOT NULL,
                LastName VARCHAR(255) NOT NULL,
                phone VARCHAR(255),
                email TEXT,
                
                Calories INT
            
                
            )";
            var epicSql = @"CREATE TABLE IF NOT EXISTS EpicCustomer (
                customerId VARCHAR(36) PRIMARY KEY,
                FirstName VARCHAR(255) NOT NULL,
                LastName VARCHAR(255) NOT NULL,
                phone VARCHAR(255),
                email TEXT,
                
                Calories int,
                duration int
                    
                
            )";
            var friendSql = @"CREATE TABLE IF NOT EXISTS friendCustomer (
                customerId VARCHAR(36) PRIMARY KEY,
                FirstName VARCHAR(255) NOT NULL,
                LastName VARCHAR(255) NOT NULL,
                phone VARCHAR(255),
                email TEXT,
                Calories int,
                duration int,
                bench int,
                deadlift int
                
            )";
            
          
            var command = new MySqlCommand(basicSql, connection);
            var command2 = new MySqlCommand(epicSql, connection);
            var command3 = new MySqlCommand(friendSql, connection);
            command.ExecuteNonQuery();
            
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            
            command3.ExecuteNonQuery();


            var checkbasic = "select * form BasicCustomer;";
            var commandtestBasic = new MySqlCommand(checkbasic, connection);
            //var populatebasic = "Insert into BasicCustomer values('1234','bob','dame','403-343-2332','23@mad',234),('1235','fob','lame','423-323-1952','dfsd@mad',2334) ";
            //var popuateCom = new MySqlCommand(populatebasic,connection);
           // popuateCom.ExecuteNonQuery();


            connection.Close();
        }

        /// <summary>
        /// Implement reirves all cutomers form the database
        /// </summary>
        public void getAllCustomers()
        {
           // load all basic cusotmer into the list
            connection.Open();
            string sql = "Select * from BasicCustomer;";
            var command = new MySqlCommand(sql, connection);


            var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                //AllCustomers.basicCustomersList.Clear();
                BasicCustomer bc = new BasicCustomer((string)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4], (int)reader[5] );
               // list.basicCustomersList.Add(bc);
                AllCustomers.basicCustomersList.Add(bc);
            }

            // load up all epic cusomers into the list
            string sqlepic = "Select * from EpicCustomer;";
            var commandEpic = new MySqlCommand(sqlepic, connection);
            connection.Close();
            connection.Open();

            var readerEpic = commandEpic.ExecuteReader();

            while (readerEpic.Read())
            {
               // AllCustomers.epicCustomersList.Clear();
                epicCustomer ec = new epicCustomer((string)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4], (int)reader[5], (int)reader[6]);
                
                AllCustomers.epicCustomersList.Add(ec);
            }



            // load up all friend cusomers into the list
            string sqlFriend = "Select * from friendCustomer;";
            var commandFriend = new MySqlCommand(sqlFriend, connection);


            connection.Close();
            connection.Open();

            var readerFriend = commandFriend.ExecuteReader();

            while (readerFriend.Read())
            {
                //AllCustomers.friendCustomersList.Clear();
                FriendCustomer fc = new FriendCustomer((string)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4], (int)reader[5], (int)reader[6], (int)reader[7], (int)reader[8]);
                
                AllCustomers.friendCustomersList.Add(fc);
            }




            connection.Close();



        }
       
        public void addBasic(string ID, string firstName, string lastName, string phone, string Email, int Calories)
        {
            connection.Open();
            var sql = $"Insert into BasicCustomer values('{ID}','{firstName}','{lastName}','{phone}','{Email}',{Calories})";
            var command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();

        }
        public void addEpic(string ID, string firstName, string lastName, string phone, string Email, int Calories, int duration)
        {
            connection.Open();
            var sql = $"Insert into epicCustomer values('{ID}','{firstName}','{lastName}','{phone}','{Email}',{Calories}, {duration})";
            var command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        // add customer into fried db
        public void addFriend(string ID, string firstName, string lastName, string phone, string Email, int Calories, int duration, int bench, int deadlift)
        {
            connection.Open();
            var sql = $"Insert into friendCustomer values('{ID}','{firstName}','{lastName}','{phone}','{Email}',{Calories}, {duration},{bench},{deadlift})";
            var command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        //public void editCusotmer(string id) { }
        public void removeCusotmer(string id) 
        { 
        }







    }
}
