using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DESSscret.Tools;
namespace DESSscret
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string beforString = "3123";
            beforString = beforString.PadRight(65, '0');
            int stringLength = beforString.Length;
            string a = (beforString.Length > 64) && (beforString.Length % 64 != 0) ? beforString.PadRight(64 - stringLength % 64 + stringLength, '0') : beforString.PadRight(64, '0');
            textBox.Text = a + " " + a.Length.ToString();
        }
    }
}
