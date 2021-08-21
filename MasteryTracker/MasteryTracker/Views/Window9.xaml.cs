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

namespace MasteryTracker.Views
{
    /// <summary>
    /// Interaction logic for Window9.xaml
    /// </summary>
    public partial class Window9 : Window
    {
        public Window9()
        {
            InitializeComponent();

            var userNameID = UserIDtoStore9.Content;
        }

        private void Button_ClickExitSubSkill(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

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
