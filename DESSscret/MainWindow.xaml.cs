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
            int a = 11;
            string aa = "dddsd";
            byte[] ab = Encoding.Default.GetBytes(aa);
            string b="";
            for (int i = 0; i < ab.Length; i++)
                b += Convert.ToString(ab[i], 2);
            string c = b.Substring(0, 1);

            int d = Convert.ToInt32(c);
            Console.Write(b + " " + c + " " + d + " ");
        }
    }
}
