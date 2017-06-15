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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PS_project_auto.Model;
using PS_project_auto.View;
using PS_project_auto.ModelView;
namespace PS_project_auto.View
{
    /// <summary>
    /// Interaction logic for InsurancePage.xaml
    /// </summary>
    public partial class InsurancePage : Page
    {
        public static InsurancePage page;
        public InsurancePage()
        {
            page = this;
            DataContext = new InsuranceViewModel();
            InitializeComponent();
        }
    }
}