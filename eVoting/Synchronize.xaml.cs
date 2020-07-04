using System;
using System.Windows;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

namespace eVoting
{
    public class Response
    {
        public string status { get; set; }
        public string success { get; set; }
        public string message { get; set; }
    }
    public partial class Synchronize : Window
    {
        SqlConnection db_connection { get; set; }
        SqlCommand sql_command { get; set; }
        private static readonly HttpClient client = new HttpClient();

        public Synchronize()
        {
            InitializeComponent();

            //initialize the db connection
            db_connection = new SqlConnection(MainWindow.connnection_string);
            sql_command = new SqlCommand();
            sql_command.Connection = db_connection;
        }

        private async void Year_button_Click(object sender, RoutedEventArgs e)
        {
            
                //initialize the db connection
                db_connection.Open();
                sql_command = db_connection.CreateCommand();
                sql_command.CommandType = CommandType.Text;
                sql_command.CommandText = "select * from years";
                sql_command.ExecuteNonQuery();

                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sql_command);
                adapter.Fill(data);

            int count = 0;

            foreach (DataRow row in data.Rows)
            {

                var year = new Dictionary<string, string>
                {
                    { "id", row["id"].ToString() },
                    { "year_name", row["year_name"].ToString()},
                    { "is_current", row["is_current"].ToString() },

                };


                var content = new FormUrlEncodedContent(year);

                var response = await client.PostAsync("http://localhost:5000/api/year", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Response Response = JsonConvert.DeserializeObject<Response>(responseString);

                    //MessageBox.Show(Response.message.ToString());
                    sync_count.Content = count++ + " Entities Syncd";
                }

            }

            db_connection.Close();

            
          

        }

        private async void Office_button_Click(object sender, RoutedEventArgs e)
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "select * from offices";
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);
            adapter.Fill(data);

            int count = 0;

            foreach (DataRow row in data.Rows)
            {

                var office = new Dictionary<string, string>
                {

                    { "id", row["id"].ToString() },
                    { "office_name", row["office_name"].ToString()},
                    { "office_description", row["office_description"].ToString() },
                    { "organization", row["organization"].ToString() },

                };


                var content = new FormUrlEncodedContent(office);

                var response = await client.PostAsync("http://localhost:5000/api/office", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Response Response = JsonConvert.DeserializeObject<Response>(responseString);

                   // MessageBox.Show(Response.message.ToString());
                    sync_count.Content = count++ + " Entities Syncd";
                }

            }

            db_connection.Close();

        }

        private async void Party_button_Click(object sender, RoutedEventArgs e)
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "select * from parties";
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);
            adapter.Fill(data);

            int count = 0;

            foreach (DataRow row in data.Rows)
            {

                var office = new Dictionary<string, string>
                {

                    { "id", row["id"].ToString() },
                    { "party_name", row["party_name"].ToString()},
                    { "party_slogan", row["party_slogan"].ToString() },
                    { "party_vision", row["party_vision"].ToString() },
                    { "party_mission", row["party_mission"].ToString() },
                    { "certified", row["certified"].ToString() },

                };


                var content = new FormUrlEncodedContent(office);

                var response = await client.PostAsync("http://localhost:5000/api/party", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Response Response = JsonConvert.DeserializeObject<Response>(responseString);

                    //MessageBox.Show(Response.message.ToString());
                    sync_count.Content = count++ + " Entities Syncd";
                }

            }

            db_connection.Close();

        }

        private async void Contestant_button_Click(object sender, RoutedEventArgs e)
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "select * from contestants";
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);
            adapter.Fill(data);

            int count = 0;

            foreach (DataRow row in data.Rows)
            {

                var contestant = new Dictionary<string, string>
                {

                    { "id", row["id"].ToString() },
                    { "user", row["user"].ToString()},
                    { "party", row["party"].ToString() },
                    { "office", row["office"].ToString() },
                    { "year", row["year"].ToString() },
                    
                };


                var content = new FormUrlEncodedContent(contestant);

                var response = await client.PostAsync("http://localhost:5000/api/contestant", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Response Response = JsonConvert.DeserializeObject<Response>(responseString);

                    //MessageBox.Show(Response.message.ToString());
                    sync_count.Content = count++ + " Entities Syncd";
                }

            }

            db_connection.Close();

        }

        private async void Voters_button_Click(object sender, RoutedEventArgs e)
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "select * from users";
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);
            adapter.Fill(data);

            int count = 0;

            foreach (DataRow row in data.Rows)
            {

                var voter = new Dictionary<string, string>
                {

                    { "id", row["id"].ToString() },
                    { "first_name", row["first_name"].ToString()},
                    { "last_name", row["last_name"].ToString() },
                    { "date_of_birth", row["date_of_birth"].ToString() },
                    
                    { "phone", row["phone"].ToString() },
                    { "email", row["email"].ToString() },
                    { "state", row["state"].ToString() },
                    { "lga", row["lga"].ToString() },
                    { "password", row["password"].ToString() },
                    { "role", row["role"].ToString() },

                };


                var content = new FormUrlEncodedContent(voter);

                var response = await client.PostAsync("http://localhost:5000/api/register", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Response Response = JsonConvert.DeserializeObject<Response>(responseString);

                    //MessageBox.Show(Response.message.ToString());
                    sync_count.Content = count++ + " Entities Syncd";
                }

            }

            db_connection.Close();

        }

        private async void Organization_button_Click(object sender, RoutedEventArgs e)
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "select * from organizations";
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);
            adapter.Fill(data);

            int count = 0;

            foreach (DataRow row in data.Rows)
            {

                var organization = new Dictionary<string, string>
                {

                    { "id", row["id"].ToString() },
                    { "organization_name", row["organization_name"].ToString()},
                    { "organization_code", row["organization_code"].ToString() },
                    { "current_election_year", row["current_election_year"].ToString() },
                    { "election_start", row["election_start"].ToString() },

                };
            

                var content = new FormUrlEncodedContent(organization);

                var response = await client.PostAsync("http://localhost:5000/api/organization", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Response Response = JsonConvert.DeserializeObject<Response>(responseString);

                    //MessageBox.Show(Response.message.ToString());
                    sync_count.Content = count++ + " Entities Syncd";
                }

            }

            db_connection.Close();

        }

        private async void Sync_votes_button_Click(object sender, RoutedEventArgs e)
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "select * from votes";
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);
            adapter.Fill(data);

            int count = 0;

            foreach (DataRow row in data.Rows)
            {

                var office = new Dictionary<string, string>
                {

                    { "id", row["id"].ToString() },
                    { "user_id", row["user_id"].ToString()},
                    { "contestant_id", row["contestant_id"].ToString() },
                    { "party_id", row["party_id"].ToString() },
                    { "office_id", row["office_id"].ToString() },
                    { "year_id", row["year_id"].ToString() },
                    
                    { "organization_code", row["organization_code"].ToString() },
                    { "created_at", row["created_at"].ToString() },

                };


                var content = new FormUrlEncodedContent(office);

                var response = await client.PostAsync("http://localhost:5000/api/vote", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Response Response = JsonConvert.DeserializeObject<Response>(responseString);

                    sync_count.Content = count++ + " Entities Syncd";
                   // MessageBox.Show(Response.message.ToString());
                }

            }

            db_connection.Close();

        }



    }
}
