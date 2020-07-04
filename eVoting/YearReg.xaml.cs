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
    /// Interaction logic for YearReg.xaml
    /// </summary>
    public partial class YearReg : Window
    {
        //connect to database
        SqlConnection db_connection { get; set; }
        SqlCommand sql_command { get; set; }
        int ID = 0;

        public YearReg()
        {
            InitializeComponent();

            //initialize the db connection
            db_connection = new SqlConnection(MainWindow.connnection_string);
            sql_command = new SqlCommand();
            sql_command.Connection = db_connection;

            //Display Data
            DisplayData();
        }

        private void Year_button_Click(object sender, RoutedEventArgs e)
        {
            
            if (year.Text == "")
            {
                MessageBox.Show("Election Year Cannot be Empty");
                year_reg_label.Content = "Please fill all fields";

            }
            else
            {
                db_connection.Open();
                DateTime Today = DateTime.Today;
                sql_command.CommandText = " INSERT INTO years(year_name,is_current,created_at) values ('" + year.Text + "','0','" + Today + "')";

                sql_command.ExecuteNonQuery();
                db_connection.Close();

                //MessageBox.Show("Year created successfully");
                year_reg_label.Content = "Year Creation Successful";
                DisplayData();
                ClearData();

            }

        }


        private void ClearData()
        {
            year.Text = "";

        }

        private void DisplayData()
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

            yearDataGrid.ItemsSource = data.DefaultView;
            db_connection.Close();
        }

        private void YearDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Year = "";
           
            try{
                object item = yearDataGrid.SelectedItem;
                year.Text =Year = (yearDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                int.TryParse((yearDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text, out ID);
            }
            catch (Exception)
            {

            }
            finally
            {

                selected_item_label.Content = "Year:    " + Year + "  Selected";
            }
           

           
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (ID != 0)
            {

                db_connection.Open();
                sql_command.CommandText = "Delete from years where id= '" + ID + "'";
                sql_command.ExecuteNonQuery();
                db_connection.Close();

                //MessageBox.Show("Contestant Deleted Successfully!");
                selected_item_label.Content = "Selected Year Deleted";
                DisplayData();
                ClearData();

            }
            else
            {
                MessageBox.Show("Please Select Year to Delete");
            }
        }

        private void edit_button_Click(object sender, RoutedEventArgs e)
        {
            if (year.Text != "")
            {

                //I am using another method to access the db
                SqlCommand cmd = new SqlCommand(" Update years set year_name = @ElectionYear where id = @ID", db_connection);
                db_connection.Open();
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@ElectionYear", year.Text);
                cmd.ExecuteNonQuery();

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

        private void current_button_Click(object sender, RoutedEventArgs e)
        {
            if (year.Text != "")
            {
                try
                {
                    //Remove the old election date
                    SqlCommand cmd = new SqlCommand(" Update years set is_current = '0' where is_current = '1'", db_connection);
                    db_connection.Open();
                    cmd.ExecuteNonQuery();
                    db_connection.Close();
                }
                finally
                {
                    //I am using another method to access the db
                    SqlCommand cmd = new SqlCommand(" Update years set is_current = '1' where id = @ID", db_connection);
                    db_connection.Open();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                    db_connection.Close();

                    MessageBox.Show("Current Year Successfully Set");

                    DisplayData();
                    ClearData();
                }
               
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }
    }
}
