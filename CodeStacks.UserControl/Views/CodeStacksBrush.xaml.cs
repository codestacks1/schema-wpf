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

namespace Xiaowen.CodeStacks.UserControls.Views
{
    /// <summary>
    /// Interaction logic for CodeStacksBrush.xaml
    /// </summary>
    public partial class CodeStacksBrush : UserControl
    {
        public CodeStacksBrush()
        {
            InitializeComponent();
            btn1.Background = new SolidColorBrush(Color.FromRgb(224, 37, 37));
        }
    }
}
