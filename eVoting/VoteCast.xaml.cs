using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace eVoting
{
    /// <summary>
    /// Interaction logic for Vote_Cast.xaml
    /// </summary>
    public partial class VoteCast : Window
    {
        //connect to database
        SqlConnection db_connection { get; set; }
        SqlCommand sql_command { get; set; }

        public VoteCast()
        {
            InitializeComponent();

            //initialize the db connection
            db_connection = new SqlConnection(MainWindow.connnection_string);
            sql_command = new SqlCommand();
            sql_command.Connection = db_connection;

            //List the offices here
            SidebarFIll();
        }

        public void SidebarFIll()
        {
            //grab the organization code 
            string code = VoteCastVerify.confirmed_org_code;

            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "SELECT * FROM offices INNER JOIN organizations ON  offices.organization = organizations.id   WHERE organizations.election_start = '1' AND organizations.organization_code = '" + code+"'";

            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);
            adapter.Fill(data);

            foreach (DataRow row in data.Rows)
            {
                Button btn = new Button();
                btn.Width = 200;
                btn.Height = 50;
                btn.Click += ButtonClicked;

                btn.Background = new SolidColorBrush(Colors.LightBlue);
                btn.Content = row["office_name"].ToString();
                btn.Tag = row["id"].ToString();
                btn.HorizontalAlignment = HorizontalAlignment.Left;

                LeftSidebar.Children.Add(btn);

            }
            db_connection.Close();

        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            string office_id = (sender as Button).Tag.ToString();
            string office_name = (sender as Button).Content.ToString();
            //Notify the voter
            display.Content = "Click On Party Of Choice To Vote For The Office Of:  " + office_name.ToUpper() ;


            //clear the contents of the center display(Centerbar)
            CenterMain.Children.Clear();
            //Fill the content based on click
            CenterbarFillfunction(office_id, office_name);
           
        }

        public void CenterbarFillfunction(string office_id, string office_name)
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "SELECT * FROM contestants INNER JOIN parties ON  contestants.party = parties.id   WHERE  contestants.office = '" + office_id + "'";
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);
            adapter.Fill(data);

            foreach (DataRow row in data.Rows)
            {
                Button btn = new Button();
                btn.Width = 200;
                btn.Height = 50;
                btn.Margin = new Thickness(16);
                //on click send the contestant ID as tag
                btn.Click += Voting;

                btn.Background = new SolidColorBrush(Colors.LightBlue);
                btn.Content = row["party_name"].ToString();
                btn.Tag = row["id"].ToString();
                btn.HorizontalAlignment = HorizontalAlignment.Left;

                CenterMain.Children.Add(btn);

            }
            db_connection.Close();

        }

        private void Voting(object sender, RoutedEventArgs e)
        {
            string contestantId = (sender as Button).Tag.ToString();

            //get the contestant details
            db_connection.Open();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "SELECT * FROM contestants  WHERE  id = '" + contestantId + "'";
            SqlDataReader result = sql_command.ExecuteReader();
            result.Read();

            //assign values to the values on the table
            var contestant_id = result["id"].ToString();
            var party_id = result["party"].ToString();
            var office_id = result["office"].ToString();
            var year_id = result["year"].ToString();
            var organization_code = VoteCastVerify.confirmed_org_code;

            db_connection.Close();
            //grab the logged in votes id
            var voter_id = Login.UserID;

            //check if the guy have voted
            db_connection.Open();
            sql_command.CommandText = "SELECT COUNT(user_id) FROM votes WHERE user_id ='" + voter_id + "'" +
                "AND organization_code ='" + organization_code + "' AND office_id ='" + office_id + "' ";
            Int32 Count = (Int32)sql_command.ExecuteScalar();
            db_connection.Close();

            if (Count < 1)
            {
                //inset the contestant details to the votes table
                db_connection.Open();
                sql_command.CommandType = CommandType.Text;
                DateTime Today = DateTime.Today;
                sql_command.CommandText = " INSERT INTO votes (user_id,contestant_id,organization_code,party_id,office_id,year_id,created_at)" +
                    " values ('" + voter_id + "','" + contestant_id + "','" + organization_code + "','" + party_id + "','" + office_id + "','" + year_id + "','" + Today + "')";
                sql_command.ExecuteNonQuery();


                MessageBox.Show("Vote Successfully Cast");
                db_connection.Close();
            }
            else{

                var Result = MessageBox.Show("You have already voted a candidate, Do you want this candidate to replace your previous vote?","Attention Please",MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(Result == MessageBoxResult.Yes)
                {

                    db_connection.Open();
                   sql_command.CommandText = "Update votes SET contestant_id='" + contestant_id + "',party_id='" + party_id + "' WHERE user_id ='" + voter_id + "'" +
                   "AND organization_code ='" + organization_code + "' AND office_id ='" + office_id + "' ";

                    sql_command.ExecuteNonQuery();
                    db_connection.Close();

                    MessageBox.Show("You changed your mind, and mordifications where made successfully","Info",MessageBoxButton.OK, MessageBoxImage.Information);
                   
                }
                else
                {

                    MessageBox.Show("No Mordification Made");
                }
            }

           
        }

        private void Log_out_Click(object sender, RoutedEventArgs e)
        {
            //clear section
            MainWindow.menu_action = 0;

            //redirect to login
            MainWindow Mainindow = new MainWindow();
            Mainindow.Show();
            this.Close();
        }
 
    }

}
