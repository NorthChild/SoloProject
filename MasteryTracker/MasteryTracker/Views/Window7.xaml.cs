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
            Window8 window8 = new Window8();
            window8.Show();
            this.Close();

            
            string skillName = Convert.ToString(SkillNameRes.Text);
            string totHrsSoFarRes = Convert.ToString(totHrsSoFarResult.Content);
            string currentYrlHrsR = Convert.ToString(currentYrlHrsRes.Content);
            string currentProgRe = Convert.ToString(currentProgrRes.Content);
            string estYrsMasRe = Convert.ToString(estYrsMastRes.Content);

            
            userManager.AddSKill(skillName, totHrsSoFarRes, currentYrlHrsR, currentProgRe, estYrsMasRe);


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
            this.Close();
        }
    }
}
