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
            byte[] a = Encoding.Default.GetBytes("FED");
            string[] b = new string[a.Length];
            string c = "";
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = a[i].ToString("x").PadLeft(4, '0');
               
            } string bb = Convert.ToString(Convert.ToInt32("B",16), 2);
            textBox.Text = DESTool.getInstace().DESencrypt("0123456789ABCDEF", "133457799BBCDFF1");
        }
    }
}
