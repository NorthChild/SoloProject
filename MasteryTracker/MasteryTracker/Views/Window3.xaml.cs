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
using MasteryTracker.Views;
using MTBusiness;

namespace MasteryTracker.Views
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
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

            

            using (var db = new SkillMasteryContext())
            {

                var userNameLogDet = userNameLogin.Text;
                var passLogin = passWordLogin.Text;

                var queryUserNameAndPass =
                    from i in db.Users
                    where i.UserName == userNameLogDet && i.Password == passLogin
                    select i;

                var counter = 0;

                foreach (var i in queryUserNameAndPass) { counter++; }

                if (counter == 0)
                {
                    lblResult.Content = "NO USER NAME WITH THAT PASSWORD FOUND";
                }
                else
                {
                    //check against db for userName and password
                    Window4 window4 = new Window4();
                    window4.Show();

                    var userIDpage3 = Convert.ToString(userNameLogDet);
                    window4.UserIDtoStore4.Content = userIDpage3;

                    this.Close();
                }

           

            }


        }

        private void exitAppBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
