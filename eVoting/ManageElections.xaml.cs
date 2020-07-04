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
    /// Interaction logic for ManageElections.xaml
    /// </summary>
    public partial class ManageElections : Window
    {
        //connect to database
        SqlConnection db_connection = new SqlConnection(MainWindow.connnection_string);
        SqlCommand sql_command { get; set; }
        SqlDataAdapter adapter;
        int ID = 0;

        public ManageElections()
        {
            InitializeComponent();

            //fill data
            FillYearCombo();
            FillOrgCombo();

            //display data
            DisplayData();
        }

    

        private void Election_start_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                db_connection.Open();
               
                var org = ((ComboBoxItem)organization_list.SelectedItem).Tag.ToString();
                var year = ((ComboBoxItem)year_list.SelectedItem).Tag.ToString();

                sql_command.CommandText = "Update organizations SET election_start = 1 ,current_election_year='" + year + "' where id=" + org + "";
                sql_command.ExecuteNonQuery();

                db_connection.Close();

                MessageBox.Show("Election Successfully Started");
                DisplayData();
               
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all fields");
            }
        }

        private void ElectionDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Election = "";

            try
            {
                object item = electionDataGrid.SelectedItem;
                Election = (electionDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
          
                int.TryParse((electionDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text, out ID);
            }
            catch (Exception)
            {

            }
            finally
            {

                selected_item_label.Content = "Election:    " + Election + "  Selected";
            }



        }


        public void FillYearCombo()
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "select * from years";
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            adapter = new SqlDataAdapter(sql_command);

            adapter.Fill(data);

            foreach (DataRow row in data.Rows)
            {
                //year_list.Items.Add(row["year_name"].ToString());
                //create a new combobox item;
                ComboBoxItem item = new ComboBoxItem();
                item.Content = row["year_name"].ToString();
                item.Tag = row["id"].ToString();

                year_list.Items.Add(item);

            }
            db_connection.Close();

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
            adapter = new SqlDataAdapter(sql_command);

            adapter.Fill(data);

            foreach (DataRow row in data.Rows)
            {
                //year_list.Items.Add(row["year_name"].ToString());
                //create a new combobox item;
                ComboBoxItem item = new ComboBoxItem();
                item.Content = row["organization_name"].ToString();
                item.Tag = row["id"].ToString();

                organization_list.Items.Add(item);

            }
            db_connection.Close();

        }

        private void DisplayData()
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "SELECT * FROM organizations INNER JOIN years ON organizations.current_election_year = years.id  WHERE organizations.election_start = '1'";
              
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);

            adapter.Fill(data);

            electionDataGrid.ItemsSource = data.DefaultView;
            db_connection.Close();

        }

        private void Election_end_button_Click(object sender, RoutedEventArgs e)
        {
            if (ID != 0)
            {

                db_connection.Open();
             
                sql_command.ExecuteNonQuery();
             
                sql_command.CommandText = "Update organizations SET election_start = '0'  WHERE id=" + ID + "";
                sql_command.ExecuteNonQuery();
                db_connection.Close();
                MessageBox.Show("Election Stopped Successfully!");
                DisplayData();
               
            }
            else
            {
                MessageBox.Show("Please Select an Election to Stop");
            }
        }
    }
}
