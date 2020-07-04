using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eVoting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //configure vital parameters
        public static int menu_action = 0;
        public static int voter_action = 0;

        public static string connnection_string = "Data Source=VITALIS;Initial Catalog = evoting;Integrated Security=True; MultipleActiveResultSets=true;";
        
        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void Cast_vote_Click(object sender, RoutedEventArgs e)
        {
            menu_action = 1;
            Login();
        }

        private void Register_users_Click(object sender, RoutedEventArgs e)
        {
            menu_action = 2;
            Login();
        }

        private void System_setup_Click(object sender, RoutedEventArgs e)
        {
            menu_action = 3;
            Login();
        }

        private void Election_results_Click(object sender, RoutedEventArgs e)
        {
            menu_action = 4;
            Login();
        }

        private void Login()
        {
            //open the user login
            Login Login = new Login();
            Login.Show();
            this.Close();
        }

       
    }
}
