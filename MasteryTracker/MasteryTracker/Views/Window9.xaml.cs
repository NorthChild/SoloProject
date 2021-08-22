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
using MTBusiness;

namespace MasteryTracker.Views
{
    /// <summary>
    /// Interaction logic for Window9.xaml
    /// </summary>
    public partial class Window9 : Window
    {

        UserManager _userManager = new UserManager();

        public Window9()
        {
            InitializeComponent();

            var userNameID = UserIDtoStore9.Content;
        }

        private void Button_ClickExitSubSkill(object sender, RoutedEventArgs e)
        {
            Window8 window8 = new Window8();
            var userIDpage9 = Convert.ToString(UserIDtoStore9.Content);
            window8.UserIDtoStore8.Content = userIDpage9;
            window8.Show();
            this.Close();
        }

        private void Button_Click_1SAVESub(object sender, RoutedEventArgs e)
        {

            var skillName = Convert.ToString(SkillIDtoStore9.Content);
            var percToMast = Convert.ToString(lblResult.Content);

            List<string> subskillList = new List<string>();

            if (subSkillSpawn1.Visibility == Visibility.Visible)
            {
                var subskill1 = $"{subSkillSpawn1.Text} - {subSkillSpawnPerc1.Text}";

                subskillList.Add(subskill1);
            }
            else if (subSkillSpawn1.Visibility == Visibility.Visible && subSkillSpawn2.Visibility == Visibility.Visible)
            {
                var subskill1 = $"{subSkillSpawn1.Text} - {subSkillSpawnPerc1.Text}";
                var subskill2 = $"{subSkillSpawn2.Text} - {subSkillSpawnPerc2.Text}";

                subskillList.Add(subskill1);
                subskillList.Add(subskill2);
            }
            else if (subSkillSpawn1.Visibility == Visibility.Visible && subSkillSpawn2.Visibility == Visibility.Visible && subSkillSpawn3.Visibility == Visibility.Visible)
            {
                var subskill1 = $"{subSkillSpawn1.Text} - {subSkillSpawnPerc1.Text}";
                var subskill2 = $"{subSkillSpawn2.Text} - {subSkillSpawnPerc2.Text}";
                var subskill3 = $"{subSkillSpawn3.Text} - {subSkillSpawnPerc3.Text}";

                subskillList.Add(subskill1);
                subskillList.Add(subskill2);
                subskillList.Add(subskill3);
            }
            else if (subSkillSpawn1.Visibility == Visibility.Visible && subSkillSpawn2.Visibility == Visibility.Visible && subSkillSpawn3.Visibility == Visibility.Visible && subSkillSpawn4.Visibility == Visibility.Visible)
            {
                var subskill1 = $"{subSkillSpawn1.Text} - {subSkillSpawnPerc1.Text}";
                var subskill2 = $"{subSkillSpawn2.Text} - {subSkillSpawnPerc2.Text}";
                var subskill3 = $"{subSkillSpawn3.Text} - {subSkillSpawnPerc3.Text}";
                var subskill4 = $"{subSkillSpawn4.Text} - {subSkillSpawnPerc4.Text}";

                subskillList.Add(subskill1);
                subskillList.Add(subskill2);
                subskillList.Add(subskill3);
                subskillList.Add(subskill4);
            }
            else if (subSkillSpawn1.Visibility == Visibility.Visible && subSkillSpawn2.Visibility == Visibility.Visible && subSkillSpawn3.Visibility == Visibility.Visible && subSkillSpawn4.Visibility == Visibility.Visible && subSkillSpawn5.Visibility == Visibility.Visible)
            {
                var subskill1 = $"{subSkillSpawn1.Text} - {subSkillSpawnPerc1.Text}";
                var subskill2 = $"{subSkillSpawn2.Text} - {subSkillSpawnPerc2.Text}";
                var subskill3 = $"{subSkillSpawn3.Text} - {subSkillSpawnPerc3.Text}";
                var subskill4 = $"{subSkillSpawn4.Text} - {subSkillSpawnPerc4.Text}";
                var subskill5 = $"{subSkillSpawn5.Text} - {subSkillSpawnPerc5.Text}";

                subskillList.Add(subskill1);
                subskillList.Add(subskill2);
                subskillList.Add(subskill3);
                subskillList.Add(subskill4);
                subskillList.Add(subskill5);
            }
            else if (subSkillSpawn1.Visibility == Visibility.Visible && subSkillSpawn2.Visibility == Visibility.Visible && subSkillSpawn3.Visibility == Visibility.Visible && subSkillSpawn4.Visibility == Visibility.Visible && subSkillSpawn5.Visibility == Visibility.Visible && subSkillSpawn6.Visibility == Visibility.Visible)
            {
                var subskill1 = $"{subSkillSpawn1.Text} - {subSkillSpawnPerc1.Text}";
                var subskill2 = $"{subSkillSpawn2.Text} - {subSkillSpawnPerc2.Text}";
                var subskill3 = $"{subSkillSpawn3.Text} - {subSkillSpawnPerc3.Text}";
                var subskill4 = $"{subSkillSpawn4.Text} - {subSkillSpawnPerc4.Text}";
                var subskill5 = $"{subSkillSpawn5.Text} - {subSkillSpawnPerc5.Text}";
                var subskill6 = $"{subSkillSpawn6.Text} - {subSkillSpawnPerc6.Text}";

                subskillList.Add(subskill1);
                subskillList.Add(subskill2);
                subskillList.Add(subskill3);
                subskillList.Add(subskill4);
                subskillList.Add(subskill5);
                subskillList.Add(subskill6);
            }

            //subskillList.ToList<SubSkill>();

            var finalsubskill = new List<SubSkill>();

            //using (var db = new SkillMasteryContext())
            //{

            //    var skillIDfromNameQuery =
            //        db.SkillToMasters.Where(c => c.SkillName == skillName).Where(c => c.PercToMast == percToMast).Select(c => c.SkillToMasterId).FirstOrDefault();

            //    _userManager.AddSubSkill(skillIDfromNameQuery, finalsubskill);
            //}

            Window8 window8 = new Window8();
            window8.Show();
            this.Close();
        }

