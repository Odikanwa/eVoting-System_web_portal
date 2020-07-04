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
using System.Windows.Shapes;

namespace eVoting
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Year_button_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            YearReg YearReg = new YearReg();
            YearReg.Show();
            this.Close();
        }

        private void Party_button_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            PartyReg PartyReg = new PartyReg();
            PartyReg.Show();
            this.Close();
        }

        private void Office_button_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            OfficeReg OfficeReg = new OfficeReg();
            OfficeReg.Show();
            this.Close();
        }

        private void Contestant_button_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            ContestantReg ContestantReg = new ContestantReg();
            ContestantReg.Show();
            this.Close();
        }

       

        private void Voters_button_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            Voters Voters = new Voters();
            Voters.Show();
            this.Close();
        }

        private void Organization_button_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            OrganizationReg Organization = new OrganizationReg();
            Organization.Show();
            this.Close();
        }

        private void Election_button_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            ManageElections ManageElection = new ManageElections();
            ManageElection.Show();
            this.Close();
        }

        private void Synchronize_Click(object sender, RoutedEventArgs e)
        {
            //redirect the the right page
            Synchronize Synchronize = new Synchronize();
            Synchronize.Show();
            this.Close();
        }

        private void Log_out_Click(object sender, RoutedEventArgs e)
        {
            //clear session
            MainWindow.menu_action = 0;

            //redirect to login
            MainWindow Mainindow = new MainWindow();
            Mainindow.Show();
            Window.GetWindow(this).Close();
        }

    }
}
