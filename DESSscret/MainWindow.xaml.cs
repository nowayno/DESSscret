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
            //以下是测试十六进制明文的加解密，用来验证加密解密是否正确
            //textBox1.Text = DESTool.getInstace().DESencrypt("0123456789ABCDEF", "133457799BBCDFF1");
            //textBox2.Text = DESTool.getInstace().DESdecrypt("a28b7a0e74430f5e", "133457799BBCDFF1");

            textBox1.Text = DESTool.getInstace().DESencrypt("0123456789ABCDEF", "133457799BBCDFF1");
            textBox2.Text = DESTool.getInstace().DESdecrypt("a28b7a0e74430f5e", "133457799BBCDFF1");
        }
    }
}
