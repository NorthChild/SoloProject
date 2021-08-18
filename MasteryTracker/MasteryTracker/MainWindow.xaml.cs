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
using MTBusiness;
using MasteryTracker.Views;

namespace MasteryTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MastTrackerLogic _mtLogic;

        public MainWindow()
        {
             InitializeComponent();
            _mtLogic = new MastTrackerLogic();
        }

            // set up data to measure
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // on previous kill command
            _mtLogic.SkillName = "";
            // save past years 
            _mtLogic.PastYears = 0;
            // save past weekly hrs
            _mtLogic.PastWeeklyHrs = 0;
            // save current weekly hrs
            _mtLogic.CurrWeeklyHrs = 0;

            var success1 = double.TryParse(tbxNum1.Text, out double num1);
            var success2 = double.TryParse(tbxNum2.Text, out double num2);
            var success3 = double.TryParse(tbxNum3.Text, out double num3);


            if (num1 >= 0 && num1 < 90 && num2 >= 0 && num2 < 168 && num3 > 0 && num3 < 168 && tbxNum1.Text != "TOTAL YRS" && tbxNum2.Text != "PAST HRS PER WEEK" && tbxNum3.Text != "CURRENT HRS PER WEEK")
            {
                // save skill name
                _mtLogic.SkillName = skillNmTbx.Text;
                // save past years 
                _mtLogic.PastYears = Convert.ToInt32(num1);
                // save past weekly hrs
                _mtLogic.PastWeeklyHrs = num2;
                // save current weekly hrs
                _mtLogic.CurrWeeklyHrs = num3;

                // for testing purpose
                var arrayRes = _mtLogic.CalculateMasteryProgress();


                // different output if user has already reached 10K

                if (Convert.ToInt32(arrayRes[1]) > 10000 || Convert.ToInt32(arrayRes[3]) > 100)
                {
                    // create and open new window and feed results to UI
                    Window7 window7 = new Window7();
                    window7.Show();
                    // display progress data 
                    window7.SkillNameRes.Text = arrayRes[0];

                    window7.totHrsSoFarResult.Content = arrayRes[1];
                    window7.currentYrlHrsRes.Content = arrayRes[2];
                    window7.currentProgrRes.Content = "MASTERY";
                    window7.estYrsMastRes.Content = "COMPLETED";

                    this.Close();
                }
                else
                {
                    //create and open new window and feed results to UI
                    Window7 window7 = new Window7();
                    window7.Show();
                    // display progress data 
                    window7.SkillNameRes.Text = arrayRes[0];
                    window7.totHrsSoFarResult.Content = arrayRes[1];
                    window7.currentYrlHrsRes.Content = arrayRes[2];
                    window7.currentProgrRes.Content = arrayRes[3] + $"%";
                    window7.estYrsMastRes.Content = arrayRes[4];

                    this.Close();
                }


            }
            else
            {
                lblResult.Content = "INVALID INPUT";
            }

        }

        private void Button_Click_DiscardSkill(object sender, RoutedEventArgs e)
        {
            Window5 window5 = new Window5();
            window5.Show();
            this.Close();
        }
    }





}
