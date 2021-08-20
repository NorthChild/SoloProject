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
using MasteryTrackedDB;
using MasteryTracker;
using MasteryTracker.Views;
using MTBusiness;

namespace MasteryTracker.Views
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>

    public partial class Window2 : Window
    {

        UserManager userManager = new UserManager();

        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Window1 window1 = new Window1();
            window1.Show();
            this.Close();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            var username = userName.Text;
            var password = passWord.Text;
            var passwordRep = passwordRepeat.Text;

            var success = false;
            var passSuccess = false;

            // checking if username is taken or not
            using (var db = new SkillMasteryContext())
            {

                var query =
                    from i in db.Users
                    where i.UserName == username
                    select i;

                var counter = 0;

                foreach (var i in query) { counter++; }

                if (counter == 0)
                {
                    success = true;
                }
            }

            // checking pasword match
            if (password == passwordRep)
            {
                passSuccess = true;
            }

            if (success == false && passSuccess == true)
            {
                lblResult.Content = "USERNAME TAKEN";
            }
            else if (success == true && passSuccess == false)
            {
                lblResult.Content = "PASSWORDS DONT MATCH";
            }
            else if (success == true && passSuccess == true && userName.Text is null || passWord.Text is null || passwordRepeat is null || userName.Text == " " || userName.Text == "USER NAME")
            {
                lblResult.Content = "INVALID INPUT";
            }
            else if (success == true && passSuccess == true)
            {
                using (var db = new SkillMasteryContext())
                {

                    userManager.AddUser(username, password);
                    db.SaveChanges();
                }

                

                Window1 window1 = new Window1();
                window1.Show();
                var userIDpage2 = Convert.ToString(username);
                window1.UserIDtoStore1.Content = userIDpage2;
                this.Close();



            }

        }

        private void exitAppBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
