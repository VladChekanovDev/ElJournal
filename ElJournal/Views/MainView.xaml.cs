using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ElJournal.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            switch (CurrentUser.UserType)
            {
                case 0:
                    MainContentControl.Content = new AdminControlView();
                    break;
                case 1:
                    MainContentControl.Content = new TeacherControlView();
                    break;
            }
        }
    }
}
