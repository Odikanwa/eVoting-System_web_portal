using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for VoterReg.xaml
    /// </summary>
    public partial class VoterReg : Window
    {
        //connect to database
        SqlConnection db_connection { get; set; }
        SqlCommand sql_command { get; set; }

        //Finger print byte sample
        public static byte[] fingerPrintTemplate = null;

        public VoterReg()
        {
            InitializeComponent();

            //initialize the db connection
            db_connection = new SqlConnection(MainWindow.connnection_string);
            sql_command = new SqlCommand();
            sql_command.Connection = db_connection;

        }

        private void Register_button_Click(object sender, RoutedEventArgs e)
        {
            if (first_name.Text == "" || last_name.Text == "" || phone.Text == "" || email.Text == "" || lga.Text == "" || dob.Text == "" || state.Text == "" || password.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                //voter_reg_label.Content = "Please fill all fields";
            }
            else if(fingerPrintTemplate == null){

                MessageBox.Show("Voter Finger Samplemust be captured!");
            }
            else
            {
                //check if this given email already exist
                db_connection.Open();
                sql_command.CommandText = "SELECT COUNT(email) FROM users WHERE email ='" + email.Text + "'";
                Int32 Count = (Int32)sql_command.ExecuteScalar();
                db_connection.Close();

                if (Count > 0)
                {
                    MessageBox.Show("User already registered with that Email");
                }
                else
                {
                    string password_hash = PasswordHash(password.Text);
                    db_connection.Open();
                    DateTime Today = DateTime.Today;
                    sql_command.CommandText = " INSERT INTO users(first_name,last_name,date_of_birth,lga,state,phone,email,password,finger_print,role)" +
                        " values ('" + first_name.Text + "','" + last_name.Text + "','" + Today + "','" + lga.Text + "','" + state.Text + "','" + phone.Text + "','" + email.Text + "','" + password_hash + "','"+ fingerPrintTemplate + "','voter')";
                    sql_command.ExecuteNonQuery();
                    db_connection.Close();

                    MessageBox.Show("User successfully created");
                    ClearData();
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

        private void ClearData()
        {

            first_name.Text = last_name.Text = phone.Text = email.Text = lga.Text = dob.Text = state.Text = password.Text = "";
            
        }

        private void View_Voters_Click(object sender, RoutedEventArgs e)
        {
            //redirect to voters page
            Voters Voters = new Voters();
            Voters.Show();
            this.Close();
        }

        public static string PasswordHash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        private void Register_finger_Click(object sender, RoutedEventArgs e)
        {
            FingerReg Capture_Finger = new FingerReg();
            Capture_Finger.Show();
            //this.Close();
        }
    }
}
