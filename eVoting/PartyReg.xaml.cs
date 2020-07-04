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
    /// Interaction logic for PartyReg.xaml
    /// </summary>
    public partial class PartyReg : Window
    {
        //connect to database
        SqlConnection db_connection { get; set; }
        SqlCommand sql_command { get; set; }
        int ID = 0;

        public PartyReg()
        {
            InitializeComponent();

            //initialize the db connection
            db_connection = new SqlConnection(MainWindow.connnection_string);
            sql_command = new SqlCommand();
            sql_command.Connection = db_connection;

            //display data
            DisplayData();
        }

        private void Party_reg_button_Click(object sender, RoutedEventArgs e)
        {
            if (party_name.Text == "" || party_slogan.Text == "" || party_vision.Text == "" || party_mission.Text == "")
            {
                MessageBox.Show("Please fill all fields");
            }
            else
            {
                db_connection.Open();
                DateTime Today = DateTime.Today;
                sql_command.CommandText = " INSERT INTO parties(party_name,party_logo,party_slogan,party_vision,party_mission,created_at)" +
                    " values ('" + party_name.Text + "','xxx','" + party_slogan.Text + "','" + party_vision.Text + "','" + party_mission.Text + "','" + Today + "')";
                sql_command.ExecuteNonQuery();
                db_connection.Close();


                MessageBox.Show("Party created successfully");
                party_reg_label.Content = "Party successfully created";
                DisplayData();
                ClearData();

            }
        }

        private void ClearData()
        {
            party_name.Text = "";
            party_slogan.Text = "";
            party_vision.Text = "";
            party_mission.Text = "";
            ID = 0;
        }

        private void PartyDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Party = "";

            try
            {
                object item = partyDataGrid.SelectedItem;
                party_name.Text = Party = (partyDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                party_slogan.Text = (partyDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                party_mission.Text = (partyDataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                party_vision.Text = (partyDataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                int.TryParse((partyDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text, out ID);
            }
            catch (Exception)
            {

            }
            finally
            {

                selected_item_label.Content = "Party:    " + Party + "  Selected";
            }



        }

        private void edit_button_Click(object sender, RoutedEventArgs e)
        {
            if (ID != 0 && !(party_name.Text == "" || party_slogan.Text == "") && !(party_vision.Text == "" || party_mission.Text == ""))
            {
                db_connection.Open();
                sql_command.CommandText = "Update parties SET party_name='" + party_name.Text + "',party_slogan='" + party_slogan.Text + "',party_vision='" + party_vision.Text + "',party_mission='" + party_mission.Text + "' where id=" + ID + "";
                sql_command.ExecuteNonQuery();
                db_connection.Close();

                MessageBox.Show("Party successfully updated");

                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Party to Edit");
            }

        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (ID != 0)
            {

                db_connection.Open();
                sql_command.CommandText = "Delete from parties where id= '" + ID + "'";
                sql_command.ExecuteNonQuery();
                db_connection.Close();

                MessageBox.Show("Party Deleted Successfully!");
                DisplayData();
                ClearData();

            }
            else
            {
                MessageBox.Show("Please Select Party to Delete");
            }
        }

        private void DisplayData()
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

            partyDataGrid.ItemsSource = data.DefaultView;
            db_connection.Close();
        }

        private void certify_button_Click(object sender, RoutedEventArgs e)
        {
            if (ID != 0 && !(party_name.Text == "" || party_slogan.Text == "") && !(party_vision.Text == "" || party_mission.Text == ""))
                {
                    //I am using another method to access the db
                    SqlCommand cmd = new SqlCommand(" Update parties set certified = '1' where id = @ID", db_connection);
                    db_connection.Open();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                    db_connection.Close();

                    MessageBox.Show("Party Certified For Election");

                    DisplayData();
                    ClearData();
                

            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void uncertify_button_Click(object sender, RoutedEventArgs e)
        {
            if (ID != 0 && !(party_name.Text == "" || party_slogan.Text == "") && !(party_vision.Text == "" || party_mission.Text == ""))
            {
                //I am using another method to access the db
                SqlCommand cmd = new SqlCommand(" Update parties set certified = '0' where id = @ID", db_connection);
                db_connection.Open();
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                db_connection.Close();

                MessageBox.Show("Party UnCertified For Election");

                DisplayData();
                ClearData();


            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }
    }
}
