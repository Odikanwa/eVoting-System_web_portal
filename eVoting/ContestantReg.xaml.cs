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


namespace eVoting
{
    /// <summary>
    /// Interaction logic for ContestantReg.xaml
    /// </summary>
    public partial class ContestantReg : Window
    {
        //connect to database
        SqlConnection db_connection = new SqlConnection(MainWindow.connnection_string);
        SqlCommand sql_command { get; set; }
        SqlDataAdapter adapter;
        int ID = 0;


        public ContestantReg()
        {
            InitializeComponent();

            //fill all the select tags(Combo boxes)
            FillPartyCombo();
            FillYearCombo();
            FillOrgCombo();

            //display data
            DisplayData();

        }

        private void Contestant_reg_button_Click(object sender, RoutedEventArgs e)
        {

            if (user_id.Text == "")
            {
                MessageBox.Show("Please fill all fields");
            }
            else
            {
                db_connection.Open();
                sql_command.CommandText = "SELECT COUNT(email) FROM users WHERE email ='" + user_id.Text + "'";
                Int32 Count = (Int32)sql_command.ExecuteScalar();
                db_connection.Close();

                if (Count < 1)
                {
                    MessageBox.Show("Invalid Contestant UserID submitted");
                }
                else
                {
                    try
                    {

                        db_connection.Open();
                        DateTime Today = DateTime.Today;
                        var party = ((ComboBoxItem)party_list.SelectedItem).Tag.ToString();
                        var office = ((ComboBoxItem)office_list.SelectedItem).Tag.ToString();
                        var year = ((ComboBoxItem)year_list.SelectedItem).Tag.ToString();


                        sql_command.CommandText = " INSERT INTO contestants([user],party,office,year,created_at) values ('" + user_id.Text + "','" + party + "','" + office + "','" + year + "','" + Today + "')";

                        sql_command.ExecuteNonQuery();
                        db_connection.Close();

                        MessageBox.Show("Contestnt successfully registered");
                        DisplayData();
                        ClearData();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please fill all fields");
                    }
                }
            }

           // MessageBox.Show(party_list.Text);
           // MessageBox.Show(((ComboBoxItem)party_list.SelectedItem).Tag.ToString());
        }

        public void FillPartyCombo()
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "select * from parties";
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            adapter = new SqlDataAdapter(sql_command);

            adapter.Fill(data);

            foreach (DataRow row in data.Rows)
            {
                //create a new combobox item;
                ComboBoxItem item = new ComboBoxItem();
                item.Content = row["party_name"].ToString();
                item.Tag = row["id"].ToString();

                party_list.Items.Add(item);
            }
            db_connection.Close();

        }

        public void FillOfficeCombo(string org)
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "select * from offices where organization = '" + org + "'";
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            adapter = new SqlDataAdapter(sql_command);

            adapter.Fill(data);
            //clear the Combombox
            office_list.Items.Clear();

            foreach (DataRow row in data.Rows)
            {
                // office_list.Items.Add(row["office_name"].ToString());
                //create a new combobox item;
                ComboBoxItem item = new ComboBoxItem();
                item.Content = row["office_name"].ToString();
                item.Tag = row["id"].ToString();

                office_list.Items.Add(item);
            }
            db_connection.Close();

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

        public void ClearData()
        {
            user_id.Text = "";
            ID = 0;
        }

        private void DisplayData()
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "SELECT * FROM contestants INNER JOIN users ON contestants.[user] = users.id" +
                " INNER JOIN parties ON contestants.[party] = parties.id " +
                "INNER JOIN offices ON contestants.[office] = offices.id " +
                "INNER JOIN years ON contestants.[year] = years.id";
            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);

            adapter.Fill(data);

            contestantDataGrid.ItemsSource = data.DefaultView;
            db_connection.Close();
        }

        private void ContestantDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Contestant = "";

            try
            {
                object item = contestantDataGrid.SelectedItem;
                Contestant = (contestantDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                user_id.Text = (contestantDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                int.TryParse((contestantDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text, out ID);
            }
            catch (Exception)
            {

            }
            finally
            {

                selected_item_label.Content = "Contestant:    " + Contestant + "  Selected";
            }



        }

        private void edit_button_Click(object sender, RoutedEventArgs e)
        {
            if (user_id.Text == "")
            {
                MessageBox.Show("Please fill all fields");
            }
            else
            {
                try
                {

                    db_connection.Open();
                    DateTime Today = DateTime.Today;
                    var party = ((ComboBoxItem)party_list.SelectedItem).Tag.ToString();
                    var office = ((ComboBoxItem)office_list.SelectedItem).Tag.ToString();
                    var year = ((ComboBoxItem)year_list.SelectedItem).Tag.ToString();

                    sql_command.CommandText = "Update contestants SET [user]='" + user_id.Text + "',party='" + party + "' ,office='" + office + "' ,year='" + year + "' where id=" + ID + "";
                  
                    sql_command.ExecuteNonQuery();
                    db_connection.Close();

                    MessageBox.Show("Contestnt successfully Updated");
                    DisplayData();
                    ClearData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please fill all fields");
                }
            }
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (ID != 0)
            {

                db_connection.Open();
                sql_command.CommandText = "Delete from contestants where id= '" + ID + "'";
                sql_command.ExecuteNonQuery();
                db_connection.Close();

                MessageBox.Show("Contestant Deleted Successfully!");
                DisplayData();
                ClearData();

            }
            else
            {
                MessageBox.Show("Please Select Contestant to Delete");
            }
        }

        private void Organization_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var org = ((ComboBoxItem)organization_list.SelectedItem).Tag.ToString();

                FillOfficeCombo(org);

            }
            catch (Exception)
            {

            }
        }
    }

}
