using System;
using System.Collections.Generic;
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
    /// Interaction logic for VoteCastVerify.xaml
    /// </summary>
    public partial class VoteCastVerify : Window
    {
        //connect to database
        SqlConnection db_connection { get; set; }
        SqlCommand sql_command { get; set; }
        int ID = 0;

        public static string confirmed_org_code = "";

        public VoteCastVerify()
        {
            InitializeComponent();

            //initialize the db connection
            db_connection = new SqlConnection(MainWindow.connnection_string);
            sql_command = new SqlCommand();
            sql_command.Connection = db_connection;

            //set the display label

            if(MainWindow.voter_action == 1)
            {
                verify_reg_label.Content = "Enter Organization Code to Vote";
            }
            else
            {
                verify_reg_label.Content = "Enter Organization Code to View Results";
            }

        }

        private void Verify_button_Click(object sender, RoutedEventArgs e)
        {
            if (org_code.Text == "")
            {
                MessageBox.Show("Election Year Cannot be Empty");
                verify_reg_label.Content = "Please fill all fields";

            }
            else
            {
                db_connection.Open();
                sql_command.CommandText = "SELECT COUNT(organization_code) FROM organizations WHERE organization_code ='" + org_code.Text + "'";
                Int32 Count = (Int32)sql_command.ExecuteScalar();
                db_connection.Close();

                if (Count > 0)
                {
                    //set the confirmation code
                    confirmed_org_code = org_code.Text;

                    if(MainWindow.voter_action == 1)
                    {
                        VoteCast Voting = new VoteCast();
                        Voting.Show();
                        this.Close();
                    }
                    else
                    {
                        ResultCast Result = new ResultCast();
                        Result.Show();
                        this.Close();
                    }
        
                }
                else
                {
                    MessageBox.Show("Invalid Organization Code Entered!");
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
            Window.GetWindow(this).Close();
        }
    }
}
