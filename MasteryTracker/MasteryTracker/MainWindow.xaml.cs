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
            var success1 = double.TryParse(tbxNum1.Text, out double num1);
            var success2 = double.TryParse(tbxNum2.Text, out double num2);
            var success3 = double.TryParse(tbxNum3.Text, out double num3);


            if (num1 >= 0 && num1 < 100 && num2 >= 0 && num2 < 168 && num3 >= 0 && num3 < 168)
            {
                // save skill name
                _mtLogic.SkillName = skillNmTbx.Text;
                // save past years 
                _mtLogic.PastYears = Convert.ToInt32(num1);
                // save past weekly hrs
                _mtLogic.PastWeeklyHrs = num2;
                // save current weekly hrs
                _mtLogic.CurrWeeklyHrs = num3;

                // for testing reasons
                //lblResult.Content = "DONE";
                // for testing reasons

                // measure progress
                //_mtLogic.CalculateMasteryProgress();



                // for testing purpose
                var arrayRes = _mtLogic.CalculateMasteryProgress();

                lblResult.Content = $"{_mtLogic.SkillName}: {arrayRes[0]}, {arrayRes[1]}, {arrayRes[2]}, {arrayRes[3]}";
            }
            else
            {
                lblResult.Content = "INVALID INPUT";
            }


            


        }


    }





}
