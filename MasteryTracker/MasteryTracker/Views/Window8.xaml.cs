﻿using System;
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
        private UserManager _userManager = new UserManager();

        public Window8()
        {
            InitializeComponent();
            PopulateSkillListBox();
            

        }

        private void PopulateSkillListBox()
        {
            var userID = Convert.ToString(UserIDtoStore8.Content);
            ListBoxResult.ItemsSource = _userManager.RetreiveUserSkills(userID);
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

        private void ListBoxResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            // to do ??

            


        }
    }
}
