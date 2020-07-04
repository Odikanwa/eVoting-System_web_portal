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
    /// Interaction logic for MenuHeader.xaml
    /// </summary>
    public partial class MenuHeader : UserControl
    {
        public MenuHeader()
        {
            InitializeComponent();

            //welcome the user
            current_user.Content = "Welcome  " + Login.UserName;
        }


        private void Home_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            Dashboard Dashboard = new Dashboard();
            Dashboard.Show();
            Window.GetWindow(this).Close();

           
        }

        private void Year_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            YearReg Year = new YearReg();
            Year.Show();
            Window.GetWindow(this).Close();
        }

        private void Offices_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            OfficeReg Office = new OfficeReg();
            Office.Show();
            Window.GetWindow(this).Close();
        }


        private void Contestants_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            ContestantReg Contestant = new ContestantReg();
            Contestant.Show();
            Window.GetWindow(this).Close();
        }

        private void Parties_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            PartyReg Party = new PartyReg();
            Party.Show();
            Window.GetWindow(this).Close();
        }

        private void Voters_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            Voters Voters = new Voters();
            Voters.Show();
            Window.GetWindow(this).Close();
        }

        private void Organizations_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            OrganizationReg Organization = new OrganizationReg();
            Organization.Show();
            Window.GetWindow(this).Close();
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
