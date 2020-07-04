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
    /// Interaction logic for ResultCast.xaml
    /// </summary>
    public partial class ResultCast : Window
    {
        //connect to database
        SqlConnection db_connection { get; set; }
        SqlCommand sql_command { get; set; }
        //grab the organization code 
        string code = VoteCastVerify.confirmed_org_code;

        public ResultCast()
        {
            InitializeComponent();


            //initialize the db connection
            db_connection = new SqlConnection(MainWindow.connnection_string);
            sql_command = new SqlCommand();
            sql_command.Connection = db_connection;

            //List the offices here
            SidebarFIll();
        }

        public void SidebarFIll()
        { 
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "SELECT * FROM offices INNER JOIN organizations ON  offices.organization = organizations.id  WHERE organizations.organization_code = '" + code + "'";

            sql_command.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);
            adapter.Fill(data);

            foreach (DataRow row in data.Rows)
            {
                Button btn = new Button();
                btn.Width = 200;
                btn.Height = 50;
                btn.Click += ButtonClicked;

                btn.Background = new SolidColorBrush(Colors.LightBlue);
                btn.Content = row["office_name"].ToString();
                btn.Tag = row["id"].ToString();
                btn.HorizontalAlignment = HorizontalAlignment.Left;

                LeftSidebar.Children.Add(btn);

            }
            db_connection.Close();

        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            string office_id = (sender as Button).Tag.ToString();
            string office_name = (sender as Button).Content.ToString();
            //Notify the voter
            display.Content = "Summary for Nuesa Elections: Office of the :  " + office_name.ToUpper();


            //clear the contents of the center display(Centerbar)
            CenterMain.Children.Clear();
            //Fill the content based on click
            CenterbarFillfunction(office_id, office_name);

        }

        public void CenterbarFillfunction(string office_id, string office_name)
        {
            //initialize the db connection
            db_connection.Open();
            sql_command = db_connection.CreateCommand();
            sql_command.CommandType = CommandType.Text;
            sql_command.CommandText = "SELECT * FROM contestants INNER JOIN parties ON  contestants.party = parties.id   WHERE  contestants.office = '" + office_id + "'";
            sql_command.ExecuteNonQuery();


            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_command);
            adapter.Fill(data);
            db_connection.Close();

            foreach (DataRow row in data.Rows)
            {
                var contestant_id = row["id"].ToString();
                //count the votes, each contestant/party g
                db_connection.Open();
                sql_command.CommandText = "SELECT COUNT(contestant_id) FROM votes WHERE organization_code ='" + code + "' AND  contestant_id ='" + contestant_id + "' AND office_id = '" + office_id + "'";
                Int32 Count = (Int32)sql_command.ExecuteScalar();
                db_connection.Close();

                //Create a button to display the votes
                Button btn = new Button();
                btn.Width = 200;
                btn.Height = 50;
                btn.Margin = new Thickness(16);
                btn.Background = new SolidColorBrush(Colors.Plum);
                btn.Content =  Count + "  Votes";
                btn.HorizontalAlignment = HorizontalAlignment.Left;
                btn.FontWeight = FontWeights.Heavy;
                btn.FontSize = 15;

                //create a Label for the party name
                Label label = new Label()
                {
                    Content = row["party_name"].ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Height = 30,
                    FontSize = 16, 
                    FontWeight = FontWeights.Bold,

                };

                label.Margin = new Thickness(5);

                //create a stack panel to help in alignment
                StackPanel miniPanel = new StackPanel() { Orientation = Orientation.Vertical, Background= Brushes.White };
                miniPanel.Margin = new Thickness(5);
                miniPanel.Children.Add(label);
                miniPanel.Children.Add(btn);

                //add in the main panel
                CenterMain.Children.Add(miniPanel);

            }
            //db_connection.Close();

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

        private void Offices_Click(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
