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
            byte[] a = Encoding.Default.GetBytes("aaa");
            string[] b = new string[a.Length];
            string c = "";
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = a[i].ToString("x").PadLeft(4, '0');

            }

            textBox1.Text = DESTool.getInstace().DESencrypt("012DEF11RdfdfTGFDEFDdvdfF方法", "133457799BBCDFF1");
            textBox2.Text = DESTool.getInstace().DESdecrypt("25bd91e16f523fd0021ca28a269f123617a59dd6215e596393c60432a5f1ef4f", "133457799BBCDFF1");
        }
    }
}
