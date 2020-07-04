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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection db_connection { get; set; }
        SqlCommand sql_command { get; set; }
        public static string UserName = null;
        public static Int32 UserID;

        public Login()
        {
            InitializeComponent();

            //initialize the db connection
            db_connection = new SqlConnection(MainWindow.connnection_string);
            sql_command = new SqlCommand();
            sql_command.Connection = db_connection;


            //catch the action initially specified
            if (MainWindow.menu_action == 1)
            {
                login_label.Content = "Voters' Login";
            }
            else if (MainWindow.menu_action == 2)
            {
                login_label.Content = "Admin: Register Voters";
            }
            else if (MainWindow.menu_action == 3)
            {
                login_label.Content = "Admin: System Setup";
            }
            else
            {
                login_label.Content = "Election Results";
            }
        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {

            //catch the action initially specified
            if (MainWindow.menu_action == 1)
            {

                //validate his details to cast vote
                string password_hashed = VoterReg.PasswordHash(password.Text);
                //validate his detail
                db_connection.Open();
                sql_command.CommandText = "SELECT COUNT(email) FROM users WHERE email ='" + user_id.Text + "'AND finger_print ='" + VoterReg.fingerPrintTemplate + "' AND password = '" + password_hashed + "'";
                Int32 Count = (Int32)sql_command.ExecuteScalar();
                db_connection.Close();

                if (Count < 1)
                {
                    MessageBox.Show("Invalid Credentials submitted");
                }
                else
                {
                    //set user
                    UserName = LoggedInUserName(user_id.Text);
                    //redirect the the right page
                    MainWindow.voter_action = 1;
                    VoteCastVerify Voting = new VoteCastVerify();
                    Voting.Show();
                    this.Close();
                }
            }
            else if (MainWindow.menu_action == 2)
            {
                string password_hashed = VoterReg.PasswordHash(password.Text);
                //validate his detail
                db_connection.Open();
                //sql_command.CommandText = "SELECT COUNT(email) FROM users WHERE finger_print ='" + VoterReg.fingerPrintTemplate + "' ";
                sql_command.CommandText = "SELECT COUNT(email) FROM users WHERE email ='" + user_id.Text + "' AND password = '"+ password_hashed + "'AND finger_print ='" + VoterReg.fingerPrintTemplate + "' AND role = 'admin'";
                Int32 Count = (Int32)sql_command.ExecuteScalar();
                db_connection.Close();

                if (Count < 1)
                {
                    MessageBox.Show("Invalid Credentials submitted");
                }
                else
                {
                    //set user
                    UserName = LoggedInUserName(user_id.Text);
                    //redirect the the right page
                    VoterReg voterReg = new VoterReg();
                    voterReg.Show();
                    this.Close();
                }
            }
            else if (MainWindow.menu_action == 3)
            {
                //validate his details
                string password_hashed = VoterReg.PasswordHash(password.Text);
                //validate his detail
                db_connection.Open();
                sql_command.CommandText = "SELECT COUNT(email) FROM users WHERE email ='" + user_id.Text + "' AND password = '" + password_hashed + "'AND finger_print ='" + VoterReg.fingerPrintTemplate + "' AND role = 'admin'";
                Int32 Count = (Int32)sql_command.ExecuteScalar();
                db_connection.Close();

                if (Count < 1)
                {
                    MessageBox.Show("Invalid Credentials submitted");
                }
                else
                {
                    //set user
                    UserName = LoggedInUserName(user_id.Text);
                    //redirect the the right page
                    Dashboard Dashboard = new Dashboard();
                    Dashboard.Show();
                    this.Close();
                }

            }
            else if (MainWindow.menu_action == 4)
            {
                //validate his details, to view election results
                string password_hashed = VoterReg.PasswordHash(password.Text);
                //validate his detail
                db_connection.Open();
                sql_command.CommandText = "SELECT COUNT(email) FROM users WHERE email ='" + user_id.Text + "'AND finger_print ='" + VoterReg.fingerPrintTemplate + "' AND password = '" + password_hashed + "'";
                Int32 Count = (Int32)sql_command.ExecuteScalar();
                db_connection.Close();

                if (Count < 1)
                {
                    MessageBox.Show("Invalid Credentials submitted");
                }
                else
                {
                    //set user
                    UserName = LoggedInUserName(user_id.Text);
                    //redirect the the right page
                    MainWindow.voter_action = 4;
                    VoteCastVerify Voting = new VoteCastVerify();
                    Voting.Show();
                    this.Close();
                }

            }

        }


        public void Log_out_Click(object sender, RoutedEventArgs e)
        {
            //clear section
            MainWindow.menu_action = 0;

            //redirect to login
            MainWindow Mainindow = new MainWindow();
            Mainindow.Show();
            Window.GetWindow(this).Close();
        }

        public string LoggedInUserName(string email)
        {
            //get the contestant details
            db_connection.Open();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "SELECT * FROM users  WHERE  email = '" + email + "'";
            SqlDataReader result = sql_command.ExecuteReader();
            result.Read();

            //assign values to the values on the table
            var User = result["first_name"].ToString();
            int.TryParse(result["id"].ToString(), out UserID);
            db_connection.Close();
            return User;
        }

        private void Login_Finger_Sample_Click(object sender, RoutedEventArgs e)
        {
            FingerReg Capture_Finger = new FingerReg();
            Capture_Finger.Show();
        }
    }
}
