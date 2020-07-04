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
    /// Interaction logic for OfficeReg.xaml
    /// </summary>
    public partial class OfficeReg : Window
    {
        //connect to database
        SqlConnection db_connection { get; set; }
        SqlCommand sql_command { get; set; }
        int ID = 0;

        public OfficeReg()
        {
            InitializeComponent();

            //initialize the db connection
            db_connection = new SqlConnection(MainWindow.connnection_string);
            sql_command = new SqlCommand();
            sql_command.Connection = db_connection;

            //Display Data
            DisplayData();
            FillOrgCombo();
        }

        private void office_reg_button_Click(object sender, RoutedEventArgs e)
        {
            if (office_name.Text == "" || office_description.Text == "")
            {
                MessageBox.Show("Please fill all fields");
            }
            else
            {
                try
                {
                    var organization = ((ComboBoxItem)org_list.SelectedItem).Tag.ToString();

                    db_connection.Open();
                    DateTime Today = DateTime.Today;
                    sql_command.CommandText = " INSERT INTO offices(office_name,office_description,organization,office_image,created_at)" +
                        " values ('" + office_name.Text + "','" + office_description.Text + "','" + organization + "','xxx','" + Today + "')";
                    sql_command.ExecuteNonQuery();
                    db_connection.Close();

                    MessageBox.Show("Office created successfully");
                    office_reg_label.Content = "Office successfully created";
                    DisplayData();
                    ClearData();

                }
                catch(Exception)
                {
                    MessageBox.Show("Please Fill all fields");
                }
            }
        }

        private void ClearData()
        {
            
            office_name.Text = "";
            office_description.Text = "";
        }

        private void DisplayData()
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "select * from offices INNER JOIN organizations ON offices.organization = organizations.id";
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);

            adapter.Fill(data);

            officeDataGrid.ItemsSource = data.DefaultView;
            db_connection.Close();
        }

        private void OfficeDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Office = "";

            try
            {
                object item = officeDataGrid.SelectedItem;
                office_name.Text = Office = (officeDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                office_description.Text = (officeDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                int.TryParse((officeDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text, out ID);
            }
            catch (Exception)
            {

            }
            finally
            {

                selected_item_label.Content = "Office:    " + Office + "  Selected";
            }



        }


        private void edit_button_Click(object sender, RoutedEventArgs e)
        {
            if (ID != 0 && !(office_name.Text == "" || office_description.Text == ""))
            {
                db_connection.Open();
                sql_command.CommandText = "Update offices SET office_name='" + office_name.Text + "',office_description='" + office_description.Text + "' where id=" + ID + "";
                sql_command.ExecuteNonQuery();
                db_connection.Close();

                MessageBox.Show("Office successfully updated");

                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Office to Edit");
            }
        }


        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (ID != 0)
            {

                db_connection.Open();
                sql_command.CommandText = "Delete from offices where id= '" + ID + "'";
                sql_command.ExecuteNonQuery();
                db_connection.Close();

                //MessageBox.Show("Contestant Deleted Successfully!");
                selected_item_label.Content = "Selected Office Deleted";
                DisplayData();
                ClearData();

            }
            else
            {
                MessageBox.Show("Please Select Office to Delete");
            }
        }

        public void FillOrgCombo()
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

            foreach (DataRow row in data.Rows)
            {
                //year_list.Items.Add(row["year_name"].ToString());
                //create a new combobox item;
                ComboBoxItem item = new ComboBoxItem();
                item.Content = row["organization_name"].ToString();
                item.Tag = row["id"].ToString();

                org_list.Items.Add(item);

            }
            db_connection.Close();

        }
    }
}
