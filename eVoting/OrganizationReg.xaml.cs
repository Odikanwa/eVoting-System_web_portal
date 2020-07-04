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
    /// Interaction logic for OrganizationReg.xaml
    /// </summary>
    public partial class OrganizationReg : Window
    {
        //connect to database
        SqlConnection db_connection { get; set; }
        SqlCommand sql_command { get; set; }
        int ID = 0;

        public OrganizationReg()
        {
            InitializeComponent();

            //initialize the db connection
            db_connection = new SqlConnection(MainWindow.connnection_string);
            sql_command = new SqlCommand();
            sql_command.Connection = db_connection;

            //Display Data
            DisplayData();
        }

        private void Organization_reg_button_Click(object sender, RoutedEventArgs e)
        {
            if (organization_name.Text == "" || organization_code.Text == "")
            {
                MessageBox.Show("All fields Cannot be Empty");
                org_reg_label.Content = "Please fill all fields";

            }
            else
            {
                db_connection.Open();
                DateTime Today = DateTime.Today;
                sql_command.CommandText = " INSERT INTO organizations(organization_name,organization_code) values ('" + organization_name.Text + "','" + organization_code.Text + "')";

                sql_command.ExecuteNonQuery();
                db_connection.Close();

                //MessageBox.Show("Year created successfully");
                org_reg_label.Content = "Organization Creation Successful";
                DisplayData();
                ClearData();

            }
        }

        private void ClearData()
        {
            organization_name.Text = "";
            organization_code.Text = "";

        }

        private void DisplayData()
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

            orgDataGrid.ItemsSource = data.DefaultView;
            db_connection.Close();
        }

        private void OrgDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Organization = "";

            try
            {
                object item = orgDataGrid.SelectedItem;
                organization_name.Text = Organization = (orgDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                organization_code.Text  = (orgDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                int.TryParse((orgDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text, out ID);
            }
            catch (Exception)
            {

            }
            finally
            {

                selected_item_label.Content = "Organization:    " + Organization + "  Selected";
            }



        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (ID != 0)
            {

                db_connection.Open();
                sql_command.CommandText = "Delete from organizations where id= '" + ID + "'";
                sql_command.ExecuteNonQuery();
                db_connection.Close();

                
                selected_item_label.Content = "Organization Deleted";
                DisplayData();
                ClearData();

            }
            else
            {
                MessageBox.Show("Please Select Organization to Delete");
            }
        }

        private void edit_button_Click(object sender, RoutedEventArgs e)
        {
            if (organization_name.Text != "" || organization_code.Text != "")
            {
                
               
                db_connection.Open();
                sql_command.CommandText = "Update organizations SET organization_name='" + organization_name.Text + "',organization_code='" + organization_code.Text + "' where id=" + ID + "";
                sql_command.ExecuteNonQuery();
                db_connection.Close();
                
                MessageBox.Show("Record Updated Successfully");

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