        private void Button_Click_2AddSubClass(object sender, RoutedEventArgs e)
        {

            int requiredSubskills = Convert.ToInt32(nmbOfClassesToSpawn.Text);

            switch (requiredSubskills)
            {
                case 1:
                    subSkillSpawn1.Visibility = Visibility.Visible;
                    subSkillSpawnPerc1.Visibility = Visibility.Visible;
                    subSkillSpawn2.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc2.Visibility = Visibility.Hidden;
                    subSkillSpawn3.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc3.Visibility = Visibility.Hidden;
                    subSkillSpawn4.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc4.Visibility = Visibility.Hidden;
                    subSkillSpawn5.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc5.Visibility = Visibility.Hidden;
                    subSkillSpawn6.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc6.Visibility = Visibility.Hidden;
                    lblResult.Content = "";
                    break;
                case 2:
                    subSkillSpawn1.Visibility = Visibility.Visible;
                    subSkillSpawnPerc1.Visibility = Visibility.Visible;
                    subSkillSpawn2.Visibility = Visibility.Visible;
                    subSkillSpawnPerc2.Visibility = Visibility.Visible;
                    subSkillSpawn3.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc3.Visibility = Visibility.Hidden;
                    subSkillSpawn4.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc4.Visibility = Visibility.Hidden;
                    subSkillSpawn5.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc5.Visibility = Visibility.Hidden;
                    subSkillSpawn6.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc6.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    subSkillSpawn1.Visibility = Visibility.Visible;
                    subSkillSpawnPerc1.Visibility = Visibility.Visible;
                    subSkillSpawn2.Visibility = Visibility.Visible;
                    subSkillSpawnPerc2.Visibility = Visibility.Visible;
                    subSkillSpawn3.Visibility = Visibility.Visible;
                    subSkillSpawnPerc3.Visibility = Visibility.Visible;
                    subSkillSpawn4.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc4.Visibility = Visibility.Hidden;
                    subSkillSpawn5.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc5.Visibility = Visibility.Hidden;
                    subSkillSpawn6.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc6.Visibility = Visibility.Hidden;
                    lblResult.Content = "";
                    break;
                case 4:
                    subSkillSpawn1.Visibility = Visibility.Visible;
                    subSkillSpawnPerc1.Visibility = Visibility.Visible;
                    subSkillSpawn2.Visibility = Visibility.Visible;
                    subSkillSpawnPerc2.Visibility = Visibility.Visible;
                    subSkillSpawn3.Visibility = Visibility.Visible;
                    subSkillSpawnPerc3.Visibility = Visibility.Visible;
                    subSkillSpawn4.Visibility = Visibility.Visible;
                    subSkillSpawnPerc4.Visibility = Visibility.Visible;
                    subSkillSpawn5.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc5.Visibility = Visibility.Hidden;
                    subSkillSpawn6.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc6.Visibility = Visibility.Hidden;
                    lblResult.Content = "";
                    break;
                case 5:
                    subSkillSpawn1.Visibility = Visibility.Visible;
                    subSkillSpawnPerc1.Visibility = Visibility.Visible;
                    subSkillSpawn2.Visibility = Visibility.Visible;
                    subSkillSpawnPerc2.Visibility = Visibility.Visible;
                    subSkillSpawn3.Visibility = Visibility.Visible;
                    subSkillSpawnPerc3.Visibility = Visibility.Visible;
                    subSkillSpawn4.Visibility = Visibility.Visible;
                    subSkillSpawnPerc4.Visibility = Visibility.Visible;
                    subSkillSpawn5.Visibility = Visibility.Visible;
                    subSkillSpawnPerc5.Visibility = Visibility.Visible;
                    subSkillSpawn6.Visibility = Visibility.Hidden;
                    subSkillSpawnPerc6.Visibility = Visibility.Hidden;
                    lblResult.Content = "";
                    break;
                case 6:
                    subSkillSpawn1.Visibility = Visibility.Visible;
                    subSkillSpawnPerc1.Visibility = Visibility.Visible;
                    subSkillSpawn2.Visibility = Visibility.Visible;
                    subSkillSpawnPerc2.Visibility = Visibility.Visible;
                    subSkillSpawn3.Visibility = Visibility.Visible;
                    subSkillSpawnPerc3.Visibility = Visibility.Visible;
                    subSkillSpawn4.Visibility = Visibility.Visible;
                    subSkillSpawnPerc4.Visibility = Visibility.Visible;
                    subSkillSpawn5.Visibility = Visibility.Visible;
                    subSkillSpawnPerc5.Visibility = Visibility.Visible;
                    subSkillSpawn6.Visibility = Visibility.Visible;
                    subSkillSpawnPerc6.Visibility = Visibility.Visible;
                    lblResult.Content = "";
                    break;
                default:
                    if (requiredSubskills == null)
                    {
                        lblResult.Content = "INVALID SPAWN AMOUNT (1-6 ALLOWED)";
                    }
                    lblResult.Content = "INVALID SPAWN AMOUNT (1-6 ALLOWED)";
                    break;




            }
        }

        private void exitAppBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

   
    }
}
