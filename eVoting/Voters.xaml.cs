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
    /// Interaction logic for Voters.xaml
    /// </summary>
    public partial class Voters : Window
    {
        //connect to database
        SqlConnection db_connection { get; set; }
        SqlCommand sql_command { get; set; }
        int ID = 0;

        public Voters()
        {
            InitializeComponent();
            //initialize the db connection
            db_connection = new SqlConnection(MainWindow.connnection_string);
            sql_command = new SqlCommand();
            sql_command.Connection = db_connection;

            //display data
            DisplayData();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (ID != 0)
            {

                db_connection.Open();
                sql_command.CommandText = "Delete from users where id= '" + ID + "'";
                sql_command.ExecuteNonQuery();
                db_connection.Close();

                MessageBox.Show("Voter Deleted Successfully!");
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
            sql_command.CommandText = "select * from users";
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);

            adapter.Fill(data);

            voterDataGrid.ItemsSource = data.DefaultView;
            db_connection.Close();
        }

        private void VoterDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Voter = "";

            try
            {
                object item = voterDataGrid.SelectedItem;             
                int.TryParse((voterDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text, out ID);
            }
            catch (Exception)
            {

            }
            finally
            {

                selected_item_label.Content = "Voter:    " + ID + "  Selected";
            }



        }

        private void ClearData()
        {
          
            ID = 0;
        }


    }
}
