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
using MTBusiness;
using MasteryTracker.Views;
using MasteryTrackedDB;
using MasteryTracker;

namespace MasteryTracker
{
    /// <summary>
    /// Interaction logic for Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {

        UserManager userManager = new UserManager();

        public Window7()
        {
            InitializeComponent();
        }

        private void Button_ClickSAVE(object sender, RoutedEventArgs e)
        {
            
            var userIDToLink = UserIDtoStore7.Content;
            int userIDFinal = 0;


            // add the skill info to the DB
            string skillName = Convert.ToString(SkillNameRes.Text);
            string totHrsSoFarRes = Convert.ToString(totHrsSoFarResult.Content);
            string currentYrlHrsR = Convert.ToString(currentYrlHrsRes.Content);
            string currentProgRe = Convert.ToString(currentProgrRes.Content);
            string estYrsMasRe = Convert.ToString(estYrsMastRes.Content);

            using (var db = new SkillMasteryContext())
            {

                // find obj associated with userID
                var userIdQuery =
                from i in db.Users
                where i.UserName == userIDToLink
                select i.UsersID;

                //int userIDFinal = 0;

                foreach (var i in userIdQuery)
                {
                    userIDFinal += i;
                }

                userManager.AddSKill(userIDFinal, skillName, totHrsSoFarRes, currentYrlHrsR, currentProgRe, estYrsMasRe);
                db.SaveChanges();

            }

            Window8 window8 = new Window8();
            window8.Show();

            window8.UserIDtoStore8.Content = userIDToLink;
            this.Close();




        }

        private void Button_Click_1KILL(object sender, RoutedEventArgs e)
        {
            MainWindow Mainwindow = new MainWindow();
            Mainwindow.Show();
            this.Close();
        }

        private void Button_ClickSUBSKILL(object sender, RoutedEventArgs e)
        {
            Window9 window9 = new Window9();
            window9.Show();

            var userIDpage7 = Convert.ToString(UserIDtoStore7.Content);
            var percetangeToAttribute = Convert.ToString(currentProgrRes.Content);

            window9.UserIDtoStore9.Content = userIDpage7;
            window9.totalPercentageCalculated.Text = percetangeToAttribute; 

            this.Close();
        }

        private void exitAppBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
