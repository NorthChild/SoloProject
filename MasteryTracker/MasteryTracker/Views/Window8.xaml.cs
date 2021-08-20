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
    /// Interaction logic for Window8.xaml
    /// </summary>
    public partial class Window8 : Window
    {
        public Window8()
        {
            InitializeComponent();


            using (var db = new SkillMasteryContext())
            {

                //var query =
                //    from i in db.Users
                //    select i;
                //var query2 = query.ToArray();

                //foreach (var i in query) 
                //{
                //    // populate list
                //}


            }

        }

        private void Button_ClickSAVE(object sender, RoutedEventArgs e)
        {
            Window4 window4 = new Window4();
            window4.Show();

            var userIDpage8 = Convert.ToString(UserIDtoStore8.Content);
            window4.UserIDtoStore4.Content = userIDpage8;

            this.Close();
        }

        private void exitAppBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
